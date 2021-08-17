using Application.ChannelMessage.Extension.ChannelMessage;
using Application.ChannelMessage.Extension.ChannelMessage.Config;
using Application.ChannelMessage.Extension.ChannelMessage.Interface;
using Application.ChannelMessage.Extension.ChannelMessage.Options;
using Application.ChannelMessage.Extension.ChannelMessage.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Application.ChannelMessage.Extension
{
    public static class Startup
    {
        #region 添加ChannelMessage插件

        /// <summary>
        /// 添加ChannelMessage插件
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="optionsBuilder">配置信息</param>
        public static void AddChannelMessage(this IServiceCollection services, Action<ChannelMessageOptions> optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(ChannelMessageOptions));
            }

            services.Configure(optionsBuilder);

            ChannelMessageConfig.OptionsBuilder = optionsBuilder;

            services.AddSingleton<IChannelPublisher, ChannelPublisher>();
            services.AddHostedService<ChannelBackgroundService>();
        }

        #endregion
    }
}
