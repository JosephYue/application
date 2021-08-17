using System.ComponentModel;

namespace Application.ChannelMessage.Extension.ChannelMessage.Enum.Status
{
    public enum MessageStatusEnum
    {
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")] Failed = -1,

        /// <summary>
        /// 预定的
        /// </summary>
        [Description("预定的")] Scheduled,

        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")] Succeeded
    }
}
