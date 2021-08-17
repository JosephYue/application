using Application.DingTalk.Extension.Model;
using Application.DingTalk.Extension.Services.Interface;
using DingTalk.Api;
using DingTalk.Api.Request;
using System.Threading.Tasks;
using static DingTalk.Api.Request.OapiRobotSendRequest;

namespace Application.DingTalk.Extension.Services
{
    /// <summary>
    /// 自定义机器人服务实现
    /// </summary>
    public class CustomRobotServices : ICustomRobotServices
    {
        private readonly IDingTalkClient _dingTalkClient;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomRobotServices()
        {
            _dingTalkClient = new DefaultDingTalkClient(Utils.GetCustomRobotWebhook());
        }

        /// <summary>
        /// 发送文本消息
        /// </summary>
        /// <param name="message">文本消息内容</param>
        /// <param name="at">需要@的人 json 类型  参考文档</param>
        /// <returns></returns>
        public async Task SendText(string message, string @at = "")
        {
            await Task.Run(() =>
            {
                var request = new OapiRobotSendRequest();

                request.SetHttpMethod("POST");
                request.Text = Utils.JsonSerializer(new TextContent() { Content = message });
                request.Msgtype = "text";
                request.At = at;

                _dingTalkClient.Execute(request);
            });
        }

        /// <summary>
        /// 发送文本消息
        /// </summary>
        /// <param name="message">文本消息内容</param>
        /// <param name="at">需要@的人</param>
        /// <returns></returns>
        public async Task SendText(string message, AtDomain? @at = null)
        {
            await Task.Run(() =>
            {
                var request = new OapiRobotSendRequest();

                request.SetHttpMethod("POST");
                request.Text = Utils.JsonSerializer(new TextContent() { Content = message });
                request.Msgtype = "text";

                if (@at != null)
                {
                    request.At_ = at;
                }

                _dingTalkClient.Execute(request);
            });
        }
    }
}
