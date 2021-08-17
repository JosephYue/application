using Microsoft.AspNetCore.Hosting;
using System;

namespace Application.Frame.Extension.Extensions
{
    /// <summary>
    /// 此框架的WebHostBuilder拓展
    /// </summary>
    public static class FrameWebHostBuilderExtensions
    {
        /// <summary>
        /// 使用框架的Startup用来代替项目中的Startup
        /// </summary>
        /// <param name="hostBuilder">web主机</param>
        /// <returns></returns>
        public static IWebHostBuilder UseFrameStartup(this IWebHostBuilder hostBuilder)
        {
            new FrameHostingStartup().Configure(hostBuilder);
            return hostBuilder;
        }

        /// <summary>
        /// 使用框架的Startup用来代替项目中的Startup 
        /// 也可执行项目中的Startup
        /// </summary>
        /// <param name="hostBuilder">web主机</param>
        /// <param name="startupType">在项目中的Startup类型</param>
        /// <returns></returns>
        public static IWebHostBuilder UseFrameStartup(this IWebHostBuilder hostBuilder, Type startupType)
        {
            new FrameHostingStartup().Configure(hostBuilder, startupType);
            return hostBuilder;
        }

        /// <summary>
        /// 使用框架的Startup用来代替项目中的Startup 
        /// 也可执行项目中的Startup
        /// </summary>
        /// <typeparam name="TStartup">泛型 类型为 Startup</typeparam>
        /// <param name="hostBuilder">web主机</param>
        /// <returns></returns>
        public static IWebHostBuilder UseFrameStartup<TStartup>(this IWebHostBuilder hostBuilder) where TStartup : class
        {
            new FrameHostingStartup().Configure(hostBuilder, typeof(TStartup));
            return hostBuilder;
        }
    }
}
