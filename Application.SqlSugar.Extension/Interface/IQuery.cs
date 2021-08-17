using SqlSugar;

namespace Application.SqlSugar.Extension.Interface
{
    public interface IQuery<TEntity, T> where TEntity : IEntity<T>
    {
        /// <summary>
        /// 获取IQueryable的方法
        /// </summary>
        /// <returns></returns>
        ISugarQueryable<TEntity> GetQueryable();
    }
}
