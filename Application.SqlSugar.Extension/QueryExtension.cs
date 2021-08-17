using SqlSugar;
using System;
using System.Threading.Tasks;

namespace Application.SqlSugar.Extension
{
    public static class QueryExtension
    {
        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable">查询实体</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public static PageData<T> ListPager<T>(this ISugarQueryable<T> queryable, int pageSize, int pageIndex)
        {
            int total = 0;

            var queryResult = queryable.ToPageList(pageIndex, pageSize, ref total);

            var pageCount = (int)Math.Ceiling((decimal)(total / pageSize));

            var result = new PageData<T>
            {
                Data = queryResult,
                RowCount = pageCount,
            };

            return result;
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable">查询实体</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public static async Task<PageData<T>> ListPagerAsync<T>(this ISugarQueryable<T> queryable, int pageSize, int pageIndex)
        {
            RefAsync<int> total = 0;

            var queryResult = await queryable.ToPageListAsync(pageIndex, pageSize, total);

            var pageCount = (int)Math.Ceiling((decimal)(total.Value / pageSize));

            var result = new PageData<T>
            {
                Data = queryResult,
                RowCount = pageCount,
            };

            return result;
        }
    }
}
