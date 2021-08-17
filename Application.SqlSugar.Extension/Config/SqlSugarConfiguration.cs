using SqlSugar;
using System;
using System.Linq;

namespace Application.SqlSugar.Extension.Config
{
    public class SqlSugarConfiguration
    {
        /// <summary>
        /// 获取链接信息
        /// </summary>
        internal static ConnectionConfig ConnectionConfig { get; set; }

        /// <summary>
        /// 初始化表结构
        /// </summary>
        public static void InitializeTables()
        {
            var dbcontext = new SqlSugarClient(ConnectionConfig);

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assemblie in assemblies)
            {
                var tableTypes = assemblie.GetTypes().Where(x => x.CustomAttributes.Any(x => x.AttributeType == typeof(SugarTable))).ToArray();

                if (tableTypes.Count() > 0)
                {
                    Console.WriteLine($"初始化数据表：{string.Join<Type>(',', tableTypes)}");

                    dbcontext.CodeFirst.InitTables(tableTypes);
                }
            }
        }
    }
}
