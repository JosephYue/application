namespace Application.DingTalk.Extension.Config.Options
{
    /// <summary>
    /// 自定义机器人配置
    /// </summary>
    public class CustomRobotOptions
    {
        /// <summary>
        /// 自定义钉钉机器人的Webhook地址
        /// </summary>
        public string Webhook { get; set; } = string.Empty;

        /// <summary>
        /// 签名（机器人加签时，此字段必填）
        /// </summary>
        public string Signature { get; set; } = string.Empty;
    }
}
