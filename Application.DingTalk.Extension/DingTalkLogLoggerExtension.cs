using Application.DingTalk.Extension.Model;
using DingTalk.Api;
using DingTalk.Api.Request;
using Microsoft.Extensions.Logging;
using System;

namespace Application.DingTalk.Extension
{
    /// <summary>
    /// 钉钉日志拓展
    /// </summary>
    public static class DingTalkLogLoggerExtension
    {
        #region Information

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="message">消息信息</param>
        /// <param name="args">包含要格式化的零个或多个对象的对象数组。</param>
        public static void LogInformationForDingTalk(this ILogger logger, string message, params object[] args)
        {
            SendText(message);

            logger.LogInformation(message, args);
        }

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="eventId">标识id</param>
        /// <param name="message">消息内容</param>
        /// <param name="args"></param>
        public static void LogInformationForDingTalk(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            SendText(message);

            logger.LogInformation(message, eventId, args);
        }

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="exception">错误信息</param>
        /// <param name="message">消息内容</param>
        /// <param name="args">包含要格式化的零个或多个对象的对象数组</param>
        public static void LogInformationForDingTalk(this ILogger logger, Exception exception, string message, params object[] args)
        {
            SendText(message);

            logger.LogInformation(message, exception, args);
        }

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="eventId">标识id</param>
        /// <param name="exception">错误信息</param>
        /// <param name="message">消息内容</param>
        /// <param name="args">包含要格式化的零个或多个对象的对象数组</param>
        public static void LogInformationForDingTalk(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            SendText(message);

            logger.LogInformation(message, eventId, exception, args);
        }

        #endregion

        #region Error

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="message">消息信息</param>
        /// <param name="args">包含要格式化的零个或多个对象的对象数组。</param>
        public static void LogErrorForDingTalk(this ILogger logger, string message, params object[] args)
        {
            SendText(message);

            logger.LogError(message, args);
        }

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="eventId">标识id</param>
        /// <param name="message">消息内容</param>
        /// <param name="args"></param>
        public static void LogErrorForDingTalk(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            SendText(message);

            logger.LogError(message, eventId, args);
        }

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="exception">错误信息</param>
        /// <param name="message">消息内容</param>
        /// <param name="args">包含要格式化的零个或多个对象的对象数组</param>
        public static void LogErrorForDingTalk(this ILogger logger, Exception exception, string message, params object[] args)
        {
            SendText(message);

            logger.LogError(message, exception, args);
        }

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="eventId">标识id</param>
        /// <param name="exception">错误信息</param>
        /// <param name="message">消息内容</param>
        /// <param name="args">包含要格式化的零个或多个对象的对象数组</param>
        public static void LogErrorForDingTalk(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            SendText(message);

            logger.LogError(message, eventId, exception, args);
        }

        #endregion

        #region Debug

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="message">消息信息</param>
        /// <param name="args">包含要格式化的零个或多个对象的对象数组。</param>
        public static void LogDebugForDingTalk(this ILogger logger, string message, params object[] args)
        {
            SendText(message);

            logger.LogDebug(message, args);
        }

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="eventId">标识id</param>
        /// <param name="message">消息内容</param>
        /// <param name="args"></param>
        public static void LogDebugForDingTalk(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            SendText(message);

            logger.LogDebug(message, eventId, args);
        }

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="exception">错误信息</param>
        /// <param name="message">消息内容</param>
        /// <param name="args">包含要格式化的零个或多个对象的对象数组</param>
        public static void LogDebugForDingTalk(this ILogger logger, Exception exception, string message, params object[] args)
        {
            SendText(message);

            logger.LogDebug(message, exception, args);
        }

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="eventId">标识id</param>
        /// <param name="exception">错误信息</param>
        /// <param name="message">消息内容</param>
        /// <param name="args">包含要格式化的零个或多个对象的对象数组</param>
        public static void LogDebugForDingTalk(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            SendText(message);

            logger.LogDebug(message, eventId, exception, args);
        }

        #endregion

