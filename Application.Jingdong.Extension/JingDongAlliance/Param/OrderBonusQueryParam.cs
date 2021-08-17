using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    /// <summary>
    /// 奖励订单查询接口(申请)业务参数
    /// </summary>
    public class OrderBonusQueryParam : ValidateParam
    {
        /// <summary>
        /// 时间类型
        /// 1.下单时间拉取
        /// 2.更新时间拉取
        /// </summary>
        [JsonProperty("optType")]
        public int OptType { get; set; }

        /// <summary>
        /// 订单开始时间，时间戳（毫秒），与endTime间隔不超过10分钟
        /// </summary>
        [JsonProperty("startTime")]
        public long StartTime { get; set; }

        /// <summary>
        /// 订单结束时间，时间戳（毫秒），与startTime间隔不超过10分钟
        /// </summary>
        [JsonProperty("endTime")]
        public long EndTime { get; set; }

        /// <summary>
        /// 页码，默认值为1
        /// </summary>
        [JsonProperty("pageNo")]
        public int PageNo { get; set; }

        /// <summary>
        /// 每页数量，上限100
        /// </summary>
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        /// <summary>
        /// 与pageNo、pageSize组合使用。获取当前页最后一条记录的sortValue，下一页请求传入该值
        /// </summary>
        [JsonProperty("sortValue")]
        public string SortValue { get; set; }

        /// <summary>
        /// 奖励活动ID
        /// </summary>
        [JsonProperty("activityId")]
        public int ActivityId { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        internal override void Validate()
        {
            if (OptType != 1 && OptType != 2)
            {
                throw new ArgumentNullException(nameof(OptType));
            }
            if (StartTime <= 0)
            {
                throw new ArgumentNullException(nameof(StartTime));
            }
            if (EndTime <= 0)
            {
                throw new ArgumentNullException(nameof(EndTime));
            }
            if (PageNo <= 0)
            {
                throw new ArgumentNullException(nameof(PageNo));
            }
            if (PageSize <= 0 && PageSize > 100)
            {
                throw new ArgumentNullException(nameof(PageSize));
            }
            if (string.IsNullOrWhiteSpace(SortValue))
            {
                throw new ArgumentNullException(nameof(SortValue));
            }
        }
    }
}
