using System.Threading.Tasks;

namespace Application.ChannelMessage.Extension.ChannelMessage.Interface
{
    public interface IChannelPublisher
    {
        /// <summary>
        /// 写入队列（异步）
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        /// <param name="subscriberName">订阅者名称</param>
        /// <param name="contentObj">参数内容</param>
        /// <returns></returns>
        Task WriteAsync<T>(string subscriberName, T contentObj) where T : class, new();

        /// <summary>
        /// 写入队列（异步）
        /// </summary>
        /// <param name="subscriberName">订阅者名称</param>
        /// <returns></returns>
        Task WriteAsync(string subscriberName);

        /// <summary>
        /// 写入队列（同步）
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        /// <param name="subscriberName">订阅者名称</param>
        /// <param name="contentObj">参数内容</param>
        /// <returns></returns>
        void Write<T>(string subscriberName, T contentObj) where T : class, new();

        /// <summary>
        /// 写入队列（同步）
        /// </summary>
        /// <param name="subscriberName">订阅者名称</param>
        /// <returns></returns>
        void Write(string subscriberName);
    }
}
