using Application.SqlSugar.Extension.Interface;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.SqlSugar.Extension
{
    public class RepositoryBase<TEntity, T> : SimpleClient<TEntity>, IRepository<TEntity, T> where TEntity : class, IEntity<T>, new()
    {
        public RepositoryBase(IUnitOfWork context) : base(context as SqlSugarClient)
        {

        }

        /// <summary>
        /// 设置当前DbContext
        /// </summary>
        /// <returns></returns>
        protected ISugarQueryable<TEntity> DbSet()
        {
            return AsQueryable();
        }

        /// <summary>
        /// 根据实体移除
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public bool Remove(TEntity entity)
        {
            return base.Delete(entity);
        }

        /// <summary>
        /// 根据实体移除
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(TEntity entity)
        {
            return await base.DeleteAsync(entity);
        }

        /// <summary>
        /// 根据表达式移除
        /// </summary>
        /// <param name="whereExpression">表达式</param>
        /// <returns></returns>
        public bool Remove(Expression<Func<TEntity, bool>> whereExpression)
        {
            return base.Delete(whereExpression);
        }

        /// <summary>
        /// 根据表达式移除
        /// </summary>
        /// <param name="whereExpression">表达式</param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await base.DeleteAsync(whereExpression);
        }

        /// <summary>
        /// 根据主键id删除
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        public bool RemoveById(T id)
        {
            return base.DeleteById(id);
        }

        /// <summary>
        /// 根据主键id删除
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        public async Task<bool> RemoveByIdAsync(T id)
        {
            return await base.DeleteByIdAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public T Add(TEntity entity)
        {
            if (typeof(T) == typeof(int))
            {
                return (T)Convert.ChangeType(InsertReturnIdentity(entity), typeof(T));
            }
            else if (typeof(T) == typeof(long))
            {
                return (T)Convert.ChangeType(InsertReturnBigIdentity(entity), typeof(T));
            }
            else
            {
                Insert(entity);
                return default;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task<T> AddAsync(TEntity entity)
        {
            if (typeof(T) == typeof(int))
            {
                return (T)Convert.ChangeType(await InsertReturnIdentityAsync(entity), typeof(T));
            }
            else if (typeof(T) == typeof(long))
            {
                return (T)Convert.ChangeType(await InsertReturnBigIdentityAsync(entity), typeof(T));
            }
            else
            {
                await InsertAsync(entity);
                return default;
            }
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns>是否添加成功</returns>
        public bool AddRange(List<TEntity> entities)
        {
            return InsertRange(entities);
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns>是否添加成功</returns>
        public async Task<bool> AddRangeAsunc(List<TEntity> entities)
        {
            return await InsertRangeAsync(entities);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public new bool Update(TEntity entity)
        {
            return base.Update(entity);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public new async Task<bool> UpdateAsync(TEntity entity)
        {
            return await base.UpdateAsync(entity);
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        public new bool UpdateRange(List<TEntity> entities)
        {
            return base.UpdateRange(entities);
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        public new async Task<bool> UpdateRangeAsync(List<TEntity> entities)
        {
            return await base.UpdateRangeAsync(entities);
        }
    }
}
