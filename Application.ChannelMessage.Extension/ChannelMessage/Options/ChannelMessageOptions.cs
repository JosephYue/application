using Newtonsoft.Json;

namespace Application.ChannelMessage.Extension.ChannelMessage.Options
{
    public class ChannelMessageOptions
    {
        /// <summary>
        /// Gets or sets the database's connection string that will be used to store database entities.
        /// </summary>
        [JsonProperty("connectionString")]
        public string ConnectionString { get; set; }

        /// <summary>
        /// 表名前缀
        /// </summary>
        [JsonProperty("tableNamePrefix")]
        public string TableNamePrefix { get; set; } = "message";

        /// <summary>
        /// 失败重试次数
        /// </summary>
        [JsonProperty("failedRetryCount")]
        public int FailedRetryCount { get; set; } = 20;

        /// <summary>
        /// Failed messages polling delay time.
        /// Default is 60 seconds.
        /// Unit:Seconds
        /// </summary>
        public int FailedRetryInterval { get; set; } = 60;

        /// <summary>
        /// Sent or received succeed message after time span of due, then the message will be deleted at due time.
        /// Default is 24 * 3600 seconds.
        /// Unit:Seconds
        /// </summary>
        public int SucceedMessageExpiredAfter { get; set; } = 24 * 3600;
    }
}
