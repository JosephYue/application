using Application.EntityFrameworkCore.Extension.Config;
using Application.EntityFrameworkCore.Extension.Config.Options;
using Application.EntityFrameworkCore.Extension.Interface;
using Application.EntityFrameworkCore.Extension.Migration;
using Application.EntityFrameworkCore.Extension.Migration.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Application.EntityFrameworkCore.Extension
{
    public static class Startup
    {
        /// <summary>
        /// 添加EFCore启动
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="optionsBuilder">配置信息</param>
        public static void AddEntityFrameworkCore(this IServiceCollection services, Action<EntityFrameworkCoreOption> optionsBuilder)
        {
            services.AddControllers();

            if (optionsBuilder == null)
            {
                throw new ArgumentNullException(nameof(EntityFrameworkCoreOption));
            }

            var option = new EntityFrameworkCoreOption();

            optionsBuilder.Invoke(option);

            if (option.ConnectionConfig == null)
            {
                throw new ArgumentNullException(nameof(ConnectionConfig));
            }

            EntityFrameworkCoreConfiguration.RegisterDbContextConfig();
            EntityFrameworkCoreConfiguration.ConnectionConfig = option.ConnectionConfig;

            services.AddTransient<IEntityFrameworkCoreMigration, EntityFrameworkCoreMigration>();
            services.AddScoped(typeof(IRepository<,>), typeof(RepositoryBase<,>));
            services.AddScoped(typeof(IQuery<,>), typeof(QueryBase<,>));
            services.AddDbContext<EntityFrameworkCoreDbContext>();
            services.AddScoped(typeof(IUnitOfWork), typeof(EntityFrameworkCoreDbContext));
            services.Configure(optionsBuilder);
        }
    }
}
