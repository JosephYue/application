namespace Application.SqlSugar.Extension.Interface
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// 开始事务
        /// </summary>
        void BeginTran();

        /// <summary>
        /// 提交事务
        /// </summary>
        void CommitTran();

        /// <summary>
        /// 回滚
        /// </summary>
        void RollbackTran();
    }
}
