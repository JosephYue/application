using System.Linq;

namespace Application.EntityFrameworkCore.Extension.Interface
{
    /// <summary>
    /// 查询方法
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="T"></typeparam>
    public interface IQuery<TEntity, T> where TEntity : IEntity<T>
    {
        /// <summary>
        /// 获取IQueryable的方法（非跟踪查询 不可用于修改、删除、添加）
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetQueryable();
    }
}
