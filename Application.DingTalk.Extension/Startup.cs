using Application.DingTalk.Extension.Config.Options;
using Application.DingTalk.Extension.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Application.DingTalk.Extension
{
    /// <summary>
    /// 钉钉拓展接口
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// 添加自定义机器人服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="optionsBuilder">配置信息</param>
        public static void AddCustomRobotServices(this IServiceCollection services, Action<CustomRobotOptions> optionsBuilder)
        {
            if (optionsBuilder == null)
            {
                throw new ArgumentNullException(nameof(CustomRobotOptions));
            }

            optionsBuilder.Invoke(DingTalkContainer.CustomRobotOptions ??= new CustomRobotOptions());

            services.AddSingleton(typeof(CustomRobotServices), typeof(CustomRobotServices));
        }
    }
}
