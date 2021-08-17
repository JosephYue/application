using Application.EntityFrameworkCore.Extension.Interface;

namespace Application.EntityFrameworkCore.Extension
{
    /// <summary>
    /// 实体实现
    /// </summary>
    /// <typeparam name="T">主键类型</typeparam>
    public abstract class Entity<T> : IEntity<T>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public virtual T Id { get; set; }
    }
}
