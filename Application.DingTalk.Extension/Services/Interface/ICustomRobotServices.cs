using System.Threading.Tasks;
using static DingTalk.Api.Request.OapiRobotSendRequest;

namespace Application.DingTalk.Extension.Services.Interface
{
    /// <summary>
    /// 自定义机器人服务
    /// </summary>
    public interface ICustomRobotServices
    {
        /// <summary>
        /// 发送文本消息
        /// </summary>
        /// <param name="message">文本消息内容</param>
        /// <param name="at">需要@的人</param>
        /// <returns></returns>
        Task SendText(string message, string @at = "");

        /// <summary>
        /// 发送文本消息
        /// </summary>
        /// <param name="message">文本消息内容</param>
        /// <param name="at">需要@的人</param>
        /// <returns></returns>
        Task SendText(string message, AtDomain? @at = null);
    }
}
