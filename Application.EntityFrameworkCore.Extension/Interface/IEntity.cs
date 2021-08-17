namespace Application.EntityFrameworkCore.Extension.Interface
{
    public interface IEntity<T>
    {
        /// <summary>
        /// 主键id
        /// </summary>
        T Id { get; }
    }
}
