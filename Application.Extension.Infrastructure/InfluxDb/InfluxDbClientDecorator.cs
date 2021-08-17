using Application.Extension.Infrastructure.InfluxDb.Options;
using InfluxData.Net.InfluxDb;
using InfluxData.Net.InfluxDb.ClientModules;
using InfluxData.Net.InfluxDb.Models.Responses;
using InfluxData.Net.InfluxDb.RequestClients;
using System;
using System.Linq;

namespace Application.Extension.Infrastructure.InfluxDb
{
    public class InfluxDbClientDecorator : IInfluxDbClient
    {
        private readonly IInfluxDbClient _influxDbClient;

        public InfluxDbClientDecorator(IInfluxDbClient influxDbClient, InfluxDbClientOptions options)
        {
            _influxDbClient = influxDbClient;
            Client = new BasicClientModuleDecorator(_influxDbClient.Client, options);

            if (!string.IsNullOrEmpty(options.DbName))
            {
                EnsureDatabaseCreated(options.DbName);
            }

            if (options.RetentionPolicies != null)
            {
                foreach (var retentionPolicies in options.RetentionPolicies)
                {
                    EnsureRetentionPolicyCreated(retentionPolicies, options.DbName);
                }
            }
        }

        /// <summary>
        /// 生成数据库
        /// </summary>
        /// <param name="dbName"></param>
        private void EnsureDatabaseCreated(string dbName)
        {
            var databaseNames = Database.GetDatabasesAsync().Result;

            if (!databaseNames.Any(r => r.Name == dbName))
            {
                Database.CreateDatabaseAsync(dbName);
            }
        }

        /// <summary>
        /// 创建策略
        /// </summary>
        /// <param name="defaultPolicy"></param>
        /// <param name="dbName"></param>
        private void EnsureRetentionPolicyCreated(RetentionPolicy defaultPolicy, string dbName)
        {
            var policies = Retention.GetRetentionPoliciesAsync(dbName).Result;
            if (!policies.Any(r => r.Name == defaultPolicy.Name))
            {
                var result = Retention.CreateRetentionPolicyAsync(dbName, defaultPolicy.Name, defaultPolicy.Duration, defaultPolicy.ReplicationCopies).Result;
                if (!result.Success)
                {
                    throw new InvalidOperationException("初始化策略失败");
                }
            }
        }

        #region 请求方式

        public IBasicClientModule Client { get; }

        public ISerieClientModule Serie => _influxDbClient.Serie;

        public IDatabaseClientModule Database => _influxDbClient.Database;

        public IRetentionClientModule Retention => _influxDbClient.Retention;

        public ICqClientModule ContinuousQuery => _influxDbClient.ContinuousQuery;

        public IDiagnosticsClientModule Diagnostics => _influxDbClient.Diagnostics;

        public IUserClientModule User => _influxDbClient.User;

        public IInfluxDbRequestClient RequestClient => _influxDbClient.RequestClient;

        #endregion
    }
}
