using Application.EntityFrameworkCore.Extension.Config.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static Application.EntityFrameworkCore.Extension.Config.EntityFrameworkCoreEventHandlers;

namespace Application.EntityFrameworkCore.Extension.Config
{
    internal class EntityFrameworkCoreConfiguration
    {
        /// <summary>
        /// 数据库连接配置
        /// </summary>
        public static ConnectionConfig ConnectionConfig { get; set; }

        /// <summary>
        /// EF映射的Mapper Type 集合
        /// </summary>
        public static List<Type> MapperTypes { get; set; } = new List<Type>();

        /// <summary>
        /// 注册DbContext配置
        /// </summary>
        public static void RegisterDbContextConfig()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var mappingInterface = typeof(IEntityTypeConfiguration<>);

            foreach (var assemblie in assemblies)
            {
                foreach (var type in assemblie.GetTypes())
                {
                    var methods = type.GetMethods().Where(x => x.IsPublic && x.CustomAttributes.Any(x => x.AttributeType == typeof(OnConfiguringAttribute) || x.AttributeType == typeof(OnModelCreatingAttribute))).ToList();

                    var onConfiguringMethods = methods.Where(x => x.CustomAttributes.Any(c => c.AttributeType == typeof(OnConfiguringAttribute)));

                    var onModelCreatingMethods = methods.Where(x => x.CustomAttributes.Any(c => c.AttributeType == typeof(OnModelCreatingAttribute)));

                    foreach (var method in onConfiguringMethods)
                    {
                        object demethodInstance = Activator.CreateInstance(method.DeclaringType);

                        // 创建一个OnConfiguring类型的委托
                        var customDelegate = Delegate.CreateDelegate(typeof(OnConfiguring), demethodInstance, method);

                        DbContextConfig.EntityFrameworkCoreOnConfiguring += customDelegate as OnConfiguring;
                    }

                    foreach (var method in onModelCreatingMethods)
                    {
                        object demethodInstance = Activator.CreateInstance(method.DeclaringType);

                        // 创建一个OnModelCreating类型的委托
                        var customDelegate = Delegate.CreateDelegate(typeof(OnModelCreating), demethodInstance, method);

                        DbContextConfig.EntityFrameworkCoreOnModelCreating += customDelegate as OnModelCreating;
                    }

                    if (type.GetInterfaces().Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == mappingInterface).Count() > 0)
                    {
                        MapperTypes.Add(type);
                    }
                }
            }
        }
    }
}
