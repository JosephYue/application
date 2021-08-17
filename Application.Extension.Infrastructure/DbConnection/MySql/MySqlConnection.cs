using Application.Extension.Infrastructure.DbConnection.MySql.Interface;
using Application.Extension.Infrastructure.DbConnection.MySql.Options;
using Microsoft.Extensions.Options;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace Application.Extension.Infrastructure.DbConnection.MySql
{
    public class MySql : IMySqlConnection
    {
        private readonly MySqlOptions _mySqlOption;

        public MySql(IOptions<MySqlOptions> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(MySqlOptions));
            }

            _mySqlOption = options.Value;
        }

        #region 添加/编辑

        /// <summary>
        /// 添加/编辑
        /// </summary>
        /// <param name="sql">sql语句</param>
        public void Execute(string sql)
        {
            using var connection = new MySqlConnection(_mySqlOption.ConnectionString);

            connection.ExecuteNonQuery(sql, sqlParams: new object[0]);
        }

        /// <summary>
        /// 添加/编辑
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="sqlParams">sql语句拼接的参数</param>
        public void Execute(string sql, object[] sqlParams)
        {
            using var connection = new MySqlConnection(_mySqlOption.ConnectionString);

            connection.ExecuteNonQuery(sql, sqlParams: sqlParams);
        }

        #endregion

        #region 查询

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="func">委托（用来修改返回参数）</param>
        /// <param name="sqlParams">可拼接的sqlParams</param>
        /// <returns></returns>
        public T Query<T>(string sql, Func<IDataReader, T> func, params object[] sqlParams)
        {
            using var connection = new MySqlConnection(_mySqlOption.ConnectionString);

            var result = connection.ExecuteReader(sql, func, sqlParams);

            return result;
        }

        /// <summary>
        /// 查询（直接返回列表）
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="sqlParams">sql语句的sqlParams</param>
        /// <returns></returns>
        public List<T> Query<T>(string sql, params object[] sqlParams)
        {
            using var connection = new MySqlConnection(_mySqlOption.ConnectionString);

            var result = connection.ExecuteReader<T>(sql, sqlParams);

            return result;
        }

        #endregion
    }
}