        #region Critical

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="message">消息信息</param>
        /// <param name="args">包含要格式化的零个或多个对象的对象数组。</param>
        public static void LogCriticalForDingTalk(this ILogger logger, string message, params object[] args)
        {
            SendText(message);

            logger.LogCritical(message, args);
        }

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="eventId">标识id</param>
        /// <param name="message">消息内容</param>
        /// <param name="args"></param>
        public static void LogCriticalForDingTalk(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            SendText(message);

            logger.LogCritical(message, eventId, args);
        }

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="exception">错误信息</param>
        /// <param name="message">消息内容</param>
        /// <param name="args">包含要格式化的零个或多个对象的对象数组</param>
        public static void LogCriticalForDingTalk(this ILogger logger, Exception exception, string message, params object[] args)
        {
            SendText(message);

            logger.LogCritical(message, exception, args);
        }

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="eventId">标识id</param>
        /// <param name="exception">错误信息</param>
        /// <param name="message">消息内容</param>
        /// <param name="args">包含要格式化的零个或多个对象的对象数组</param>
        public static void LogCriticalForDingTalk(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            SendText(message);

            logger.LogCritical(message, eventId, exception, args);
        }

        #endregion

        #region Trace

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="message">消息信息</param>
        /// <param name="args">包含要格式化的零个或多个对象的对象数组。</param>
        public static void LogTraceForDingTalk(this ILogger logger, string message, params object[] args)
        {
            SendText(message);

            logger.LogTrace(message, args);
        }

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="eventId">标识id</param>
        /// <param name="message">消息内容</param>
        /// <param name="args"></param>
        public static void LogTraceForDingTalk(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            SendText(message);

            logger.LogTrace(message, eventId, args);
        }

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="exception">错误信息</param>
        /// <param name="message">消息内容</param>
        /// <param name="args">包含要格式化的零个或多个对象的对象数组</param>
        public static void LogTraceForDingTalk(this ILogger logger, Exception exception, string message, params object[] args)
        {
            SendText(message);

            logger.LogTrace(message, exception, args);
        }

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="eventId">标识id</param>
        /// <param name="exception">错误信息</param>
        /// <param name="message">消息内容</param>
        /// <param name="args">包含要格式化的零个或多个对象的对象数组</param>
        public static void LogTraceForDingTalk(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            SendText(message);

            logger.LogTrace(message, eventId, exception, args);
        }

        #endregion

        #region Warning

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="message">消息信息</param>
        /// <param name="args">包含要格式化的零个或多个对象的对象数组。</param>
        public static void LogWarningForDingTalk(this ILogger logger, string message, params object[] args)
        {
            SendText(message);

            logger.LogWarning(message, args);
        }

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="eventId">标识id</param>
        /// <param name="message">消息内容</param>
        /// <param name="args"></param>
        public static void LogWarningForDingTalk(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            SendText(message);

            logger.LogWarning(message, eventId, args);
        }

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="exception">错误信息</param>
        /// <param name="message">消息内容</param>
        /// <param name="args">包含要格式化的零个或多个对象的对象数组</param>
        public static void LogWarningForDingTalk(this ILogger logger, Exception exception, string message, params object[] args)
        {
            SendText(message);

            logger.LogWarning(message, exception, args);
        }

        /// <summary>
        /// 向钉钉机器人发送消息并记录日志
        /// </summary>
        /// <param name="logger">日志接口</param>
        /// <param name="eventId">标识id</param>
        /// <param name="exception">错误信息</param>
        /// <param name="message">消息内容</param>
        /// <param name="args">包含要格式化的零个或多个对象的对象数组</param>
        public static void LogWarningForDingTalk(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            SendText(message);

            logger.LogWarning(message, eventId, exception, args);
        }

        #endregion

        #region Private

        /// <summary>
        /// 钉钉Client
        /// </summary>
        static IDingTalkClient DingTalkClient
        {
            get
            {
                if (DingTalkContainer.CustomRobotOptions == null)
                {
                    throw new ArgumentNullException(nameof(DingTalkContainer.CustomRobotOptions));
                }

                return new DefaultDingTalkClient(Utils.GetCustomRobotWebhook());
            }
        }

        /// <summary>
        /// 向钉钉机器人发送文本内容
        /// </summary>
        /// <param name="text">文本内容</param>
        static void SendText(string text)
        {
            var request = new OapiRobotSendRequest();

            request.SetHttpMethod("POST");
            request.Text = Utils.JsonSerializer(new TextContent() { Content = text });
            request.Msgtype = "text";

            var sendResult = DingTalkClient.Execute(request);
        }

        #endregion
    }
}
