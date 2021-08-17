using Newtonsoft.Json;
using System.Collections.Generic;

namespace Application.EntityFrameworkCore.Extension
{
    /// <summary>
    /// 分页数据集合
    /// </summary>
    public class PageData<T>
    {
        /// <summary>
        ///
        /// </summary>
        public PageData()
        {
            Data = new List<T>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="rowCount">总条数</param>
        /// <param name="data">数据集合</param>
        /// <param name="extendedData">扩展信息</param>
        public PageData(int rowCount, List<T> data, object extendedData)
        {
        }

        /// <summary>
        /// 总条数
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public virtual int RowCount { get; set; }

        /// <summary>
        /// 当前页数据集合
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public virtual ICollection<T> Data { get; set; }
    }
}
