using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    /// <summary>
    /// 奖励活动信息查询接口业务参数
    /// </summary>
    public class ActivityBonusQueryParam : ValidateParam
    {
        /// <summary>
        /// 奖励活动Id
        /// </summary>
        [JsonProperty("activityId")]
        public int ActivityId { get; set; }

        /// <summary>
        /// 奖励活动开始时间,开始时间为最近90天，时间戳（ms）
        /// </summary>
        [JsonProperty("beginTime")]
        public string BeginTime { get; set; }

        /// <summary>
        /// 奖励活动结束时间，时间戳（ms）
        /// </summary>
        [JsonProperty("endTime")]
        public string EndTime { get; set; }

        /// <summary>
        /// 索引
        /// </summary>
        [JsonProperty("pageIndex")]
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页数量
        /// </summary>
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        internal override void Validate()
        {
            if (string.IsNullOrWhiteSpace(BeginTime))
            {
                throw new ArgumentNullException(nameof(BeginTime));
            }
            if (string.IsNullOrWhiteSpace(EndTime))
            {
                throw new ArgumentNullException(nameof(EndTime));
            }
            if (PageIndex <= 0)
            {
                throw new ArgumentNullException(nameof(PageIndex));
            }
            if (PageSize <= 0)
            {
                throw new ArgumentNullException(nameof(PageSize));
            }
        }
    }
}
