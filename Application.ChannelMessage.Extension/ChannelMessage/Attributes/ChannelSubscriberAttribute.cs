using System;

namespace Application.ChannelMessage.Extension.ChannelMessage.Attributes
{
    /// <summary>
    /// 订阅Attribute 只有带了此标识才会被订阅方法
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ChannelSubscriberAttribute : Attribute
    {
        public ChannelSubscriberAttribute(string subscriberName, string groupName)
        {
            if (string.IsNullOrWhiteSpace(subscriberName))
            {
                throw new ArgumentException(nameof(subscriberName));
            }

            if (string.IsNullOrWhiteSpace(subscriberName))
            {
                throw new ArgumentException(nameof(groupName));
            }

            SubscriberName = subscriberName;
            GroupName = groupName;
        }

        /// <summary>
        /// 订阅者名称
        /// </summary>
        public string SubscriberName { get; private set; }

        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName { get; private set; }
    }
}
