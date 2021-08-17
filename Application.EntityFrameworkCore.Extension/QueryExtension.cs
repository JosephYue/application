using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.EntityFrameworkCore.Extension
{
    public static class QueryExtension
    {
        #region 得到IQueryable<T>的分页后实体集合

        /// <summary>
        /// 得到IQueryable的分页后实体集合
        /// </summary>
        /// <param name="query">实体</param>
        /// <param name="pageSize">每页多少条数据</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="isTotal">是否统计总行数</param>
        /// <returns></returns>
        public static PageData<T> ListPager<T>(this IQueryable<T> query, int pageSize, int pageIndex, bool isTotal)
        {
            PageData<T> list = new PageData<T>();

            if (isTotal)
            {
                list.RowCount = query.Count();
            }

            if (pageSize <= 0 && pageSize != -1)
            {
                throw new Exception("页大小设置有误");
            }

            if (pageIndex - 1 < 0 && pageSize != -1)
            {
                throw new Exception("页码必须大于等于1");
            }

            if (pageIndex - 1 >= 0 && pageSize > 0)
            {
                query = query.Skip((pageIndex - 1) * pageSize);
            }

            if (pageSize > 0)
            {
                query = query.Take(pageSize);
            }

            list.Data = query.ToList();

            return list;
        }

        #endregion

        #region 对list集合分页

        /// <summary>
        /// 对list集合分页
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageSize">页码</param>
        /// <param name="pageIndex">页大小</param>
        /// <param name="isTotal">是否计算总条数</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static PageData<T> ListPager<T>(this ICollection<T> query, int pageSize, int pageIndex, bool isTotal)
        {
            PageData<T> list = new PageData<T>();

            if (isTotal)
            {
                list.RowCount = query.Count();
            }

            if (pageIndex - 1 < 0)
            {
                throw new Exception("页码必须大于等于1");
            }

            query = query.Skip((pageIndex - 1) * pageSize).ToList();
            if (pageSize > 0)
            {
                list.Data = query.Take(pageSize).ToList();
            }
            else if (pageSize < 1 && pageSize != -1)
            {
                throw new Exception("页大小须等于-1或者大于0");
            }
            else
            {
                list.Data = query.ToList();
            }

            return list;
        }

        #endregion
    }
}
