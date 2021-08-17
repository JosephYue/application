using Application.DingTalk.Extension.Config.Options;
using System;

namespace Application.DingTalk.Extension
{
    /// <summary>
    /// 钉钉拓展容器
    /// </summary>
    internal class DingTalkContainer
    {
        /// <summary>
        /// 自定义机器人配置
        /// </summary>
        public static CustomRobotOptions CustomRobotOptions { get; set; } = new CustomRobotOptions();
    }
}
