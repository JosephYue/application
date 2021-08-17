using Application.ChannelMessage.Extension.ChannelMessage.Attributes;
using Application.ChannelMessage.Extension.ChannelMessage.Config;
using Application.ChannelMessage.Extension.ChannelMessage.Enum.Status;
using Application.ChannelMessage.Extension.ChannelMessage.Extension;
using Application.ChannelMessage.Extension.ChannelMessage.Options;
using Application.ChannelMessage.Extension.ChannelMessage.ValueModel;
using Application.ChannelMessage.Extension.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ChannelMessage.Extension.ChannelMessage.Services
{
    public class ChannelBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ChannelMessageOptions _options;

        public ChannelBackgroundService(
            IServiceProvider serviceProvider,
            IOptions<ChannelMessageOptions> options)
        {
            _serviceProvider = serviceProvider;
            _options = options?.Value;
        }

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="stoppingToken">取消token</param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            DataStorage.InitializationTable();

            RegisterSubscriber();

            RetryReceiveMessageProcessing();

            RetryPublishMessageProcessing();

            DelExpiresMessage();

            await Receive(stoppingToken);
        }

        /// <summary>
        /// 注册订阅者信息
        /// </summary>
        void RegisterSubscriber()
        {
            var assemblie = Assembly.GetEntryAssembly();

            foreach (var type in assemblie.GetTypes())
            {
                var methods = type.GetMethods().Where(x => (x.IsPublic || x.IsPrivate) && x.CustomAttributes.Any(x => x.AttributeType == typeof(ChannelSubscriberAttribute))).ToList();

                if (methods.Count() > 0)
                {
                    foreach (var method in methods)
                    {
                        var serviceTypes = new List<Type>();

                        var constructors = type.GetConstructors();

                        foreach (var constructor in constructors)
                        {
                            var parameters = constructor.GetParameters();

                            foreach (var item in parameters)
                            {
                                serviceTypes.Add(item.ParameterType);
                            }
                        }

                        var channelSubscriberAttribute = method.GetCustomAttribute<ChannelSubscriberAttribute>();

                        if (channelSubscriberAttribute != null)
                        {
                            ChannelMessageConfig.Actions.Add((channelSubscriberAttribute.SubscriberName, channelSubscriberAttribute.GroupName, method.GetParameters().FirstOrDefault()?.ParameterType, method, serviceTypes));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="param"></param>
        /// <param name="content"></param>
        /// <param name="publishMessageId"></param>
        void Processing((string name, string groupName, Type type, MethodInfo method, List<Type> serviceTypes) param, string content, string publishMessageId)
        {
            if (!string.IsNullOrWhiteSpace(param.name))
            {
                var msgContent = Utils.JsonSerializer(new ReceiveContentValueModel()
                {
                    PublishMsgId = publishMessageId,
                    Content = content
                });

                var messageId = SnowflakeId.Default().NextId().ToString();

                InvokeAction(content, param.type, param.method, param.serviceTypes, SuccessAction, (msg) => ErrorAction(msg));

                void SuccessAction()
                {
                    DataStorage.InsertReceiveMessage(new ReceiveMessageValueModel()
                    {
                        Content = msgContent,
                        Group = param.groupName,
                        SubscriberName = param.name,
                        Id = messageId,
                        ExecuteMessage = "成功",
                        Status = MessageStatusEnum.Succeeded
                    });
                }

                void ErrorAction(string errorMsg)
                {
                    DataStorage.InsertReceiveMessage(new ReceiveMessageValueModel()
                    {
                        Content = msgContent,
                        Group = param.groupName,
                        SubscriberName = param.name,
                        Id = messageId,
                        ExecuteMessage = errorMsg,
                        Status = MessageStatusEnum.Failed
                    });
                }
            }
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        async Task Receive(CancellationToken stoppingToken)
        {
            await foreach ((string subscriberName, string conetnt, string messageId) in ChannelMessageConfig.MessageChannel.Reader.ReadAllAsync(stoppingToken))
            {
                var actions = ChannelMessageConfig.Actions.Where(((string name, string groupName, Type type, MethodInfo methodInfo, List<Type> serviceTypes) x) => x.name.Equals(subscriberName)).ToList();

                if (actions.Count > 0)
                {
                    if (actions.Count == 1)
                    {
                        var (name, groupName, type, methodInfo, obj) = actions.FirstOrDefault();

                        Processing(actions.FirstOrDefault(), conetnt, messageId);
                    }
                    else
                    {
                        Task.WaitAll(actions.Select(((string name, string groupName, Type type, MethodInfo methodInfo, List<Type> serviceTypes) x) => Task.Run(() =>
                        {
                            Processing(x, conetnt, messageId);
                        })).ToArray());
                    }
                }
            }
        }

        /// <summary>
        /// 重试失败的接收消息
        /// </summary>
        void RetryReceiveMessageProcessing()
        {
            var timer = new Timer((x) => RetryTask(), null, _options.FailedRetryInterval * 1000, _options.FailedRetryInterval * 1000);

            void RetryTask()
            {
                var result = DataStorage.GetReceiveRetryMessages();

                if (result.Count > 0)
                {
                    foreach (var messageInfo in result)
                    {
                        var (name, groupName, type, method, serviceTypes) = ChannelMessageConfig.Actions.Where(((string name, string groupName, Type type, MethodInfo method, List<Type> serviceTypes) x) => x.groupName == messageInfo.Group && x.name == messageInfo.SubscriberName).FirstOrDefault();

                        var receiveContent = Utils.JsonDeserialize<ReceiveContentValueModel>(messageInfo.Content);

                        InvokeAction(receiveContent.Content, type, method, serviceTypes, SuccessAction, (msg) => ErrorAction(msg));

                        void SuccessAction()
                        {
                            DataStorage.ChangeReceiveState(messageInfo.Id, MessageStatusEnum.Succeeded, messageInfo.Retries + 1, "成功");
                        }

                        void ErrorAction(string errorMsg)
                        {
                            DataStorage.ChangeReceiveState(messageInfo.Id, MessageStatusEnum.Failed, messageInfo.Retries + 1, errorMsg);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 重试失败的发布消息
        /// </summary>
        void RetryPublishMessageProcessing()
        {
            var timer = new Timer((x) => RetryTask(), null, _options.FailedRetryInterval * 1000, _options.FailedRetryInterval * 1000);

            void RetryTask()
            {
                var result = DataStorage.GetPublishRetryMessages();

                if (result.Count > 0)
                {
                    foreach (var messageInfo in result)
                    {
                        var (name, groupName, type, method, serviceTypes) = ChannelMessageConfig.Actions.Where(((string name, string groupName, Type type, MethodInfo method, List<Type> serviceTypes) x) => x.groupName == messageInfo.Group && x.name == messageInfo.SubscriberName).FirstOrDefault();

                        try
                        {
                            ChannelMessageConfig.MessageChannel.Writer.TryWrite((messageInfo.SubscriberName, messageInfo.Content, messageInfo.Id));

                            SuccessAction();
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                ErrorAction(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                            }
                            catch (Exception e)
                            {

                            }
                        }

                        void SuccessAction()
                        {
                            DataStorage.ChangeReceiveState(messageInfo.Id, MessageStatusEnum.Succeeded, messageInfo.Retries + 1, "成功");
                        }

                        void ErrorAction(string errorMsg)
                        {
                            DataStorage.ChangeReceiveState(messageInfo.Id, MessageStatusEnum.Failed, messageInfo.Retries + 1, errorMsg);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 删除过期消息
        /// </summary>
        void DelExpiresMessage()
        {
            var timer = new Timer((x) => Del(), null, _options.FailedRetryInterval * 1000, _options.FailedRetryInterval * 1000);

            void Del()
            {
                try
                {
                    DataStorage.DelPublishExpireMessage();
                    DataStorage.DelReceiveExpireMessage();
                }
                catch (Exception e)
                {

                }
            }
        }

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="content"></param>
        /// <param name="type"></param>
        /// <param name="method"></param>
        /// <param name="serviceTypes"></param>
        /// <param name="successAction"></param>
        /// <param name="errorAction"></param>
        void InvokeAction(string content, Type type, MethodInfo method, List<Type> serviceTypes, Action successAction = null, Action<string> errorAction = null)
        {
            var services = new List<object>();

            var scope = _serviceProvider.CreateScope();

            foreach (var serviceType in serviceTypes)
            {
                services.Add(scope.ServiceProvider.GetService(serviceType));
            }

            object demethodInstance = Activator.CreateInstance(method.DeclaringType, services.ToArray());

            try
            {
                if (!string.IsNullOrWhiteSpace(content))
                {
                    method.Invoke(demethodInstance, new object[] { Utils.JsonDeserialize(content, type) });
                }
                else
                {
                    method.Invoke(demethodInstance, null);
                }

                successAction?.Invoke();
            }
            catch (Exception ex)
            {
                try
                {
                    errorAction?.Invoke(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                }
                catch (Exception e)
                {

                }
            }

            scope.Dispose();
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
    }
}
