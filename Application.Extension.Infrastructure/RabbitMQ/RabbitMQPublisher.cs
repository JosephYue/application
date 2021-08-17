using Application.Extension.Infrastructure.RabbitMQ.Interface;
using Application.Extension.Infrastructure.RabbitMQ.Options;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Application.Extension.Infrastructure.RabbitMQ
{
    public class RabbitMQPublisher : IRabbitMQPublisher
    {
        private readonly IConnection _connection;
        private readonly RabbitMQOptions _rabbitMQOptions;

        public RabbitMQPublisher(IOptions<RabbitMQOptions> rabbitMQOptions)
        {
            _rabbitMQOptions = rabbitMQOptions.Value;
            _connection = CreateConnection(rabbitMQOptions.Value);
        }

        #region 发送RabbitMQ消息

        /// <summary>
        /// 发送RabbitMQ消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="routeKey">路由key</param>
        /// <param name="contentObj">参数信息</param>
        /// <param name="exchangeType">交换机类型（默认：Direct，暂不支持：DotNetCore.CAP.Messages.Headers）</param>
        public void Publish<T>(string routeKey, T contentObj, string exchangeType = ExchangeType.Direct)
        {
            if (string.IsNullOrWhiteSpace(routeKey))
            {
                throw new ArgumentException(nameof(routeKey));
            }

            try
            {
                var channel = _connection.CreateModel();

                //type：有direct、fanout、topic三种
                //durable：true、false true：服务器重启会保留下来Exchange。
                //警告：仅设置此选项，不代表消息持久化。即不保证重启后消息还在。
                //原文：true if we are declaring a durable exchange(the exchange will survive a server restart)
                //autoDelete: true、false.true:当已经没有消费者时，服务器是否可以删除该Exchange。
                //原文1：true if the server should delete the exchange when it is no longer in use。
                channel.ExchangeDeclare(_rabbitMQOptions.ExchangeName, exchangeType, _rabbitMQOptions.Durable, _rabbitMQOptions.AutoDelete);

                //durable：true、false true：在服务器重启时，能够存活
                //exclusive ：是否为当前连接的专用队列，在连接断开后，会自动删除该队列，生产环境中应该很少用到吧。
                //autodelete：当没有任何消费者使用时，自动删除该队列。
                //this means that the queue will be deleted when there are no more processes consuming messages from it.

                //channel.QueueDeclare("", true, false, false, new Dictionary<string, object>
                //{
                //    {"x-message-ttl", _rabbitMQOptions.QueueMessageExpires}
                //});

                //prefetchSize：0 
                //prefetchCount：会告诉RabbitMQ不要同时给一个消费者推送多于N个消息，即一旦有N个消息还没有ack，则该consumer将block掉，直到有消息ack
                //global：true\false 是否将上面设置应用于channel，简单点说，就是上面限制是channel级别的还是consumer级别
                //备注：据说prefetchSize 和global这两项，rabbitmq没有实现，暂且不研究
                channel.BasicQos(0, 1, false);

                var body = Encoding.UTF8.GetBytes(Utils.JsonSerializer(contentObj ?? new object()));

                channel.BasicPublish(_rabbitMQOptions.ExchangeName, routeKey, body: body);

                channel.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 发送RabbitMQ消息（当前方法会直接声明队列）

        /// <summary>
        /// 发送RabbitMQ消息（当前方法会直接声明队列）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queueName">队列名称</param>
        /// <param name="routeKey">路由key</param>
        /// <param name="contentObj">参数信息</param>
        /// <param name="exchangeType">交换机类型（默认：Direct，暂不支持：DotNetCore.CAP.Messages.Headers）</param>
        public void Publish<T>(string queueName, string routeKey, T contentObj, string exchangeType = ExchangeType.Direct)
        {
            if (string.IsNullOrWhiteSpace(routeKey))
            {
                throw new ArgumentException(nameof(routeKey));
            }

            if (string.IsNullOrWhiteSpace(queueName))
            {
                throw new ArgumentException(nameof(queueName));
            }

            try
            {
                var channel = _connection.CreateModel();

                //type：有direct、fanout、topic三种
                //durable：true、false true：服务器重启会保留下来Exchange。
                //警告：仅设置此选项，不代表消息持久化。即不保证重启后消息还在。
                //原文：true if we are declaring a durable exchange(the exchange will survive a server restart)
                //autoDelete: true、false.true:当已经没有消费者时，服务器是否可以删除该Exchange。
                //原文1：true if the server should delete the exchange when it is no longer in use。
                channel.ExchangeDeclare(_rabbitMQOptions.ExchangeName, exchangeType, _rabbitMQOptions.Durable, _rabbitMQOptions.AutoDelete);

                //durable：true、false true：在服务器重启时，能够存活
                //exclusive ：是否为当前连接的专用队列，在连接断开后，会自动删除该队列，生产环境中应该很少用到吧。
                //autodelete：当没有任何消费者使用时，自动删除该队列。
                //this means that the queue will be deleted when there are no more processes consuming messages from it.
                channel.QueueDeclare(queueName, true, false, false, new Dictionary<string, object>
                {
                    {"x-message-ttl", _rabbitMQOptions.QueueMessageExpires}
                });

                //prefetchSize：0 
                //prefetchCount：会告诉RabbitMQ不要同时给一个消费者推送多于N个消息，即一旦有N个消息还没有ack，则该consumer将block掉，直到有消息ack
                //global：true\false 是否将上面设置应用于channel，简单点说，就是上面限制是channel级别的还是consumer级别
                //备注：据说prefetchSize 和global这两项，rabbitmq没有实现，暂且不研究
                channel.BasicQos(0, 1, false);

                var body = Encoding.UTF8.GetBytes(Utils.JsonSerializer(contentObj ?? new object()));

                //routingKey：路由键，#匹配0个或多个单词，*匹配一个单词，在topic exchange做消息转发用
                //mandatory：true：如果exchange根据自身类型和消息routeKey无法找到一个符合条件的queue，那么会调用basic.return方法将消息返还给生产者。false：出现上述情形broker会直接将消息扔掉
                //immediate：true：如果exchange在将消息route到queue(s)时发现对应的queue上没有消费者，那么这条消息不会放入队列中。当与消息routeKey关联的所有queue(一个或多个)都没有消费者时，该消息会通过basic.return方法返还给生产者。
                //BasicProperties ：需要注意的是BasicProperties.deliveryMode，0:不持久化 1：持久化 这里指的是消息的持久化，配合channel(durable = true),queue(durable)可以实现，即使服务器宕机，消息仍然保留
                //简单来说：mandatory标志告诉服务器至少将该消息route到一个队列中，否则将消息返还给生产者；immediate标志告诉服务器如果该消息关联的queue上有消费者，则马上将消息投递给它，如果所有queue都没有消费者，直接把消息返还给生产者，不用将消息入队列等待消费者了。
                channel.BasicPublish(_rabbitMQOptions.ExchangeName, routeKey, body: body);

                channel.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 创建rabbitmq链接

        /// <summary>
        /// 创建rabbitmq链接
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        static IConnection CreateConnection(RabbitMQOptions options)
        {
            var serviceName = Assembly.GetEntryAssembly()?.GetName()?.Name?.ToLower();

            var factory = new ConnectionFactory
            {
                UserName = options.UserName,
                Port = options.Port,
                Password = options.Password,
                VirtualHost = options.VirtualHost
            };

            if (options.HostName.Contains(","))
            {
                options.ConnectionFactoryOptions?.Invoke(factory);

                return factory.CreateConnection(options.HostName.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries), serviceName);
            }

            factory.HostName = options.HostName;
            options.ConnectionFactoryOptions?.Invoke(factory);
            return factory.CreateConnection(serviceName);
        }

        #endregion
    }
}
