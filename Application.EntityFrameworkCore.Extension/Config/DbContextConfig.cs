using Application.EntityFrameworkCore.Extension.Config;
using Microsoft.EntityFrameworkCore;
using static Application.EntityFrameworkCore.Extension.Config.EntityFrameworkCoreEventHandlers;

namespace Application.EntityFrameworkCore.Extension.Config
{
    internal class DbContextConfig
    {
        /// <summary>
        /// OnConfiguring事件
        /// </summary>
        internal static event OnConfiguring EntityFrameworkCoreOnConfiguring;

        /// <summary>
        /// OnModelCreating事件
        /// </summary>
        internal static event OnModelCreating EntityFrameworkCoreOnModelCreating;

        /// <summary>
        /// 监听OnConfiguring事件
        /// </summary>
        /// <param name="optionsBuilder"></param>
        /// <param name="connectionConfig"></param>
        public static bool ListenOnConfiguring(DbContextOptionsBuilder optionsBuilder, ConnectionConfig connectionConfig)
        {
            EntityFrameworkCoreOnConfiguring?.Invoke(optionsBuilder, connectionConfig);

            return EntityFrameworkCoreOnConfiguring != null;
        }

        /// <summary>
        /// 监听OnModelCreating事件
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static bool ListenOnModelCreating(ModelBuilder modelBuilder)
        {
            EntityFrameworkCoreOnModelCreating?.Invoke(modelBuilder);

            return EntityFrameworkCoreOnModelCreating != null;
        }
    }
}
