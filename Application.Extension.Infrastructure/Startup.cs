using Application.Extension.Infrastructure.Crontab.Quartz;
using Application.Extension.Infrastructure.Crontab.Quartz.Factory;
using Application.Extension.Infrastructure.DbConnection.MySql;
using Application.Extension.Infrastructure.DbConnection.MySql.Interface;
using Application.Extension.Infrastructure.DbConnection.MySql.Options;
using Application.Extension.Infrastructure.Elasticsearch.Factory;
using Application.Extension.Infrastructure.Elasticsearch.Options;
using Application.Extension.Infrastructure.InfluxDb;
using Application.Extension.Infrastructure.InfluxDb.Interface;
using Application.Extension.Infrastructure.InfluxDb.Options;
using Application.Extension.Infrastructure.RabbitMQ;
using Application.Extension.Infrastructure.RabbitMQ.Interface;
using Application.Extension.Infrastructure.RabbitMQ.Options;
using Application.Extension.Infrastructure.Storage.Oss;
using Application.Extension.Infrastructure.Storage.Oss.Interface;
using Application.Extension.Infrastructure.Storage.Oss.Options;
using InfluxData.Net.InfluxDb;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Linq;
using System.Reflection;

namespace Application.Extension.Infrastructure
{
    /// <summary>
    /// 基础类库启动类
    /// </summary>
    public static class Startup
    {
        #region 添加Quartz定时任务

        /// <summary>
        /// 添加Quartz定时任务
        /// </summary>
        /// <param name="services">服务集合</param>
        public static void AddQuartz(this IServiceCollection services)
        {
            var assembly = Assembly.GetEntryAssembly()!;

            var jobs = assembly.DefinedTypes.Where(r => r.IsClass && typeof(IJob).IsAssignableFrom(r));

            foreach (var job in jobs)
            {
                services.AddTransient(job.AsType());
            }

            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddSingleton<IJobFactory, DependencyInjectionJobFactory>();
            services.AddHostedService<JobHostedService>();
        }

        #endregion

        #region 添加Elasticsearch服务

        /// <summary>
        /// 添加Elasticsearch服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="optionsBuilder">配置信息</param>
        /// <returns></returns>
        public static IServiceCollection AddElasticClient(this IServiceCollection services, Action<ElasticClientOptions> optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(ElasticClientOptions));
            }

            services.Configure(optionsBuilder);

            services.AddSingleton<IElasticClientFactory, ElasticClientFactory>();

            services.AddTransient<IElasticClient, ElasticClient>(provider =>
            {
                var service = provider.GetService<IElasticClientFactory>();

                if (service == null)
                {
                    throw new ArgumentNullException(nameof(IElasticClientFactory));
                }

                return service.CreateClient();
            });

            return services;
        }

        #endregion

        #region 添加InfluxDb服务

        /// <summary>
        /// 添加InfluxDb服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="optionsBuilder">操作信息</param>
        /// <returns></returns>
        public static IServiceCollection AddInfluxDbClient(this IServiceCollection services, Action<InfluxDbClientOptions> optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(InfluxDbClientOptions));
            }

            services.Configure(optionsBuilder);

            services.AddSingleton<IInfluxDbClientFactory, InfluxDbClientFactory>();
            services.AddScoped<IInfluxDbClient, InfluxDbClientDecorator>(serviceProvider =>
            {
                var service = serviceProvider.GetService<IInfluxDbClientFactory>();

                if (service == null)
                {
                    throw new ArgumentNullException(nameof(IInfluxDbClientFactory));
                }

                return service.CreateClient();
            });

            return services;
        }

        #endregion

        #region 添加拓展RabbitMQ拓展方法

        /// <summary>
        /// 添加拓展RabbitMQ拓展方法
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="optionsBuilder">配置信息</param>
        public static void AddRabbitMQExtension(this IServiceCollection services, Action<RabbitMQOptions> optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(RabbitMQOptions));
            }

            services.Configure(optionsBuilder);
            services.AddSingleton<IRabbitMQPublisher, RabbitMQPublisher>();
        }

        #endregion

        #region 添加Oss上传服务

        /// <summary>
        /// 添加Oss上传服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="optionsBuilder">Oss配置信息</param>
        public static void AddOssClient(this IServiceCollection services, Action<AliyunOssOptions> optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(AliyunOssOptions));
            }

            services.Configure(optionsBuilder);
            services.AddSingleton<IOssFileServices, OssFileServices>();
        }

        #endregion

        #region 添加MySql Sql语句查询服务

        /// <summary>
        /// 添加MySql Sql语句查询服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="optionsBuilder">配置信息</param>
        public static void AddMySqlServices(this IServiceCollection services, Action<MySqlOptions> optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(MySqlOptions));
            }

            services.Configure(optionsBuilder);

            services.AddSingleton<IMySqlConnection, MySql>();
        }

        #endregion
    }
}
