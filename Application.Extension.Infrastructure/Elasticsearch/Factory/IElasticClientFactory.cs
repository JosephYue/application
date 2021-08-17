using Nest;

namespace Application.Extension.Infrastructure.Elasticsearch.Factory
{
    public interface IElasticClientFactory
    {
        /// <summary>
        /// 创建数据链接实例
        /// </summary>
        /// <returns></returns>
        ElasticClient CreateClient();
    }
}
