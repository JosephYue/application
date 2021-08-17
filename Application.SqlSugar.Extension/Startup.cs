using Application.SqlSugar.Extension.Config;
using Application.SqlSugar.Extension.Config.Options;
using Application.SqlSugar.Extension.Interface;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;

namespace Application.SqlSugar.Extension
{
    /// <summary>
    /// 配置信息
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// 添加SqlSugar服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="optionsBuilder">配置信息</param>
        public static void AddSqlSugar(this IServiceCollection services, Action<SqlSugarOption> optionsBuilder)
        {
            if (optionsBuilder == null)
            {
                throw new ArgumentNullException(nameof(SqlSugarOption));
            }

            services.AddScoped<IUnitOfWork, SqlSugarDbContext>();
            services.AddScoped(typeof(IQuery<,>), typeof(QueryBase<,>));
            services.AddScoped(typeof(IRepository<,>), typeof(RepositoryBase<,>));

            var option = new SqlSugarOption();

            optionsBuilder?.Invoke(option);

            if (option.ConnectionConfig == null)
            {
                throw new ArgumentNullException(nameof(ConnectionConfig));
            }

            SqlSugarConfiguration.ConnectionConfig = option.ConnectionConfig;

            services.Configure(optionsBuilder);
        }
    }
}
