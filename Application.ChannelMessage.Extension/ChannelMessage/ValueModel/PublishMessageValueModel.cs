using Application.ChannelMessage.Extension.ChannelMessage.Enum.Status;
using Newtonsoft.Json;

namespace Application.ChannelMessage.Extension.ChannelMessage.ValueModel
{
    public class PublishMessageValueModel
    {
        /// <summary>
        /// 消息id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 订阅名称
        /// </summary>
        [JsonProperty("subscriberName")]
        public string SubscriberName { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// 执行原因
        /// </summary>
        [JsonProperty("executeMessage")]
        public string ExecuteMessage { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty("status")]
        public MessageStatusEnum Status { get; set; }
    }

    public class ReceiveMessageValueModel : PublishMessageValueModel
    {
        /// <summary>
        /// 分组
        /// </summary>
        [JsonProperty("group")]
        public string Group { get; set; }

        /// <summary>
        /// 发送者消息id
        /// </summary>
        [JsonProperty("publishMsgId")]
        public string PublishMessageId { get; set; }
    }
}
