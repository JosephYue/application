using Application.Extension.Infrastructure.InfluxDb.Interface;
using Application.Extension.Infrastructure.InfluxDb.Options;
using InfluxData.Net.Common.Enums;
using InfluxData.Net.InfluxDb;
using Microsoft.Extensions.Options;

namespace Application.Extension.Infrastructure.InfluxDb
{
    public class InfluxDbClientFactory : IInfluxDbClientFactory
    {
        private readonly InfluxDbClientOptions _options;

        public InfluxDbClientFactory(IOptions<InfluxDbClientOptions> optionsAccesser)
        {
            _options = optionsAccesser.Value;
        }

        /// <summary>
        /// 创建Client
        /// </summary>
        /// <returns></returns>
        public InfluxDbClientDecorator CreateClient()
        {
            var influxDbClient = new InfluxDbClient(_options.Url, _options.User, _options.Pwd, InfluxDbVersion.Latest);
            var clientDecorator = new InfluxDbClientDecorator(influxDbClient, _options);

            return clientDecorator;
        }
    }
}
