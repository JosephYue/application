using Application.Extension.Infrastructure.InfluxDb.Attributes;
using InfluxData.Net.InfluxDb.ClientModules;
using InfluxData.Net.InfluxDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Extension.Infrastructure.InfluxDb.Extensions
{
    public static class BasicClientModuleExtensions
    {
        #region 添加

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="basicClientModule">Influx client</param>
        /// <param name="entity">实体</param>
        /// <param name="dbName">数据库名称（可指定，不指定走默认）</param>
        /// <param name="retentionPolicy">策略名称（不传不走策略，传值走策略）</param>
        /// <returns></returns>
        public static async Task AddAsync<TEntity>(this IBasicClientModule basicClientModule, TEntity entity, string dbName = "", string retentionPolicy = "")
           where TEntity : class, new()
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var type = entity.GetType();

            var point = new Point
            {
                Name = type.Name,
                Tags = new Dictionary<string, object>(),
                Fields = new Dictionary<string, object>()
            };

            foreach (var property in type.GetProperties())
            {
                var tagAttribute = property.GetCustomAttributes(false).OfType<InfluxTagAttribute>().FirstOrDefault();

                if (tagAttribute != null)
                {
                    point.Tags.Add(property.Name, property.GetValue(entity) ?? string.Empty);
                    continue;
                }

                point.Fields.Add(property.Name, property.GetValue(entity) ?? string.Empty);
            }

            await basicClientModule.WriteAsync(point, dbName, retentionPolicy);
        }

        #endregion

        #region 查询列表

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="basicClientModule">Influx client</param>
        /// <param name="querySql">查询sql语句</param>
        /// <returns></returns>
        public static async Task<List<TEntity>> GetListAsync<TEntity>(this IBasicClientModule basicClientModule, string querySql)
            where TEntity : class, new()
        {
            if (string.IsNullOrWhiteSpace(querySql))
            {
                throw new ArgumentNullException(nameof(querySql));
            }

            var result = new List<TEntity>();

            var type = typeof(TEntity);

            var series = await basicClientModule.QueryAsync(querySql);

            var serie = series.FirstOrDefault();

            if (serie == null)
            {
                return result;
            }

            foreach (var val in serie.Values)
            {
                var entity = new TEntity();

                for (int i = 0; i < serie.Columns.Count; i++)
                {
                    var column = serie.Columns[i];
                    if (column == "time")
                    {
                        continue;
                    }

                    var originValue = val[i];
                    var property = type.GetProperty(column);

                    if (property != null)
                    {
                        var changedValue = Convert.ChangeType(originValue, property.PropertyType);
                        property.SetValue(entity, changedValue);
                    }
                }

                result.Add(entity);
            }

            return result;
        }

        #endregion

        #region 查询单条数据

        /// <summary>
        /// 查询单条数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="basicClientModule">Influx client</param>
        /// <param name="querySql">查询sql语句</param>
        /// <returns></returns>
        public static async Task<TEntity> GetFirstOrDefaultAsync<TEntity>(this IBasicClientModule basicClientModule, string querySql)
            where TEntity : class, new()
        {
            if (string.IsNullOrWhiteSpace(querySql))
            {
                throw new ArgumentNullException(nameof(querySql));
            }

            var result = new TEntity();

            var type = typeof(TEntity);

            var series = await basicClientModule.QueryAsync(querySql);

            var serie = series.FirstOrDefault();

            if (serie == null)
            {
                return result;
            }

            foreach (var val in serie.Values)
            {
                var entity = new TEntity();

                for (int i = 0; i < serie.Columns.Count; i++)
                {
                    var column = serie.Columns[i];
                    if (column == "time")
                    {
                        continue;
                    }

                    var originValue = val[i];
                    var property = type.GetProperty(column);

                    if (property != null)
                    {
                        var changedValue = Convert.ChangeType(originValue, property.PropertyType);
                        property.SetValue(entity, changedValue);
                    }
                }

                if (entity != null)
                {
                    result = entity;
                    continue;
                }
            }

            return result;
        }

        #endregion

        #region 分页查询

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="basicClientModule">Influx client</param>
        /// <param name="querySql">查询语句</param>
        /// <returns></returns>
        public static async Task<(int, List<TEntity>?)> GetPageListAsync<TEntity>(this IBasicClientModule basicClientModule, string querySql)
            where TEntity : class, new()
        {
            var (totalCount, result, queries, type) = new ValueTuple<int, List<TEntity>, List<string>, Type>();

            Initialization();

            var countProperty = type?.GetProperties().FirstOrDefault(r => !r.GetCustomAttributes(false).OfType<InfluxTagAttribute>().Any());
            if (countProperty == null)
            {
                throw new InvalidOperationException("无法查询数据数量，请检查表内是否存在可查询字段");
            }

            var countQuery = $"SELECT COUNT(\"{countProperty.Name}\") FROM {type?.Name}";
            queries?.Add(countQuery);

            var series = await basicClientModule.QueryAsync(queries);
            var serie = series.FirstOrDefault();

            if (serie == null)
            {
                return (totalCount, result);
            }

            var countSerie = series.LastOrDefault();

            if (countSerie != null)
            {
                totalCount = Convert.ToInt32(countSerie.Values.FirstOrDefault().LastOrDefault());
            }

            foreach (var val in serie.Values)
            {
                var entity = new TEntity();

                for (int i = 0; i < serie.Columns.Count; i++)
                {
                    var column = serie.Columns[i];
                    if (column == "time")
                    {
                        continue;
                    }

                    var originValue = val[i];
                    var property = type?.GetProperty(column);

                    if (property != null)
                    {
                        var changedValue = Convert.ChangeType(originValue, property.PropertyType);
                        property.SetValue(entity, changedValue);
                    }
                }

                result?.Add(entity);
            }

            return (totalCount, result);

            void Initialization()
            {
                result = new List<TEntity>();
                queries = new List<string> { querySql };
                type = typeof(TEntity);
            }
        }

        #endregion
    }
}
