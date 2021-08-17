using InfluxData.Net.InfluxDb.Models.Responses;
using System.Collections.Generic;

namespace Application.Extension.Infrastructure.InfluxDb.Options
{
    public class InfluxDbClientOptions
    {
        /// <summary>
        /// 数据链接字符串
        /// </summary>
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// 数据库登录的用户名
        /// </summary>
        public string User { get; set; } = string.Empty;

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; } = string.Empty;

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DbName { get; set; } = string.Empty;

        /// <summary>
        /// 策略集合（可生成你自己的策略，只进行生成策略）
        /// </summary>
        public List<RetentionPolicy> RetentionPolicies { get; set; } = new List<RetentionPolicy>();
    }
}
