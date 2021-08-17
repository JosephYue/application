using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    public class GoodsActivityQueryParam
    {
        /// <summary>
        /// 页码，默认1
        /// </summary>
        [JsonProperty("pageIndex")]
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页数量，默认20，上限50
        /// </summary>

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        /// <summary>
        /// 活动物料ID
        /// 1：营销日历热门会场
        /// 2：营销日历热门榜单
        /// 6：PC站长端官方活动
        /// </summary>
        [JsonProperty("poolId")]
        public int PoolId { get; set; }

        /// <summary>
        /// 按单个日期查询活动，查询日期范围为过去或未来15天。建议按日期依次查询当天及未来的活动
        /// </summary>
        [JsonProperty("activeDate")]
        public string ActiveDate { get; set; }

        internal void Validate()
        {
           
        }
    }
}
