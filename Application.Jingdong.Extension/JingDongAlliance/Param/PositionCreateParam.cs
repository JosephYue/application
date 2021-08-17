using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    /// <summary>
    /// 创建推广位(申请)业务参数
    /// </summary>
    public class PositionCreateParam : ValidateParam
    {
        /// <summary>
        /// 需要创建的目标联盟id
        /// </summary>
        [JsonProperty("unionId")]
        public long UnionId { get; set; }

        /// <summary>
        /// 推客unionid对应的“授权Key”
        /// 在联盟官网-我的工具-我的API中查询
        /// 授权Key具有唯一性，有效期365天
        /// 删除或创建新的授权Key后原有的授权Key自动失效
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// 3：私域推广位，上限5000个，不在联盟后台展示，无对应 PID
        /// 4：联盟后台推广位，上限500个，会在推客联盟后台展示，自动生成对应PID，可用于内容平台推广
        /// </summary>
        [JsonProperty("unionType")]
        public int UnionType { get; set; }

        /// <summary>
        /// 站点类型 
        /// 1.网站推广位
        /// 2.APP推广位
        /// 3.导购媒体推广位
        /// 4.聊天工具推广位
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }

        /// <summary>
        /// 推广位名称集合，英文,分割
        /// 上限50
        /// </summary>
        [JsonProperty("spaceNameList")]
        public string[] SpaceNameList { get; set; }

        /// <summary>
        /// 站点ID：网站的ID/app ID/snsID 
        /// 当type非4(聊天工具)时，siteId必填
        /// </summary>
        [JsonProperty("siteId")]
        public long? SiteId { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        internal override void Validate()
        {
            if (UnionId <= 0)
            {
                throw new ArgumentNullException(nameof(UnionId));
            }
            if (string.IsNullOrWhiteSpace(Key))
            {
                throw new ArgumentNullException(nameof(Key));
            }
            if (UnionType <= 0)
            {
                throw new ArgumentNullException(nameof(UnionType));
            }
            if (Type <= 0)
            {
                throw new ArgumentNullException(nameof(Type));
            }
            if (SpaceNameList == null || SpaceNameList.Length==0)
            {
                throw new ArgumentNullException(nameof(SpaceNameList));
            }
        }
    }
}
