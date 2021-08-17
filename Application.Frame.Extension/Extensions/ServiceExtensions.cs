using Application.Frame.Extension.Config.Attributes;
using Application.Frame.Extension.Config.Filters;
using Application.Frame.Extension.Config.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Application.Frame.Extension.Extensions
{
    /// <summary>
    /// 服务拓展
    /// </summary>
    public static partial class ServiceExtensions
    {
        /// <summary>
        /// 添加需要自动注册的服务集合
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="Configuration">属性配置信息</param>
        internal static void AddFrameServices(this IServiceCollection services, IConfiguration Configuration)
        {
            FrameAssemblyExtensions.InitializeAssembly();

            foreach (var (serviceType, customAttribute) in FrameContainer.ServiceAttributes ?? new List<(Type?, ServiceAttribute?)>())
            {
                ServiceDescriptor serviceDescriptor;

                if (customAttribute is null || serviceType is null)
                {
                    continue;
                }

                if (customAttribute.InterfaceType is null)
                {
                    serviceDescriptor = new ServiceDescriptor(serviceType, serviceType, customAttribute.Lifetime);
                }
                else
                {
                    serviceDescriptor = new ServiceDescriptor(customAttribute.InterfaceType, serviceType, customAttribute.Lifetime);
                }

                if (!services.Any(service => service.ServiceType == serviceDescriptor.ServiceType && service.ImplementationType == serviceDescriptor.ImplementationType && service.ImplementationFactory == serviceDescriptor.ImplementationFactory && service.ImplementationInstance == serviceDescriptor.ImplementationInstance))
                {
                    services.Add(serviceDescriptor);
                }
            };

            foreach (var (optionType, optionAttribute) in FrameContainer.OptionAttributes ?? new List<(Type?, OptionAttribute?)>())
            {
                if (optionType is null || optionAttribute is null)
                {
                    continue;
                }

                var optionsConfigurationServiceCollectionExtensions = typeof(OptionsConfigurationServiceCollectionExtensions).GetMethods().FirstOrDefault().MakeGenericMethod(optionType);//利用反射生成一个泛型返回值的方法

                var objs = new List<object>()
                {
                    services,
                    Configuration.GetSection(optionAttribute.Url)
                };

                optionsConfigurationServiceCollectionExtensions.Invoke(null, objs.ToArray());//执行当前泛型犯法

                var optionObject = Activator.CreateInstance(optionType);//反射创建实例

                var properties = optionType.GetProperties();//获取指定对象的所有公共属性

                var section = Configuration.GetSection(optionAttribute.Url);

                if (optionObject == null) return;

                var instance = optionType.BindInstance(optionObject, section, new BinderOptions()
                {
                    BindNonPublicProperties = false
                })!;

                services.AddSingleton(optionType, instance);//加入服务方便调用

                FrameContainer.Options.Add(optionType, instance);
            }
        }

        /// <summary>
        /// 添加NewtonsoftJson作为项目输出的主要格式
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="mvcAction">Mvc配置委托</param>
        /// <param name="jsonAction">NewtonsoftJson配置委托</param>
        public static void AddMvcNewtonsoftJson(this IServiceCollection services, Action<MvcOptions>? mvcAction = null, Action<MvcNewtonsoftJsonOptions>? jsonAction = null)
        {
            //注入新版默认序列化json
            services.AddMvc(setup =>
            {
                setup.ReturnHttpNotAcceptable = true;//当输入格式与默认格式不符时返回406状态码
                mvcAction?.Invoke(setup);

                #region 老版输入输出格式写法

                //（新版在下方.AddNewtonsoftJson,AddXmlDataContractSerializerFormatters）
                //setup.InputFormatters.Add(new XmlDataContractSerializerInputFormatter(setup));//设置默认输入格式为xml格式
                //setup.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());//设置输出支持xml格式
                //setup.OutputFormatters.Insert(0,new XmlDataContractSerializerOutputFormatter());//设置xml格式为默认输出格式

                #endregion
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                jsonAction?.Invoke(options);

                #region Json 拓展用法

                //// 忽略循环引用
                //options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //// 不使用驼峰
                //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //// 设置时间格式
                //options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                // 如字段为null值，该字段不会返回到前端
                // options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore; 

                #endregion
            });
        }

        /// <summary>
        /// 添加Swagger文档服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="frameSwaggerAction">Swagger配置信息</param>
        public static void AddSwaggerServices(this IServiceCollection services, Action<FrameSwaggerOptions>? frameSwaggerAction = null)
        {
            //当前服务被添加说明Swagger被启动，将会自动注册Swagger的信息，并且Startup内的Startup.Configure不用再重复UseSwagger和UseSwaggerUI
            frameSwaggerAction?.Invoke(FrameContainer.FrameSwaggerOptions);

            if (!FrameContainer.FrameSwaggerOptions.EnableSwagger)
            {
                return;
            }

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(FrameContainer.FrameSwaggerOptions.DefaultSwaggerConfig.GroupName, FrameContainer.FrameSwaggerOptions.DefaultSwaggerConfig.OpenApiInfo);

                foreach (var config in FrameContainer.FrameSwaggerOptions.GroupSwaggerConfigs)
                {
                    options.SwaggerDoc(config.GroupName, config.OpenApiInfo);
                }

                //模块隔离，无ApiExplorerSettingsAttribute特性的默认显示至默认模块
                options.DocInclusionPredicate((docName, apiDes) =>
                {
                    if (!apiDes.TryGetMethodInfo(out MethodInfo method))
                    {
                        return false;
                    }

                    var version = method?.DeclaringType?.GetCustomAttributes(true).OfType<ApiExplorerSettingsAttribute>().Select(m => m.GroupName).ToList();

                    var actionVersion = method?.GetCustomAttributes(true).OfType<ApiExplorerSettingsAttribute>().Select(m => m.GroupName).ToList();

                    if (FrameContainer.FrameSwaggerOptions.DefaultSwaggerConfig.GroupName.Equals(docName))
                    {
                        if ((!version.Any() && !actionVersion.Any()) || version.Any(v => v == docName) || actionVersion.Any(v => v == docName))
                        {
                            return true;
                        }

                        return false;
                    }
                    else
                    {
                        if (version.Any(x => x == docName) || actionVersion.Any(x => x == docName))
                        {
                            return true;
                        }

                        return false;
                    }
                });

                //配置Swagger需要的XML文件
                foreach (var xmlComment in FrameContainer.FrameSwaggerOptions.XmlComments)
                {
                    var assemblyXmlName = xmlComment.EndsWith(".xml") ? xmlComment : $"{xmlComment}.xml";
                    var assemblyXmlPath = Path.Combine(AppContext.BaseDirectory, assemblyXmlName);
                    if (File.Exists(assemblyXmlPath))
                    {
                        options.IncludeXmlComments(assemblyXmlPath, true);
                    }
                }

                //添加过滤器新增头部信息
                options.OperationFilter<SwaggerHeaderFilter>();
                //使得Swagger能够正确地显示Enum的对应关系
                options.SchemaFilter<EnumSchemaFilter>();

                FrameContainer.FrameSwaggerOptions.SwaggerGenOptions?.Invoke(options);
            });

            services.AddTransient<IStartupFilter>((serverProvider) => new ActionMiddlewareStartupFilter((applicationBuilder) =>
            {
                applicationBuilder.UseSwagger();

                applicationBuilder.UseSwaggerUI((options) =>
                {
                    options.DocExpansion(DocExpansion.None);
                    options.SwaggerEndpoint($"/swagger/{Uri.EscapeDataString(FrameContainer.FrameSwaggerOptions.DefaultSwaggerConfig.GroupName)}/swagger.json", FrameContainer.FrameSwaggerOptions.DefaultSwaggerConfig.GroupName);

                    foreach (var config in FrameContainer.FrameSwaggerOptions.GroupSwaggerConfigs)
                    {
                        options.SwaggerEndpoint($"/swagger/{Uri.EscapeDataString(config.GroupName)}/swagger.json", config.GroupName);
                    }

                    FrameContainer.FrameSwaggerOptions.SwaggerUIOptions?.Invoke(options);
                });
            }, true));
        }
    }
}
