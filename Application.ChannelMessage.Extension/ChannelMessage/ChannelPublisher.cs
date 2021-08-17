using Application.ChannelMessage.Extension.ChannelMessage.Config;
using Application.ChannelMessage.Extension.ChannelMessage.Enum.Status;
using Application.ChannelMessage.Extension.ChannelMessage.Extension;
using Application.ChannelMessage.Extension.ChannelMessage.Interface;
using Application.ChannelMessage.Extension.ChannelMessage.ValueModel;
using Application.ChannelMessage.Extension.Config;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ChannelMessage.Extension.ChannelMessage
{
    public class ChannelPublisher : IChannelPublisher
    {
        #region 写入队列（同步）

        /// <summary>
        /// 写入队列（同步）
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        /// <param name="subscriberName">订阅者名称</param>
        /// <param name="contentObj">参数内容</param>
        /// <returns></returns>
        public void Write<T>(string subscriberName, T contentObj) where T : class, new()
        {
            if (!CheckChannel(subscriberName)) return;

            var info = Utils.JsonSerializer(contentObj);

            var id = SnowflakeId.Default().NextId().ToString();

            try
            {
                ChannelMessageConfig.MessageChannel.Writer.TryWrite((subscriberName, info, id));

                DataStorage.InsertPublishMessage(new PublishMessageValueModel()
                {
                    Content = info,
                    SubscriberName = subscriberName,
                    Id = id,
                    Status = MessageStatusEnum.Succeeded,
                    ExecuteMessage = "成功"
                });
            }
            catch (Exception ex)
            {
                try
                {
                    DataStorage.InsertPublishMessage(new PublishMessageValueModel()
                    {
                        Content = info,
                        SubscriberName = subscriberName,
                        Id = id,
                        Status = MessageStatusEnum.Failed,
                        ExecuteMessage = ex.Message
                    });
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        #endregion

        #region 写入队列（同步）

        /// <summary>
        /// 写入队列（同步）
        /// </summary>
        /// <param name="subscriberName">订阅者名称</param>
        /// <returns></returns>
        public void Write(string subscriberName)
        {
            if (!CheckChannel(subscriberName)) return;

            var id = SnowflakeId.Default().NextId().ToString();

            try
            {
                ChannelMessageConfig.MessageChannel.Writer.TryWrite((subscriberName, "", id));

                DataStorage.InsertPublishMessage(new PublishMessageValueModel()
                {
                    Content = "",
                    SubscriberName = subscriberName,
                    Id = id,
                    Status = MessageStatusEnum.Succeeded,
                    ExecuteMessage = "成功"
                });
            }
            catch (Exception ex)
            {
                try
                {
                    DataStorage.InsertPublishMessage(new PublishMessageValueModel()
                    {
                        Content = "",
                        SubscriberName = subscriberName,
                        Id = id,
                        Status = MessageStatusEnum.Failed,
                        ExecuteMessage = ex.Message
                    });
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }

        #endregion

        #region 写入队列（异步）

        /// <summary>
        /// 写入队列（异步）
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        /// <param name="subscriberName">订阅者名称</param>
        /// <param name="contentObj">参数内容</param>
        /// <returns></returns>
        public async Task WriteAsync<T>(string subscriberName, T contentObj) where T : class, new()
        {
            if (!CheckChannel(subscriberName)) return;

            var info = Utils.JsonSerializer(contentObj);

            var id = SnowflakeId.Default().NextId().ToString();

            try
            {
                await ChannelMessageConfig.MessageChannel.Writer.WriteAsync((subscriberName, info, id));

                DataStorage.InsertPublishMessage(new PublishMessageValueModel()
                {
                    Content = info,
                    SubscriberName = subscriberName,
                    Id = id,
                    Status = MessageStatusEnum.Succeeded,
                    ExecuteMessage = "成功"
                });
            }
            catch (Exception ex)
            {
                try
                {
                    DataStorage.InsertPublishMessage(new PublishMessageValueModel()
                    {
                        Content = info,
                        SubscriberName = subscriberName,
                        Id = id,
                        Status = MessageStatusEnum.Failed,
                        ExecuteMessage = ex.Message
                    });
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }

        #endregion

        #region 写入队列（异步）

        /// <summary>
        /// 写入队列（异步）
        /// </summary>
        /// <param name="subscriberName">订阅者名称</param>
        /// <returns></returns>
        public async Task WriteAsync(string subscriberName)
        {
            if (!CheckChannel(subscriberName)) return;

            var id = SnowflakeId.Default().NextId().ToString();

            try
            {
                await ChannelMessageConfig.MessageChannel.Writer.WriteAsync((subscriberName, "", id));

                DataStorage.InsertPublishMessage(new PublishMessageValueModel()
                {
                    Content = "",
                    SubscriberName = subscriberName,
                    Id = id,
                    Status = MessageStatusEnum.Succeeded,
                    ExecuteMessage = "成功"
                });
            }
            catch (Exception ex)
            {
                try
                {
                    DataStorage.InsertPublishMessage(new PublishMessageValueModel()
                    {
                        Content = "",
                        SubscriberName = subscriberName,
                        Id = id,
                        Status = MessageStatusEnum.Failed,
                        ExecuteMessage = ex.Message
                    });
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        #endregion

        #region Private

        /// <summary>
        /// 检查是否允许写入消息
        /// </summary>
        /// <param name="subscriberName"></param>
        /// <returns></returns>
        bool CheckChannel(string subscriberName)
        {
            return ChannelMessageConfig.Actions.Any(x => x.Item1 == subscriberName);
        }

        /// <summary>
        /// 数据库查询
        /// </summary>
        DataStorage DataStorage
        {
            get
            {
                return new DataStorage();
            }
        }

        #endregion
    }
}
