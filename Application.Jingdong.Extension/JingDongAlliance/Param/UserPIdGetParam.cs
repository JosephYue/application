using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    /// <summary>
    /// 获取PId(申请)业务参数
    /// </summary>
    public class UserPIdGetParam : ValidateParam
    {
        /// <summary>
        /// 联盟ID
        /// </summary>
        [JsonProperty("unionId")]
        public long UnionId { get; set; }

        /// <summary>
        /// 子站长ID
        /// </summary>
        [JsonProperty("childUnionId")]
        public long ChildUnionId { get; set; }

        /// <summary>
        /// 推广类型
        /// 1APP推广 
        /// 2聊天工具推广
        /// </summary>
        [JsonProperty("promotionType")]
        public int PromotionType { get; set; }

        /// <summary>
        /// 子站长的推广位名称，如不存在则创建，不填则由联盟根据母账号信息创建
        /// </summary>
        [JsonProperty("positionName")]
        public string PositionName { get; set; }

        /// <summary>
        /// 媒体名称，即子站长的app应用名称，推广方式为app推广时必填，且app名称必须为已存在的app名称
        /// </summary>
        [JsonProperty("mediaName")]
        public string MediaName { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        internal override void Validate()
        {
            if (UnionId <= 0)
            {
                throw new ArgumentNullException(nameof(UnionId));
            }
            if (ChildUnionId <= 0)
            {
                throw new ArgumentNullException(nameof(ChildUnionId));
            }
            if (PromotionType != 1 && PromotionType != 2)
            {
                throw new ArgumentNullException(nameof(PromotionType));
            }
            if (string.IsNullOrWhiteSpace(MediaName))
            {
                throw new ArgumentNullException(nameof(MediaName));
            }
        }
    }
}
