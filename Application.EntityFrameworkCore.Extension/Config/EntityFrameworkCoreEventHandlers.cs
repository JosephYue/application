using Microsoft.EntityFrameworkCore;

namespace Application.EntityFrameworkCore.Extension.Config
{
    public class EntityFrameworkCoreEventHandlers
    {
        /// <summary>
        /// OnConfiguring委托
        /// </summary>
        /// <param name="optionsBuilder"></param>
        /// <param name="connectionConfig"></param>
        public delegate void OnConfiguring(DbContextOptionsBuilder optionsBuilder, ConnectionConfig connectionConfig);

        /// <summary>
        /// OnModelCreating委托
        /// </summary>
        /// <param name="modelBuilder"></param>
        public delegate void OnModelCreating(ModelBuilder modelBuilder);
    }
}
