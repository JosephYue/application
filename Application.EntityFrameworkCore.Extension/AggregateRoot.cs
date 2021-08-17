using Application.EntityFrameworkCore.Extension.Interface;

namespace Application.EntityFrameworkCore.Extension
{
    /// <summary>
    /// 聚合跟实现
    /// </summary>
    /// <typeparam name="T">主键类型</typeparam>
    public abstract class AggregateRoot<T> : Entity<T>, IAggregateRoot<T>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AggregateRoot()
        {
            Id = default;
        }
    }
}
