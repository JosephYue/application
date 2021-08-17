using Application.ChannelMessage.Extension.DbConnection;
using MySqlConnector;
using System;
using System.Data;

namespace Application.ChannelMessage.Extension.ChannelMessage.Config
{
    internal class MySqlConnectionConfig
    {
        #region 添加/编辑

        /// <summary>
        /// 添加/编辑
        /// </summary>
        /// <param name="sql">sql语句</param>
        public void Execute(string sql)
        {
            using var connection = new MySqlConnection(ChannelMessageConfig.ChannelMessageOption.ConnectionString);

            connection.ExecuteNonQuery(sql, sqlParams: new object[0]);
        }

        /// <summary>
        /// 添加/编辑
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="sqlParams">sql语句拼接的参数</param>
        public void Execute(string sql, object[] sqlParams)
        {
            using var connection = new MySqlConnection(ChannelMessageConfig.ChannelMessageOption.ConnectionString);

            connection.ExecuteNonQuery(sql, sqlParams: sqlParams);
        }

        #endregion

        #region 查询

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="func">委托（用来修改返回参数）</param>
        /// <returns></returns>
        public T Query<T>(string sql, Func<IDataReader, T> func)
        {
            using var connection = new MySqlConnection(ChannelMessageConfig.ChannelMessageOption.ConnectionString);

            var result = connection.ExecuteReader(sql, func);

            return result;
        }

        #endregion
    }
}
