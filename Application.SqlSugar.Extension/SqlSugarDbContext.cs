using Application.SqlSugar.Extension.Config;
using Application.SqlSugar.Extension.Interface;
using SqlSugar;

namespace Application.SqlSugar.Extension
{
    public class SqlSugarDbContext : SqlSugarClient, IUnitOfWork
    {
        public SqlSugarDbContext() : base(SqlSugarConfiguration.ConnectionConfig)
        {

        }
    }
}
