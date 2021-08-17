using Newtonsoft.Json;

namespace Application.Extension.Infrastructure.DbConnection.MySql.Options
{
    public class MySqlOptions
    {
        /// <summary>
        /// Gets or sets the database's connection string that will be used to store database entities.
        /// </summary>
        [JsonProperty("connectionString")]
        public string ConnectionString { get; set; } = string.Empty;
    }
}
