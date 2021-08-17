using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Dto
{
    /// <summary>
    /// 商品类目查询Dto
    /// </summary>
    public class JDUnionOpenCategoryGoodsGetDto
    {
        /// <summary>
        ///  返回参数
        /// </summary>
        [JsonProperty("jd_union_open_category_goods_get_responce")]
        public ResponseDto Response { get; set; }
    }
    public class ResponseDto
    {
        /// <summary>
        /// 查询结果 (接口查询)
        /// </summary>
        [JsonProperty("getResult")]
        public string GetResult { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }
    }

     
    public class JDUnionOpenCategoryGoodsDto
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
        public List<CategoryRespResponseDto> Data { get; set; }
    }
    /// <summary>
    /// 数据明细
    /// </summary>
    public class CategoryRespResponseDto
    {
        /// <summary>
        /// 类目Id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// 类目名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 类目级别(类目级别 0，1，2 代表一、二、三级类目)
        /// </summary>
        [JsonProperty("grade")]
        public int Grade { get; set; }

        /// <summary>
        /// 父类目Id
        /// </summary>
        [JsonProperty("parentId")]
        public int ParentId { get; set; }
    }
}
