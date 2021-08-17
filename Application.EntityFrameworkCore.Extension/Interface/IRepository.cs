using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.EntityFrameworkCore.Extension.Interface
{
    public interface IRepository<TEntity, T> where TEntity : IAggregateRoot<T>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        void Add(TEntity entity);

        /// <summary>
        /// 异步添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体</param>
        void Remove(TEntity entity);

        /// <summary>
        /// 批量移除
        /// </summary>
        /// <param name="entities">实体</param>
        void RemoveRange(List<TEntity> entities);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">实体</param>
        void Update(TEntity entity);

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entities">实体集合</param>
        void UpdateRange(List<TEntity> entities);

        /// <summary>
        /// 添加集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void AddRange(List<TEntity> entities);

        /// <summary>
        /// 添加集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        Task AddRangeAsync(List<TEntity> entities);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="autoCommit">是否自动提交事务</param>
        void Add(TEntity entity, bool autoCommit);

        /// <summary>
        /// 异步添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        /// <param name="autoCommit">是否自动提交事务</param>
        Task AddAsync(TEntity entity, bool autoCommit);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="autoCommit">是否自动提交事务</param>
        void Remove(TEntity entity, bool autoCommit);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="autoCommit">是否自动提交事务</param>
        void Update(TEntity entity, bool autoCommit);

        /// <summary>
        /// 添加集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="autoCommit">是否自动提交事务</param>
        void AddRange(List<TEntity> entities, bool autoCommit);

        /// <summary>
        /// 添加集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="autoCommit">是否自动提交事务</param>
        Task AddRangeAsync(List<TEntity> entities, bool autoCommit);

        /// <summary>
        /// 根据主键id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity FindById(T id);
    }
}
