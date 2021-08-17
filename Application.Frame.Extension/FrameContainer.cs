using Application.Frame.Extension.Config.Attributes;
using Application.Frame.Extension.Config.Options;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Application.Frame.Extension
{
    /// <summary>
    /// 静态容器类（代替缓存的作用，存储一些固定的信息）
    /// </summary>
    internal class FrameContainer
    {
        /// <summary>
        /// 自定义OptionAttribute的信息集合
        /// </summary>
        public static Dictionary<Type, object> Options { get; set; } = new Dictionary<Type, object>();

        /// <summary>
        /// 属性类型集合
        /// </summary>
        public static List<Type> AttributeTypes
        {
            get
            {
                return new List<Type>()
                {
                   typeof(OptionAttribute),
                   typeof(ServiceAttribute),
                   typeof(TransientServiceAttribute),
                   typeof(ScopedServiceAttribute),
                   typeof(SingletonServiceAttribute),
                   typeof(ApiExplorerSettingsAttribute)
                };
            }
        }

        /// <summary>
        /// OptionAttribute信息
        /// </summary>
        public static List<(Type?, OptionAttribute?)> OptionAttributes { get; set; } = new List<(Type?, OptionAttribute?)>();

        /// <summary>
        /// ServiceAttribute信息
        /// </summary>
        public static List<(Type?, ServiceAttribute?)> ServiceAttributes { get; set; } = new List<(Type?, ServiceAttribute?)>();

        /// <summary>
        /// 整个项目的静态的Assemblies
        /// </summary>
        public static Assembly[]? Assemblies { get; set; }

        /// <summary>
        /// 全局静态变量ServiceProvider
        /// </summary>
        public static IServiceProvider? ServiceProvider { get; set; }

        /// <summary>
        /// Swagger的配置信息
        /// </summary>
        public static FrameSwaggerOptions FrameSwaggerOptions { get; set; } = new FrameSwaggerOptions();

        /// <summary>
        /// 控制器类型
        /// </summary>
        public static List<Type> ControllerTypes { get; set; } = new List<Type>();

        /// <summary>
        /// 控制器方法
        /// </summary>
        public static List<MethodInfo> ControllerActions { get; set; } = new List<MethodInfo>();
    }
}
