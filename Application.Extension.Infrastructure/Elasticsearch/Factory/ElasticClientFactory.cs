using Application.Extension.Infrastructure.Elasticsearch.Options;
using Microsoft.Extensions.Options;
using Nest;
using System;

namespace Application.Extension.Infrastructure.Elasticsearch.Factory
{
    public class ElasticClientFactory : IElasticClientFactory
    {
        private readonly ElasticClientOptions _options;

        public ElasticClientFactory(IOptions<ElasticClientOptions> optionsAccesser)
        {
            _options = optionsAccesser.Value;
        }

        /// <summary>
        /// 创建数据链接实例
        /// </summary>
        /// <returns></returns>
        public ElasticClient CreateClient()
        {
            if (string.IsNullOrWhiteSpace(_options.Password) && string.IsNullOrWhiteSpace(_options.Username))
            {
                var settings = new ConnectionSettings(new Uri(_options.Url));

                return new ElasticClient(settings);
            }
            else
            {
                var settings = new ConnectionSettings(new Uri(_options.Url)).BasicAuthentication(_options.Username, _options.Password);

                return new ElasticClient(settings);
            }
        }
    }
}
