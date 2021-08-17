using Application.Frame.Extension.Config.Attributes;
using Application.Frame.Extension.Config.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Application.Frame.Extension.Extensions
{
    /// <summary>
    /// Assembly拓展
    /// </summary>
    internal class FrameAssemblyExtensions
    {
        #region Method

        /// <summary>
        /// 获取整个程序集的Assemblies
        /// </summary>
        /// <returns></returns>
        public static Assembly[] GetAssemblies()
        {
            return FrameContainer.Assemblies ?? SetAssemblies();
        }

        /// <summary>
        /// 获取自定义Attribute的类型及Type信息
        /// </summary>
        /// <typeparam name="T">泛型 必须为 Attribute</typeparam>
        /// <returns></returns>
        public static List<(Type?, T)> GetCustomAttributes<T>() where T : Attribute
        {
            var result = new List<(Type?, T)>();

            foreach (var assembly in GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.GetCustomAttribute<T>() is null)
                    {
                        continue;
                    }

                    result.Add((type, type.GetCustomAttribute<T>()!));
                }
            }

            return result;
        }

        /// <summary>
        /// 初始化Assemblies
        /// </summary>
        public static void InitializeAssembly()
        {
            SetAssemblies();

            foreach (var assembly in FrameContainer.Assemblies!)
            {
                foreach (var type in assembly.GetTypes())
                {
                    foreach (var attributeType in FrameContainer.AttributeTypes)
                    {
                        var attribute = type.GetCustomAttribute(attributeType);

                        if (attribute is null)
                        {
                            continue;
                        }

                        if (typeof(OptionAttribute) == attributeType)
                        {
                            FrameContainer.OptionAttributes.Add((type, attribute as OptionAttribute));
                        }

                        if (typeof(ServiceAttribute) == attributeType || typeof(TransientServiceAttribute) == attributeType || typeof(ScopedServiceAttribute) == attributeType || typeof(SingletonServiceAttribute) == attributeType)
                        {
                            FrameContainer.ServiceAttributes.Add((type, attribute as ServiceAttribute));
                        }
                    }

                    if (IsApiController(type))
                    {
                        foreach (var method in type.GetMethods())
                        {
                            if (IsApiAction(method, type))
                            {
                                if (!method.IsDefined(typeof(ApiExplorerSettingsAttribute), true))
                                {
                                    continue;
                                }

                                FrameContainer.ControllerActions.Add(method);
                                SetGroupSwaggerConfig(method.GetCustomAttribute<ApiExplorerSettingsAttribute>(true)!);
                            }
                        }

                        if (!type.IsDefined(typeof(ApiExplorerSettingsAttribute), true))
                        {
                            continue;
                        }

                        FrameContainer.ControllerTypes.Add(type);
                        SetGroupSwaggerConfig(type.GetCustomAttribute<ApiExplorerSettingsAttribute>(true)!);
                    }
                }
            }
        }

        static void SetGroupSwaggerConfig(ApiExplorerSettingsAttribute attributeInfo)
        {
            if (FrameContainer.FrameSwaggerOptions.GroupSwaggerConfigs.Any(x=>x.GroupName== attributeInfo.GroupName))
            {
                return;
            }

            FrameContainer.FrameSwaggerOptions.GroupSwaggerConfigs.Add(new SwaggerOpenApiInfo()
            {
                GroupName = attributeInfo.GroupName,
                OpenApiInfo = new OpenApiInfo()
                {
                    Description = attributeInfo.GroupName,
                    Title = attributeInfo.GroupName,
                    Version = "1.0.0"
                }
            });
        }

        /// <summary>
        /// 判断是否是Api控制器
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        internal static bool IsApiController(Type type)
        {
            if (!type.IsPublic || type.IsPrimitive || type.IsValueType || type.IsAbstract || type.IsInterface || type.IsGenericType) return false;

            // 继承 ControllerBase 或 实现 IDynamicApiController 的类型 或 贴了 [DynamicApiController] 特性
            if (typeof(Controller).IsAssignableFrom(type) && typeof(ControllerBase).IsAssignableFrom(type))
            {
                // 不是能被导出忽略的接口
                var attribute = type.GetCustomAttribute<ApiExplorerSettingsAttribute>(true);

                if (attribute == null)
                {
                    return true;
                }

                if (type.IsDefined(typeof(ApiExplorerSettingsAttribute), true) && attribute.IgnoreApi) return false;

                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断是否是方法
        /// </summary>
        /// <param name="method">方法</param>
        /// <param name="ReflectedType">反射类型</param>
        /// <returns></returns>
        internal static bool IsApiAction(MethodInfo method, Type ReflectedType)
        {
            // 不是非公开、抽象、静态、泛型方法
            if (!method.IsPublic || method.IsAbstract || method.IsStatic || method.IsGenericMethod) return false;

            // 如果所在类型不是控制器，则该行为也被忽略
            if (method.ReflectedType != ReflectedType || method.DeclaringType == typeof(object)) return false;

            var attribute = method.GetCustomAttribute<ApiExplorerSettingsAttribute>(true);

            if (attribute == null)
            {
                return true;
            }

            // 不是能被导出忽略的接方法
            if (method.IsDefined(typeof(ApiExplorerSettingsAttribute), true) && attribute.IgnoreApi) return false;

            return true;
        }

        #endregion

        #region Private

        /// <summary>
        /// 设置Assemblies集合
        /// </summary>
        /// <returns></returns>
        static Assembly[] SetAssemblies()
        {
            return FrameContainer.Assemblies = AppDomain.CurrentDomain.GetAssemblies();
        }

        #endregion
    }
}
