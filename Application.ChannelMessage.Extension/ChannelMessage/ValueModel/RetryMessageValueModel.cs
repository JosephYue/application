using Newtonsoft.Json;

namespace Application.ChannelMessage.Extension.ChannelMessage.ValueModel
{
    public class RetryMessageValueModel
    {
        /// <summary>
        /// 消息id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// 重试次数
        /// </summary>
        [JsonProperty("retries")]
        public int Retries { get; set; }

        /// <summary>
        /// 订阅队列名
        /// </summary>
        [JsonProperty("subscriberName")]
        public string SubscriberName { get; set; }

        /// <summary>
        /// 分组名称
        /// </summary>
        [JsonProperty("group")]
        public string Group { get; set; }
    }
}
