using RabbitMQ.Client;

namespace Application.Extension.Infrastructure.RabbitMQ.Interface
{
    public interface IRabbitMQPublisher
    {
        /// <summary>
        /// 发送RabbitMQ消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="routeKey">路由key</param>
        /// <param name="contentObj">参数信息</param>
        /// <param name="exchangeType">交换机类型（默认：Direct，暂不支持：Headers）</param>
        void Publish<T>(string routeKey, T contentObj, string exchangeType = ExchangeType.Direct);

        /// <summary>
        /// 发送RabbitMQ消息（当前方法会直接声明队列）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queueName">队列名称</param>
        /// <param name="routeKey">路由key</param>
        /// <param name="contentObj">参数信息</param>
        /// <param name="exchangeType">交换机类型（默认：Direct，暂不支持：Headers）</param>
        void Publish<T>(string queueName, string routeKey, T contentObj, string exchangeType = ExchangeType.Direct);
    }
}
