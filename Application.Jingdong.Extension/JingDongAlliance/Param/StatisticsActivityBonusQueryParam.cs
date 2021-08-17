using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    /// <summary>
    /// 奖励活动奖励金额查询业务参数
    /// </summary>
    public class StatisticsActivityBonusQueryParam : ValidateParam
    {
        /// <summary>
        /// 奖励活动Id
        /// </summary>
        [JsonProperty("activityId")]
        public int ActivityId { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        internal override void Validate()
        {
            if (ActivityId <= 0)
            {
                throw new ArgumentNullException(nameof(ActivityId));
            }
        }
    }
}
