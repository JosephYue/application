namespace Application.Extension.Infrastructure.Elasticsearch.Options
{
    public class ElasticClientOptions
    {
        /// <summary>
        /// Elasticsearch服务地址
        /// </summary>
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
