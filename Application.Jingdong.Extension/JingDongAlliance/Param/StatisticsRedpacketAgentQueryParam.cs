using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    /// <summary>
    /// 工具商京享红包效果数据业务参数
    /// </summary>
    public class StatisticsRedpacketAgentQueryParam : ValidateParam
    {
        /// <summary>
        /// 京享红包活动Id，如不传则查询全部京享红包活动
        /// </summary>
        [JsonProperty("actId")]
        public long? ActId { get; set; }

        /// <summary>
        /// 开始日期yyyy-MM-dd，不可超出最近90天
        /// </summary>
        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        /// <summary>
        /// 结束时间yyyy-MM-dd，不可超出最近90天
        /// </summary>
        [JsonProperty("endDate")]
        public string EndDate { get; set; }

        /// <summary>
        /// 页码，起始1
        /// </summary>
        [JsonProperty("pageIndex")]
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页数，大于等于10且小于等于100的正整数
        /// </summary>
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        internal override void Validate()
        {
            if (string.IsNullOrWhiteSpace(StartDate))
            {
                throw new ArgumentNullException(nameof(StartDate));
            }
            if (string.IsNullOrWhiteSpace(EndDate))
            {
                throw new ArgumentNullException(nameof(EndDate));
            }
            if (PageIndex <= 0)
            {
                throw new ArgumentNullException(nameof(PageIndex));
            }
            if (PageSize < 10 || PageSize > 100)
            {
                throw new ArgumentNullException(nameof(PageSize));
            }
        }
    }
}
