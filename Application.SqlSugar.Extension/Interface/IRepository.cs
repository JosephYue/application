using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.SqlSugar.Extension.Interface
{
    public interface IRepository<TEntity, T> where TEntity : IEntity<T>
    {
        /// <summary>
        /// 根据实体移除
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        bool Remove(TEntity entity);

        /// <summary>
        /// 根据实体移除
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<bool> RemoveAsync(TEntity entity);

        /// <summary>
        /// 根据表达式移除
        /// </summary>
        /// <param name="whereExpression">表达式</param>
        /// <returns></returns>
        bool Remove(Expression<Func<TEntity, bool>> whereExpression);

        /// <summary>
        /// 根据表达式移除
        /// </summary>
        /// <param name="whereExpression">表达式</param>
        /// <returns></returns>
        Task<bool> RemoveAsync(Expression<Func<TEntity, bool>> whereExpression);

        /// <summary>
        /// 根据主键id删除
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        bool RemoveById(T id);

        /// <summary>
        /// 根据主键id删除
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        Task<bool> RemoveByIdAsync(T id);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        T Add(TEntity entity);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<T> AddAsync(TEntity entity);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns>是否添加成功</returns>
        bool AddRange(List<TEntity> entities);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns>是否添加成功</returns>
        Task<bool> AddRangeAsunc(List<TEntity> entities);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        bool Update(TEntity entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(TEntity entity);

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        bool UpdateRange(List<TEntity> entities);

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        Task<bool> UpdateRangeAsync(List<TEntity> entities);
    }
}
