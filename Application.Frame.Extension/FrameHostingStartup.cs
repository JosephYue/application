using Application.Frame.Extension.Config.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Application.Frame.Extension
{
    internal class FrameHostingStartup : IHostingStartup
    {
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="builder">WebHost主机</param>
        public void Configure(IWebHostBuilder builder)
        {
            Configure(builder, null);
        }

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="builder">WebHost主机</param>
        /// <param name="originalStartup">Startup的Type</param>
        public void Configure(IWebHostBuilder builder, Type? originalStartup)
        {
            builder.UseStartup<Startup>();
            builder.UseSetting(WebHostDefaults.ApplicationKey, Assembly.GetEntryAssembly()?.GetName().Name);
            if (originalStartup is null) return;

            builder.ConfigureServices((webBuilder, services) =>
            {
                LoadOriginalStartup(webBuilder, services, originalStartup);
            });
        }

        /// <summary>
        /// 加载携带的Startup文件
        /// </summary>
        /// <param name="webBuilder"></param>
        /// <param name="services"></param>
        /// <param name="originalStartup"></param>
        void LoadOriginalStartup(WebHostBuilderContext webBuilder, IServiceCollection services, Type originalStartup)
        {
            var consutructor = originalStartup.GetConstructors().FirstOrDefault()!;//获取当前Type的构造函数

            object assemblyStartupInstance;

            if (consutructor.GetParameters().Length == 0)
            {
                assemblyStartupInstance = Activator.CreateInstance(originalStartup)!;//反射创建实体对象
            }
            else
            {
                var parameters = consutructor.GetParameters().Select(p =>
                {
                    if (p.ParameterType == typeof(IConfiguration))
                        return webBuilder.Configuration;
                    if (p.ParameterType == typeof(IWebHostEnvironment))
                        return (object)webBuilder.HostingEnvironment;
                    return null;
                }).ToArray();

                assemblyStartupInstance = Activator.CreateInstance(originalStartup, parameters)!;//反射创建实体对象（带参数）
            }

            if (assemblyStartupInstance is null) return;

            var configureServicesMethodInfo = originalStartup.GetMethod(nameof(IStartup.ConfigureServices));//取出Startup中的ConfigureServices方法

            var configureMethodInfo = originalStartup.GetMethod(nameof(IStartup.Configure));//取出Startup中的Configure方法

            configureServicesMethodInfo?.Invoke(assemblyStartupInstance, new object[] { services });//执行Startup中的ConfigureServices方法

            services.AddTransient<IStartupFilter>((serverProvider) => new ActionMiddlewareStartupFilter(CreateMiddlewareDelegate(), true));

            Action<IApplicationBuilder> CreateMiddlewareDelegate()//创建委托执行Startup中的Configure方法
            {
                return (applicationBuilder) =>
                {
                    var parameters = configureMethodInfo?.GetParameters().Select(p =>
                    {
                        var param = applicationBuilder.ApplicationServices.GetService(p.ParameterType);
                        if (param == null && (p.ParameterType == typeof(ApplicationBuilder)
                            || p.ParameterType == typeof(IApplicationBuilder)))
                        {
                            param = applicationBuilder;
                        }
                        return param;
                    }).ToArray();

                    configureMethodInfo?.Invoke(assemblyStartupInstance, parameters);
                };
            }
        }
    }
}
