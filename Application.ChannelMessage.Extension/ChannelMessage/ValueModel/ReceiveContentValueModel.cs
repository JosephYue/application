using Newtonsoft.Json;

namespace Application.ChannelMessage.Extension.ChannelMessage.ValueModel
{
    internal class ReceiveContentValueModel
    {
        /// <summary>
        /// 发送者消息id
        /// </summary>
        [JsonProperty("publishMsgId")]
        public string PublishMsgId { get; set; } 

        /// <summary>
        /// 消息内容
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
