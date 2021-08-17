using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    /// <summary>
    /// 工具商订单行查询接口业务参数
    /// </summary>
    public class OrderAgentQueryParam : ValidateParam
    {
        /// <summary>
        /// 页码
        /// </summary>
        [JsonProperty("pageIndex")]
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页包含条数，上限为500
        /// </summary>
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        /// <summary>
        /// 订单时间查询类型
        /// 1：下单时间
        /// 2：完成时间
        /// 3：更新时间
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }

        /// <summary>
        /// 开始时间 格式yyyy-MM-dd HH:mm:ss，与endTime间隔不超过20分钟
        /// </summary>
        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        /// <summary>
        /// 结束时间 格式yyyy-MM-dd HH:mm:ss，与startTime间隔不超过20分钟
        /// </summary>
        [JsonProperty("endTime")]
        public string EndTime { get; set; }

        /// <summary>
        /// 筛选出参，多项逗号分隔，目前支持：categoryInfo、goodsInfo
        /// </summary>
        [JsonProperty("fields")]
        public string Fields { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        internal override void Validate()
        {
            if (PageIndex <= 0)
            {
                throw new ArgumentNullException(nameof(PageIndex));
            }
            if (PageSize <= 0 || PageSize > 500)
            {
                throw new ArgumentNullException(nameof(PageSize));
            }
            if (Type != 1 && Type != 2 && Type != 3)
            {
                throw new ArgumentNullException(nameof(Type));
            }
            if (string.IsNullOrWhiteSpace(StartTime))
            {
                throw new ArgumentNullException(nameof(StartTime));
            }
            if (string.IsNullOrWhiteSpace(EndTime))
            {
                throw new ArgumentNullException(nameof(EndTime));
            }
        }
    }
}
