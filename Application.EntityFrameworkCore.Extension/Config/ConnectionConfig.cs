using Application.EntityFrameworkCore.Extension.Config.Enum;

namespace Application.EntityFrameworkCore.Extension.Config
{
    /// <summary>
    /// 数据库连接配置信息
    /// </summary>
    public class ConnectionConfig
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public DbTypeEnum DbType { get; set; } = DbTypeEnum.MySql;

        /// <summary>
        /// 数据库映射的程序集名称
        /// </summary>
        public string MigrationsAssembly { get; set; }
    }
}
