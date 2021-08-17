using Application.Mongo.Extension.Config;
using Application.Mongo.Extension.Config.Options;
using Application.Mongo.Extension.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Application.Mongo.Extension
{
    /// <summary>
    /// MongoDB配置类
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// 注册MogoDb服务
        /// </summary>
        /// <param name="service">服务集合</param>
        /// <param name="optionsBuilder">配置信息</param>
        public static void AddMongoServices(this IServiceCollection service, Action<MongoConnectionOption> optionsBuilder)
        {
            if (optionsBuilder == null)
            {
                throw new ArgumentNullException(nameof(MongoConnectionOption));
            }

            optionsBuilder.Invoke(MongoContainer.MongoConnectionOption ??= new MongoConnectionOption());

            if (string.IsNullOrWhiteSpace(MongoContainer.MongoConnectionOption!.ConnectionString))
            {
                throw new ArgumentNullException(nameof(MongoContainer.MongoConnectionOption.ConnectionString));
            }

            service.AddScoped(typeof(IMongo), typeof(MongoDbContext));

            MongoContainer.SetCollectionNames();
        }

        /// <summary>
        /// 注册MogoDb服务
        /// </summary>
        /// <param name="service">服务集合</param>
        /// <param name="optionsBuilder">配置信息</param>
        public static void AddMongoServices(this IServiceCollection service, Action<MongoClientSettingsOption> optionsBuilder)
        {
            if (optionsBuilder == null)
            {
                throw new ArgumentNullException(nameof(MongoClientSettingsOption));
            }

            optionsBuilder.Invoke(MongoContainer.MongoClientSettingsOption ??= new MongoClientSettingsOption());

            service.AddScoped(typeof(IMongo), typeof(MongoDbContext));

            MongoContainer.SetCollectionNames();
        }

        /// <summary>
        /// 注册MogoDb服务
        /// </summary>
        /// <param name="service">服务集合</param>
        /// <param name="optionsBuilder">配置信息</param>
        public static void AddMongoServices(this IServiceCollection service, Action<MongoUrlOption> optionsBuilder)
        {
            if (optionsBuilder == null)
            {
                throw new ArgumentNullException(nameof(MongoUrlOption));
            }

            optionsBuilder.Invoke(MongoContainer.MongoUrlOption ??= new MongoUrlOption());

            service.AddScoped(typeof(IMongo), typeof(MongoDbContext));

            MongoContainer.SetCollectionNames();
        }
    }
}
