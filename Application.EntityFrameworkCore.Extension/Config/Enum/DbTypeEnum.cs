using System.ComponentModel;

namespace Application.EntityFrameworkCore.Extension.Config.Enum
{
    /// <summary>
    /// 数据库类型枚举
    /// </summary>
    public enum DbTypeEnum
    {
        /// <summary>
        /// MySql
        /// </summary>
        [Description("MySql")] MySql = 1,

        /// <summary>
        /// SqlServer
        /// </summary>
        [Description("SqlServer")] SqlServer = 2
    }
}
