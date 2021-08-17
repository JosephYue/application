using Application.SqlSugar.Extension.Interface;
using SqlSugar;

namespace Application.SqlSugar.Extension
{
    public sealed class QueryBase<TEntity, T> : IQuery<TEntity, T> where TEntity : class, IEntity<T>
    {
        /// <summary>
        ///数据库上下文
        /// </summary>
        private readonly SqlSugarClient Dbcontext;

        /// <summary>
        ///构造函数
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public QueryBase(IUnitOfWork unitOfWork)
        {
            Dbcontext = unitOfWork as SqlSugarClient;
        }

        /// <summary>
        /// 获取IQueryable 
        /// </summary>
        /// <returns></returns>
        public ISugarQueryable<TEntity> GetQueryable()
        {
            return Dbcontext.Queryable<TEntity>();
        }
    }
}
