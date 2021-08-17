using Application.ChannelMessage.Extension.ChannelMessage.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Channels;

namespace Application.ChannelMessage.Extension.ChannelMessage.Config
{
    internal class ChannelMessageConfig
    {
        /// <summary>
        /// 控制器方法信息集合
        /// </summary>
        internal static readonly List<(string, string, Type, MethodInfo, List<Type>)> Actions = new List<(string, string, Type, MethodInfo, List<Type>)>();

        /// <summary>
        /// Channel队列信息
        /// </summary>
        internal static Channel<(string, string, string)> MessageChannel = Channel.CreateUnbounded<(string, string, string)>(new UnboundedChannelOptions { SingleReader = false, SingleWriter = false, AllowSynchronousContinuations = false });

        /// <summary>
        /// ChannelMessage配置信息
        /// </summary>
        internal static ChannelMessageOptions ChannelMessageOption
        {
            get
            {
                var option = new ChannelMessageOptions();

                if (OptionsBuilder == null)
                {
                    return option;
                }

                OptionsBuilder.Invoke(option);

                return option;
            }
        }

        /// <summary>
        /// ChannelMessage配置信息委托
        /// </summary>
        internal static Action<ChannelMessageOptions> OptionsBuilder { get; set; }
    }
}
