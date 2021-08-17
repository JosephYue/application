namespace Application.EntityFrameworkCore.Extension.Migration.Interface
{
    public interface IEntityFrameworkCoreMigration
    {
        /// <summary>
        /// 迁移表结构
        /// </summary>
        /// <returns></returns>
        bool Migrate();
    }
}
