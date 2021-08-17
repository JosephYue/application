using Application.EntityFrameworkCore.Extension.Config;
using Application.EntityFrameworkCore.Extension.Config.Enum;
using Application.EntityFrameworkCore.Extension.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Application.EntityFrameworkCore.Extension
{
    public class EntityFrameworkCoreDbContext : DbContext, IUnitOfWork
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public EntityFrameworkCoreDbContext(DbContextOptions<EntityFrameworkCoreDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// 重写数据库配置
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!DbContextConfig.ListenOnConfiguring(optionsBuilder, EntityFrameworkCoreConfiguration.ConnectionConfig))
            {
                switch (EntityFrameworkCoreConfiguration.ConnectionConfig.DbType)
                {
                    case DbTypeEnum.MySql:

                        optionsBuilder
                            .UseMySql(EntityFrameworkCoreConfiguration.ConnectionConfig.ConnectionString,
                            ServerVersion.AutoDetect(EntityFrameworkCoreConfiguration.ConnectionConfig.ConnectionString)
                            , option =>
                             {
                                 option.EnableRetryOnFailure(
                                 maxRetryCount: 5,
                                 maxRetryDelay: TimeSpan.FromSeconds(30),
                                 errorNumbersToAdd: null);

                                 if (!string.IsNullOrWhiteSpace(EntityFrameworkCoreConfiguration.ConnectionConfig.MigrationsAssembly))
                                 {
                                     option.MigrationsAssembly(EntityFrameworkCoreConfiguration.ConnectionConfig.MigrationsAssembly);
                                 }

                             });

                        break;
                    case DbTypeEnum.SqlServer:

                        optionsBuilder
                            .UseSqlServer(EntityFrameworkCoreConfiguration.ConnectionConfig.ConnectionString, option =>
                             {
                                 if (!string.IsNullOrWhiteSpace(EntityFrameworkCoreConfiguration.ConnectionConfig.MigrationsAssembly))
                                 {
                                     option.MigrationsAssembly(EntityFrameworkCoreConfiguration.ConnectionConfig.MigrationsAssembly);
                                 }
                             });

                        break;
                    default:
                        throw new ArgumentNullException(nameof(EntityFrameworkCoreConfiguration.ConnectionConfig.DbType));
                }
            }
        }

        /// <summary>
        /// 重写模型构建
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (!DbContextConfig.ListenOnModelCreating(modelBuilder))
            {
                foreach (var mappingType in EntityFrameworkCoreConfiguration.MapperTypes)
                {
                    var mapper = Activator.CreateInstance(mappingType);
                    modelBuilder.ApplyConfiguration(mapper as dynamic);
                }
            }
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            try
            {
                SaveChanges();
            }
            catch (Exception)
            {
                return RollBack();
            }

            return true;
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CommitAsync()
        {
            try
            {
                await SaveChangesAsync();
            }
            catch (Exception)
            {
                return RollBack();
            }

            return true;
        }

        /// <summary>
        /// 回滚
        /// </summary>
        /// <returns></returns>
        public bool RollBack()
        {
            return false;
        }
    }
}
