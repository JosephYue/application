using Microsoft.Extensions.DependencyInjection;
using System;

namespace Application.Frame.Extension.Config.Attributes
{
    /// <summary>
    /// 服务标识
    /// 注：带有此标识的会被注册进容器
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ServiceAttribute : Attribute
    {
        /// <summary>
        /// 服务标识
        /// 注：带有此标识的会被注册进容器
        /// </summary>
        public ServiceAttribute()
        {

        }

        /// <summary>
        /// 服务标识
        /// 注：带有此标识的会被注册进容器
        /// </summary>
        /// <param name="as">当前参数必须为接口，被标记的类必须是当前接口参数的实现</param>
        /// <param name="lifetime">服务的生命周期</param>
        public ServiceAttribute(Type @as, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            if (!@as.IsInterface)
            {
                throw new TypeUnloadedException(@as.Name);
            }

            InterfaceType = @as;
            Lifetime = lifetime;
        }

        /// <summary>
        /// 注册服务生命周期
        /// </summary>
        internal ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Transient;

        /// <summary>
        /// 接口类型
        /// </summary>
        internal Type? InterfaceType { get; set; }
    }

    /// <summary>
    /// 服务标识（瞬时：Transient）
    /// 注：带有此标识的会被注册进容器
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class TransientServiceAttribute : ServiceAttribute
    {
        /// <summary>
        /// 服务标识
        /// 注：带有此标识的会被注册进容器
        /// </summary>
        public TransientServiceAttribute()
        {
            Lifetime = ServiceLifetime.Transient;
        }

        /// <summary>
        /// 服务标识
        /// 注：带有此标识的会被注册进容器
        /// </summary>
        /// <param name="as">当前参数必须为接口，被标记的类必须是当前接口参数的实现</param>
        public TransientServiceAttribute(Type @as) : base(@as, ServiceLifetime.Transient)
        {

        }
    }

    /// <summary>
    /// 服务标识（局域：Scoped）
    /// 注：带有此标识的会被注册进容器
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ScopedServiceAttribute : ServiceAttribute
    {
        /// <summary>
        /// 服务标识
        /// 注：带有此标识的会被注册进容器
        /// </summary>
        public ScopedServiceAttribute()
        {
            Lifetime = ServiceLifetime.Scoped;
        }

        /// <summary>
        /// 服务标识
        /// 注：带有此标识的会被注册进容器
        /// </summary>
        /// <param name="as">当前参数必须为接口，被标记的类必须是当前接口参数的实现</param>
        public ScopedServiceAttribute(Type @as) : base(@as, ServiceLifetime.Scoped)
        {

        }
    }

    /// <summary>
    /// 服务标识（单例：Singleton）
    /// 注：带有此标识的会被注册进容器
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class SingletonServiceAttribute : ServiceAttribute
    {
        /// <summary>
        /// 服务标识
        /// 注：带有此标识的会被注册进容器
        /// </summary>
        public SingletonServiceAttribute()
        {
            Lifetime = ServiceLifetime.Singleton;
        }

        /// <summary>
        /// 服务标识
        /// 注：带有此标识的会被注册进容器
        /// </summary>
        /// <param name="as">当前参数必须为接口，被标记的类必须是当前接口参数的实现</param>
        public SingletonServiceAttribute(Type @as) : base(@as, ServiceLifetime.Singleton)
        {

        }
    }
}
