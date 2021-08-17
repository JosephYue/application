namespace Application.SqlSugar.Extension.Interface
{
    public interface IEntity<T>
    {
        /// <summary>
        /// id
        /// </summary>
        T Id { get; }
    }
}
