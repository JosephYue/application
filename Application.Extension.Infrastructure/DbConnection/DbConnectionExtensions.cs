using Application.Extension.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace Application.Extension.Infrastructure.DbConnection
{
    internal static class DbConnectionExtensions
    {
        public static int ExecuteNonQuery(this IDbConnection connection, string sql, IDbTransaction? transaction = null, params object[] sqlParams)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            using IDbCommand command = connection.CreateCommand();

            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            foreach (var param in sqlParams)
            {
                command.Parameters.Add(param);
            }

            if (transaction != null)
            {
                command.Transaction = transaction;
            }

            return command.ExecuteNonQuery();
        }

        public static T ExecuteReader<T>(this IDbConnection connection, string sql, Func<IDataReader, T> readerFunc,
            params object[] sqlParams)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            foreach (var param in sqlParams)
            {
                command.Parameters.Add(param);
            }

            var reader = command.ExecuteReader();

            T result = default;

            if (readerFunc != null)
            {
                result = readerFunc(reader);
            }

#pragma warning disable CS8603 // 可能返回 null 引用。
            return result;
#pragma warning restore CS8603 // 可能返回 null 引用。
        }

        public static List<T> ExecuteReader<T>(this IDbConnection connection, string sql, params object[] sqlParams)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            foreach (var param in sqlParams)
            {
                command.Parameters.Add(param);
            }

            var reader = command.ExecuteReader();

            return reader.ConvertReaderToList<T>();
        }

        public static T ExecuteScalar<T>(this IDbConnection connection, string sql, params object[] sqlParams)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            foreach (var param in sqlParams)
            {
                command.Parameters.Add(param);
            }

            var objValue = command.ExecuteScalar();

            T result = default;
            if (objValue != null)
            {
                var returnType = typeof(T);
                var converter = TypeDescriptor.GetConverter(returnType);
                if (converter.CanConvertFrom(objValue.GetType()))
                {
                    result = (T)converter.ConvertFrom(objValue);
                }
                else
                {
                    result = (T)Convert.ChangeType(objValue, returnType);
                }
            }

#pragma warning disable CS8603 // 可能返回 null 引用。
            return result;
#pragma warning restore CS8603 // 可能返回 null 引用。
        }

        /// <summary>
        /// 转换DataReader
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="objReader">数据库的DataReader</param>
        /// <returns></returns>
        private static List<T> ConvertReaderToList<T>(this IDataReader objReader)
        {
            using (objReader)
            {
                List<T> list = new List<T>();

                //获取传入的数据类型
                Type modelType = typeof(T);

                //遍历DataReader对象
                while (objReader.Read())
                {
                    //使用与指定参数匹配最高的构造函数，来创建指定类型的实例
                    T model = Activator.CreateInstance<T>();
                    for (int i = 0; i < objReader.FieldCount; i++)
                    {
                        //判断字段值是否为空或不存在的值
                        if (!(objReader[i] == null || objReader[i] is DBNull))
                        {
                            //匹配字段名
                            PropertyInfo? pi = modelType.GetProperty(objReader.GetName(i),
                                BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance |
                                BindingFlags.IgnoreCase);

                            if (pi != null)
                            {
                                //绑定实体对象中同名的字段
                                pi.SetValue(model, objReader[i].ConvertToSpecifyType(pi.PropertyType), null);
                            }
                        }
                    }

                    list.Add(model);
                }

                return list;
            }
        }
    }
}
