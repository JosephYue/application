using Application.EntityFrameworkCore.Extension.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.EntityFrameworkCore.Extension
{
    /// <summary>
    /// 增删改查仓储接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="T"></typeparam>
    public class RepositoryBase<TEntity, T> : IRepository<TEntity, T> where TEntity : Entity<T>, IAggregateRoot<T>
    {
        /// <summary>
        /// 单元模式
        /// </summary>
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// 数据库上下文
        /// </summary>
        private readonly DbContext Dbcontext;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unitOfWork"></param>
        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Dbcontext = unitOfWork as DbContext;
        }

        /// <summary>
        /// 设置当前DbContext
        /// </summary>
        /// <returns></returns>
        protected DbSet<TEntity> DbSet()
        {
            return Dbcontext.Set<TEntity>();
        }

        /// <summary>
        /// 设置DbContext
        /// </summary>
        /// <typeparam name="DbEntity"></typeparam>
        /// <returns></returns>
        protected DbSet<DbEntity> DbSet<DbEntity>() where DbEntity : class, new()
        {
            return Dbcontext.Set<DbEntity>();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        public void Add(TEntity entity)
        {
            Dbcontext.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// 异步添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task AddAsync(TEntity entity)
        {
            await Dbcontext.Set<TEntity>().AddAsync(entity);
        }

        /// <summary>
        /// 添加集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public void AddRange(List<TEntity> entities)
        {
            Dbcontext.Set<TEntity>().AddRange(entities);
        }

        /// <summary>
        /// 添加集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public async Task AddRangeAsync(List<TEntity> entities)
        {
            await Dbcontext.Set<TEntity>().AddRangeAsync(entities);
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="entity">实体</param>
        public void Remove(TEntity entity)
        {
            Dbcontext.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// 批量移除
        /// </summary>
        /// <param name="entities">实体集合</param>
        public void RemoveRange(List<TEntity> entities)
        {
            Dbcontext.Set<TEntity>().RemoveRange(entities);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">实体</param>
        public void Update(TEntity entity)
        {
            Dbcontext.Set<TEntity>().Update(entity);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entities">实体集合</param>
        public void UpdateRange(List<TEntity> entities)
        {
            Dbcontext.Set<TEntity>().UpdateRange(entities);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="autoCommit">是否自动提交</param>
        public void Add(TEntity entity, bool autoCommit)
        {
            Dbcontext.Set<TEntity>().Add(entity);

            if (autoCommit)
            {
                UnitOfWork.Commit();
            }
        }

        /// <summary>
        /// 异步添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="autoCommit">是否自动提交</param>
        /// <returns></returns>
        public async Task AddAsync(TEntity entity, bool autoCommit)
        {
            await Dbcontext.Set<TEntity>().AddAsync(entity);

            if (autoCommit)
            {
                await UnitOfWork.CommitAsync();
            }
        }

        /// <summary>
        /// 添加集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="autoCommit">是否自动提交</param>
        public void AddRange(List<TEntity> entities, bool autoCommit)
        {
            Dbcontext.Set<TEntity>().AddRange(entities);

            if (autoCommit)
            {
                UnitOfWork.Commit();
            }
        }

        /// <summary>
        /// 添加集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="autoCommit">是否自动提交</param>
        public async Task AddRangeAsync(List<TEntity> entities, bool autoCommit)
        {
            await Dbcontext.Set<TEntity>().AddRangeAsync(entities);

            if (autoCommit)
            {
                await UnitOfWork.CommitAsync();
            }
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="autoCommit">是否自动提交</param>
        public void Remove(TEntity entity, bool autoCommit)
        {
            Dbcontext.Set<TEntity>().Remove(entity);

            if (autoCommit)
            {
                UnitOfWork.Commit();
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="autoCommit">是否自动提交</param>
        public void Update(TEntity entity, bool autoCommit)
        {
            Dbcontext.Set<TEntity>().Update(entity);

            if (autoCommit)
            {
                UnitOfWork.Commit();
            }
        }

        /// <summary>
        /// 根据主键id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity FindById(T id)
        {
            return Dbcontext.Set<TEntity>().Find(id);
        }
    }
}
