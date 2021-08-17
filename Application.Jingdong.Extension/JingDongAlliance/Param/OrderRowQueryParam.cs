using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    /// <summary>
    /// 订单行查询接口业务参数
    /// </summary>
    public class OrderRowQueryParam : ValidateParam
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
        /// 2：完成时间（购买用户确认收货时间）
        /// 3：更新时间
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }

        /// <summary>
        /// 开始时间 格式yyyy-MM-dd HH:mm:ss，与endTime间隔不超过1小时
        /// </summary>
        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        /// <summary>
        /// 结束时间 格式yyyy-MM-dd HH:mm:ss，与startTime间隔不超过1小时
        /// </summary>
        [JsonProperty("endTime")]
        public string EndTime { get; set; }

        /// <summary>
        /// 子推客unionID，传入该值可查询子推客的订单，注意不可和key同时传入。（需联系运营开通PID权限才能拿到数据）
        /// </summary>
        [JsonProperty("childUnionId")]
        public long? ChildUnionId { get; set; }

        /// <summary>
        /// 工具商传入推客的授权key，可帮助该推客查询订单，注意不可和childUnionid同时传入。（需联系运营开通工具商权限才能拿到数据）
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// 支持出参数据筛选，逗号','分隔，目前可用：goodsInfo（商品信息）,categoryInfo(类目信息）
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
