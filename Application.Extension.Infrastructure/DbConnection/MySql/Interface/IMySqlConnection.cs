using System;
using System.Collections.Generic;
using System.Data;

namespace Application.Extension.Infrastructure.DbConnection.MySql.Interface
{
    public interface IMySqlConnection
    {
        /// <summary>
        /// 添加/编辑
        /// </summary>
        /// <param name="sql">sql语句</param>
        void Execute(string sql);

        /// <summary>
        /// 添加/编辑
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="sqlParams">sql语句拼接的参数</param>
        void Execute(string sql, object[] sqlParams);

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="func">委托（用来修改返回参数）</param>
        /// <param name="sqlParams">可拼接的sqlParams</param>
        /// <returns></returns>
        T Query<T>(string sql, Func<IDataReader, T> func, params object[] sqlParams);

        /// <summary>
        /// 查询（直接返回列表）
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="sqlParams">sql语句的sqlParams</param>
        /// <returns></returns>
        List<T> Query<T>(string sql, params object[] sqlParams);
    }
}
