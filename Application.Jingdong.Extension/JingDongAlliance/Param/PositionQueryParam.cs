using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    /// <summary>
    /// 查询推广位(申请)业务参数
    /// </summary>
    public class PositionQueryParam : ValidateParam
    {
        /// <summary>
        /// 需要查询的目标联盟id
        /// </summary>
        [JsonProperty("unionId")]
        public long UnionId { get; set; }

        /// <summary>
        /// 推客unionid对应的“授权Key”，在联盟官网-我的工具-我的API中查询，授权Key具有唯一性，有效期365天，删除或创建新的授权Key后原有的授权Key自动失效
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// 3：私域推广位，上限5000个，不在联盟后台展示，无对应 PID
        /// 4：联盟后台推广位，上限500个，会在推客联盟后台展示，可用于内容平台推广
        /// </summary>
        [JsonProperty("unionType")]
        public int UnionType { get; set; }

        /// <summary>
        /// 页码，上限100
        /// </summary>
        [JsonProperty("pageIndex")]
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页条数，上限100
        /// </summary>
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

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
            if (UnionType != 3 && UnionType != 4)
            {
                throw new ArgumentNullException(nameof(UnionType));
            }
            if (PageIndex <= 0 && PageIndex > 100)
            {
                throw new ArgumentNullException(nameof(PageIndex));
            }
            if (PageSize <= 0 && PageSize > 100)
            {
                throw new ArgumentNullException(nameof(PageSize));
            }
        }
    }
}
