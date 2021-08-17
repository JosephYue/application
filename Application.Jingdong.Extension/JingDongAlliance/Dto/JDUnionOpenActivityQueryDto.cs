using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    public class JDUnionOpenActivityQueryDto
    {
        /// <summary>
        ///  返回参数
        /// </summary>
        [JsonProperty("jd_union_open_activity_query_responce")]
        public ResponseBaseDto Response { get; set; }
    }

    public class ActivityQueryInfoResponseDto
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 数据明细
        /// </summary>
        [JsonProperty("data")]
        public List<ActivityRespResponseDto> Data { get; set; }
    }

    public class ActivityRespResponseDto
    {
        /// <summary>
        /// 活动落地页-PC
        /// </summary>
        [JsonProperty("urlPC")]
        public string UrlPC { get; set; }

        /// <summary>
        /// 活动落地页-移动端
        /// </summary>
        [JsonProperty("urlM")]
        public string UrlM { get; set; }

        /// <summary>
        /// 活动主题
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 活动利益点
        /// </summary>
        [JsonProperty("advantage")]
        public string Advantage { get; set; }

        /// <summary>
        /// 活动开始时间
        /// </summary>
        [JsonProperty("startTime")]
        public long StartTime { get; set; }

        /// <summary>
        /// 活动结束时间
        /// </summary>
        [JsonProperty("endTime")]
        public long EndTime { get; set; }

        /// <summary>
        /// 商品资源位id，调用京粉精选商品查询接口传入此参数可获取活动SKU
        /// </summary>
        [JsonProperty("eliteId")]
        public int EliteId { get; set; }

        /// <summary>
        /// 推荐指数，从1到5，越高越好
        /// </summary>
        [JsonProperty("recommend")]
        public int Recommend { get; set; }

        /// <summary>
        /// 活动素材下载链接
        /// </summary>
        [JsonProperty("downloadUrl")]
        public string DownloadUrl { get; set; }

        /// <summary>
        /// 活动素材提取码
        /// </summary>
        [JsonProperty("downloadCode")]
        public string DownloadCode { get; set; }

        /// <summary>
        /// 活动更新时间
        /// </summary>
        [JsonProperty("updateTime")]
        public long UpdateTime { get; set; }

        /// <summary>
        /// 活动规则、描述、说明
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// 活动标签
        /// 1：大促活动
        /// 2：佣金提升活动
        /// 3：常规活动
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// 活动状态
        /// 1：未开始
        /// 2：进行中
        /// 3：已结束
        /// </summary>
        [JsonProperty("actStatus")]
        public int ActStatus { get; set; }

        /// <summary>
        /// 主推开始时间
        /// </summary>
        [JsonProperty("promotionStartTime")]
        public long PromotionStartTime { get; set; }

        /// <summary>
        /// 主推结束时间
        /// </summary>
        [JsonProperty("promotionEndTime")]
        public long PromotionEndTime { get; set; }

        /// <summary>
        /// 活动推广平台
        /// 1：仅支持PC推广
        /// 2：仅支持移动端推广
        /// 3：PC和移动端均支持推广
        /// </summary>
        [JsonProperty("platformType")]
        public int PlatformType { get; set; }

        /// <summary>
        /// 图片集
        /// </summary>
        [JsonProperty("imgList")]
        public List<ActivityImageDto> ImgList { get; set; }

        /// <summary>
        /// 活动ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// 类目集
        /// </summary>
        public List<ActivityCategoryListDto> CategoryList { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
    }

    /// <summary>
    /// 图片集
    /// </summary>
    public class ActivityImageDto
    {
        /// <summary>
        /// 图片尺寸
        /// </summary>
        [JsonProperty("widthHeight")]
        public string WidthHeight { get; set; }

        /// <summary>
        /// 图片名称
        /// </summary>
        [JsonProperty("imgName")]
        public string ImgName { get; set; }

        /// <summary>
        /// 图片链接
        /// </summary>
        [JsonProperty("imgUrl")]
        public string ImgUrl { get; set; }
    }

    /// <summary>
    /// 类目集
    /// </summary>
    public class ActivityCategoryListDto
    {
        /// <summary>
        /// 类目
        /// </summary>
        [JsonProperty("activityCategory")]
        public ActivityCategoryDto ActivityCategory { get; set; }
    }

    /// <summary>
    /// 类目
    /// </summary>
    public class ActivityCategoryDto
    {
        /// <summary>
        /// 类目Id
        /// </summary>
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        /// <summary>
        /// 类目级别(需枚举，当前京挑客活动全部为一级类目)
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }
    }
}
