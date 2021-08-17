using Newtonsoft.Json;

namespace Application.DingTalk.Extension.Model
{
    /// <summary>
    /// 文本内容
    /// </summary>
    internal class TextContent
    {
        /// <summary>
        /// 内容
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; } = string.Empty;
    }
}
