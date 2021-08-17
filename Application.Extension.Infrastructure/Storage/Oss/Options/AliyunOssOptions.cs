using Newtonsoft.Json;

namespace Application.Extension.Infrastructure.Storage.Oss.Options
{
    public class AliyunOssOptions
    {
        /// <summary>
        /// 阿里云绑定的域名
        /// </summary>
        [JsonProperty("aliyunDomain")]
        public string AliyunDomain { get; set; } = string.Empty;

        /// <summary>
        /// 阿里云路径的前缀
        /// </summary>
        [JsonProperty("aliyunPrefix")]
        public string AliyunPrefix { get; set; } = string.Empty;

        /// <summary>
        /// 阿里云EndPoint
        /// </summary>
        [JsonProperty("aliyunEndPoint")]
        public string AliyunEndPoint { get; set; } = string.Empty;

        /// <summary>
        /// 阿里云AccessKeyId
        /// </summary>
        [JsonProperty("aliyunAccessKeyId")]
        public string AliyunAccessKeyId { get; set; } = string.Empty;

        /// <summary>
        /// 阿里云AccessKeySecret
        /// </summary>
        [JsonProperty("aliyunAccessKeySecret")]
        public string AliyunAccessKeySecret { get; set; } = string.Empty;

        /// <summary>
        /// 阿里云BucketName
        /// </summary>
        [JsonProperty("aliyunBucketName")]
        public string AliyunBucketName { get; set; } = string.Empty;

        /// <summary>
        /// 是否是PresignedUri
        /// </summary>
        public bool IsPresignedUri { get; set; }

        /// <summary>
        /// 下载结束标识
        /// </summary>
        public string DownEndPoint { get; set; } = string.Empty;
    }
}
