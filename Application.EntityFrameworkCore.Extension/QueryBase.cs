using Application.EntityFrameworkCore.Extension.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.EntityFrameworkCore.Extension
{
    public sealed class QueryBase<TEntity, T> : IQuery<TEntity, T> where TEntity : class, IEntity<T>
    {
        /// <summary>
        ///数据库上下文
        /// </summary>
        private readonly DbContext Dbcontext;

        /// <summary>
        ///构造函数
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public QueryBase(IUnitOfWork unitOfWork)
        {
            Dbcontext = unitOfWork as DbContext;
        }

        /// <summary>
        /// 获取IQueryable （非跟踪查询 不可用于修改、删除、添加）
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetQueryable()
        {
            return Dbcontext.Set<TEntity>().AsNoTracking();
        }
    }
}
