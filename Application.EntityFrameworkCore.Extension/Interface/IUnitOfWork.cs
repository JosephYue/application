using System.Threading.Tasks;

namespace Application.EntityFrameworkCore.Extension.Interface
{
    /// <summary>
    /// 单元模式
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 提交事务保存至数据库
        /// </summary>
        /// <returns></returns>
        bool Commit();

        /// <summary>
        /// 提交事务保存至数据库
        /// </summary>
        /// <returns></returns>
        Task<bool> CommitAsync();

        /// <summary>
        /// 回滚
        /// </summary>
        /// <returns></returns>
        bool RollBack();
    }
}
