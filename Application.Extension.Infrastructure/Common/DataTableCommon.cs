using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Application.Extension.Infrastructure.Common
{
    public static class DataTableCommon
    {
        #region 将指定的集合转换成DataTable

        /// <summary>
        /// 将指定的集合转换成DataTable
        /// </summary>
        /// <param name="list">将指定的集合</param>
        /// <param name="hasColumns">是否包含TableColumns</param>
        /// <returns>返回转换后的DataTable</returns>
        public static DataTable ToDataTable(this IList list, bool hasColumns = true)
        {
            DataTable table = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[]? propertys = list[0]?.GetType().GetProperties();

                if (propertys == null)
                {
                    return table;
                }

                if (hasColumns)
                {
                    foreach (PropertyInfo pi in propertys)
                    {
                        Type pt = pi.PropertyType;

                        if (pt.IsGenericType && (pt.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            pt = pt.GetGenericArguments()[0];
                        }

                        table.Columns.Add(new DataColumn(pi.Name, pt));
                    }
                }

                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();

                    foreach (PropertyInfo pi in propertys)
                    {
                        object? obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }

                    table.LoadDataRow(tempList.ToArray(), true);
                }
            }
            return table;
        }

        /// <summary>
        /// 将指定的集合转换成DataTable
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="list">集合信息</param>
        /// <param name="hasColumns">是否包含TableColumns</param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this List<T> list, bool hasColumns = true)
        {
            DataTable table = new DataTable();
            PropertyInfo[] propertys = typeof(T).GetProperties();

            if (hasColumns)
            {
                //创建列头
                foreach (PropertyInfo pi in propertys)
                {
                    Type pt = pi.PropertyType;
                    if (pt.IsGenericType && (pt.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    {
                        pt = pt.GetGenericArguments()[0];
                    }
                    table.Columns.Add(new DataColumn(pi.Name, pt));
                }
            }

            //创建数据行
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();

                    foreach (PropertyInfo pi in propertys)
                    {
                        object? obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }

                    table.LoadDataRow(tempList.ToArray(), true);
                }
            }

            return table;
        }

        /// <summary>
        /// 将指定的集合转换成DataTable
        /// </summary>
        /// <param name="list">将指定的集合</param>
        /// <param name="table">DataTable信息</param>
        /// <param name="hasColumns">是否包含TableColumns</param>
        /// <returns>返回转换后的DataTable</returns>
        public static DataTable ToDataTable(this IList list, DataTable table, bool hasColumns = true)
        {
            if (table is null)
            {
                table = new DataTable();
            }

            if (list.Count > 0)
            {
                PropertyInfo[]? propertys = list[0]?.GetType().GetProperties();

                if (propertys == null)
                {
                    return table;
                }

                if (hasColumns)
                {
                    foreach (PropertyInfo pi in propertys)
                    {
                        Type pt = pi.PropertyType;

                        if (pt.IsGenericType && (pt.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            pt = pt.GetGenericArguments()[0];
                        }

                        table.Columns.Add(new DataColumn(pi.Name, pt));
                    }
                }

                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object? obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }

                    table.LoadDataRow(tempList.ToArray(), true);
                }
            }
            return table;
        }

        /// <summary>
        /// 将指定的集合转换成DataTable
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="list">集合信息</param>
        /// <param name="table">DataTable信息</param>
        /// <param name="hasColumns">是否包含TableColumns</param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this List<T> list, DataTable table, bool hasColumns = true)
        {
            if (table is null)
            {
                table = new DataTable();
            }

            PropertyInfo[] propertys = typeof(T).GetProperties();

            if (hasColumns)
            {
                //创建列头
                foreach (PropertyInfo pi in propertys)
                {
                    Type pt = pi.PropertyType;
                    if (pt.IsGenericType && (pt.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    {
                        pt = pt.GetGenericArguments()[0];
                    }
                    table.Columns.Add(new DataColumn(pi.Name, pt));
                }
            }

            //创建数据行
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();

                    foreach (PropertyInfo pi in propertys)
                    {
                        object? obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }

                    table.LoadDataRow(tempList.ToArray(), true);
                }
            }

            return table;
        }

        #endregion

        #region 将指定的DataTable转换为实体

        /// <summary>
        /// 将DataTable转换为实体
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="table">DataTable信息</param>
        /// <returns></returns>
        public static T ToEntity<T>(this DataTable table) where T : new()
        {
            T entity = new T();
            foreach (DataRow? row in table.Rows)
            {
                if (row == null)
                {
                    continue;
                }

                foreach (var item in entity.GetType().GetProperties())
                {
                    if (row.Table.Columns.Contains(item.Name))
                    {
                        if (DBNull.Value != row[item.Name])
                        {
                            Type newType = item.PropertyType;
                            //判断type类型是否为泛型，因为nullable是泛型类,
                            if (newType.IsGenericType
                                    && newType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))//判断convertsionType是否为nullable泛型类
                            {
                                //如果type为nullable类，声明一个NullableConverter类，该类提供从Nullable类到基础基元类型的转换
                                System.ComponentModel.NullableConverter nullableConverter = new System.ComponentModel.NullableConverter(newType);
                                //将type转换为nullable对的基础基元类型
                                newType = nullableConverter.UnderlyingType;
                            }

                            item.SetValue(entity, Convert.ChangeType(row[item.Name], newType), null);

                        }

                    }
                }
            }

            return entity;
        }

        /// <summary>
        /// 将DataTable转换为实体集合
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="table">DataTable信息</param>
        /// <returns></returns>
        public static List<T>? ToEntities<T>(this DataTable table) where T : new()
        {
            List<T> entities = new List<T>();
            if (table == null)
                return null;

            foreach (DataRow? row in table.Rows)
            {

                if (row == null)
                {
                    continue;
                }

                T entity = new T();
                foreach (var item in entity.GetType().GetProperties())
                {
                    if (table.Columns.Contains(item.Name))
                    {
                        if (DBNull.Value != row[item.Name])
                        {
                            Type newType = item.PropertyType;
                            //判断type类型是否为泛型，因为nullable是泛型类,
                            if (newType.IsGenericType
                                    && newType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))//判断convertsionType是否为nullable泛型类
                            {
                                //如果type为nullable类，声明一个NullableConverter类，该类提供从Nullable类到基础基元类型的转换
                                System.ComponentModel.NullableConverter nullableConverter = new System.ComponentModel.NullableConverter(newType);
                                //将type转换为nullable对的基础基元类型
                                newType = nullableConverter.UnderlyingType;
                            }
                            item.SetValue(entity, Convert.ChangeType(row[item.Name], newType), null);
                        }
                    }
                }
                entities.Add(entity);
            }
            return entities;
        }

        #endregion
    }
}
