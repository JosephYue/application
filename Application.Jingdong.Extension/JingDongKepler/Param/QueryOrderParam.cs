using Newtonsoft.Json;
using System;

namespace Application.Jingdong.Extension.JingDongKepler.Param
{
    public class QueryOrderParam : ValidateParam
    {
        /// <summary>
        /// 可选参数，如果传了orderId则只匹配该订单号，返回对应的订单信息；如果未传orderId，则根据其他参数返回时间段范围内的订单详情列表
        /// </summary>
        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        /// <summary>
        /// 查询起始时间 yyyymmddhhmmss格式
        /// </summary>
        [JsonProperty("beginTime")]
        public string BeginTime { get; set; }

        /// <summary>
        /// 查询截止时间 yyyymmddhhmmss格式
        /// </summary>
        [JsonProperty("endTime")]
        public string EndTime { get; set; }

        /// <summary>
        /// 查询开始页数
        /// </summary>
        [JsonProperty("pageIndex")]
        public int PageIndex { get; set; }

        /// <summary>
        /// 每次查询显示的条数
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
