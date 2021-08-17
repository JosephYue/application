
using RabbitMQ.Client;
using System;

namespace Application.Extension.Infrastructure.RabbitMQ.Options
{
    public class RabbitMQOptions
    {
        /// <summary>
        /// The host to connect to.
        /// If you want connect to the cluster, you can assign like “192.168.1.111,192.168.1.112”
        /// RabbitMQ服务地址
        /// </summary>
        public string HostName { get; set; } = string.Empty;

        /// <summary>
        /// Password to use when authenticating to the server.
        /// RabbitMQ服务密码
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Username to use when authenticating to the server.
        /// RabbitMQ服务用户名
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Virtual host to access during this connection.
        /// RabbitMQ服务虚拟机地址
        /// </summary>
        public string VirtualHost { get; set; } = string.Empty;

        /// <summary>
        /// Topic exchange name when declare a topic exchange.
        /// RabbitMQ服务交换机名称
        /// </summary>
        public string ExchangeName { get; set; } = string.Empty;

        /// <summary>
        /// The port to connect on.
        /// RabbitMQ服务端口
        /// </summary>
        public int Port { get; set; } = -1;

        /// <summary>
        /// Gets or sets queue message automatic deletion time (in milliseconds). Default 864000000 ms (10 days).
        /// RabbitMQ服务队列过期时间
        /// </summary>
        public int QueueMessageExpires { get; set; } = 864000000;

        /// <summary>
        /// 消息队列持久化  false 时 重启服务消息队列会消失  true 则不会
        /// </summary>
        public bool Durable { get; set; } = true;

        /// <summary>
        /// 当已经没有消费者时，服务器是否可以删除该交换机
        /// </summary>
        public bool AutoDelete { get; set; } = false;

        /// <summary>
        /// 交换机类型
        /// </summary>
        public string ExchangeType { get; set; } = "direct";

        /// <summary>
        /// RabbitMQ native connection factory options
        /// </summary>
        public Action<ConnectionFactory>? ConnectionFactoryOptions { get; set; }
    }
}
