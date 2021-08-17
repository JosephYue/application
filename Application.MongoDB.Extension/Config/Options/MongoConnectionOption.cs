using MongoDB.Driver;

namespace Application.Mongo.Extension.Config.Options
{
    /// <summary>
    /// 
    /// </summary>
    public class MongoConnectionOption
    {
        /// <summary>
        /// 链接数据库的字符串
        /// </summary>
        public string ConnectionString { get; set; } = string.Empty;

        /// <summary>
        /// 数据库
        /// </summary>
        public string Database { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class MongoClientSettingsOption
    {
        /// <summary>
        /// MongoDb的配置
        /// </summary>
        public MongoClientSettings? MongoClientSettings { get; set; }

        /// <summary>
        /// 数据库
        /// </summary>
        public string Database { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class MongoUrlOption
    {
        /// <summary>
        /// 包含设置的URL
        /// </summary>
        public MongoUrl? MongoUrl { get; set; }

        /// <summary>
        /// 数据库
        /// </summary>
        public string Database { get; set; } = string.Empty;
    }
}
