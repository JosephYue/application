using Application.Mongo.Extension.Config;
using Application.Mongo.Extension.Interface;
using MongoDB.Driver;
using System;
using System.Linq;

namespace Application.Mongo.Extension
{
    /// <summary>
    /// mongodb的dbcontext
    /// </summary>
    public class MongoDbContext : DbContextConfig, IMongo
    {
        /// <summary>
        /// 获取MongoDB的Collection
        /// </summary>
        /// <typeparam name="TDocument">Collection的泛型</typeparam>
        /// <returns></returns>
        public IMongoCollection<TDocument> GetCollection<TDocument>()
        {
            var collectionName = MongoContainer.CollectionNames.FirstOrDefault(x => x.Key == typeof(TDocument)).Value;

            if (string.IsNullOrWhiteSpace(collectionName))
            {
                collectionName = typeof(TDocument).Name;
            }

            return GetDatabase().GetCollection<TDocument>(collectionName);
        }

        /// <summary>
        /// 获取MongoDB的Collection
        /// </summary>
        /// <typeparam name="TDocument">Collection的泛型</typeparam>
        /// <param name="settings">配置信息</param>
        /// <returns></returns>
        public IMongoCollection<TDocument> GetCollection<TDocument>(MongoCollectionSettings settings)
        {
            var collectionName = MongoContainer.CollectionNames.FirstOrDefault(x => x.Key == typeof(TDocument)).Value;

            if (string.IsNullOrWhiteSpace(collectionName))
            {
                collectionName = typeof(TDocument).Name;
            }

            return GetDatabase().GetCollection<TDocument>(collectionName, settings);
        }

        /// <summary>
        /// 获取MongoDB的Collection
        /// </summary>
        /// <typeparam name="TDocument">Collection的泛型</typeparam>
        /// <param name="name">Collection的name</param>
        /// <returns></returns>
        public IMongoCollection<TDocument> GetCollection<TDocument>(string name)
        {
            return GetDatabase().GetCollection<TDocument>(name);
        }

        /// <summary>
        /// 获取MongoDB的Collection
        /// </summary>
        /// <typeparam name="TDocument">Collection的泛型</typeparam>
        /// <param name="name">Collection的name</param>
        /// <param name="settings">配置信息</param>
        /// <returns></returns>
        public IMongoCollection<TDocument> GetCollection<TDocument>(string name, MongoCollectionSettings settings)
        {
            return GetDatabase().GetCollection<TDocument>(name, settings);
        }
    }

    /// <summary>
    /// 数据库配置信息
    /// </summary>
    public class DbContextConfig
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DbContextConfig()
        {
            Initialize();

            if (Client is null)
            {
                throw new ArgumentNullException(nameof(MongoClient));
            }
        }

        /// <summary>
        /// 请求
        /// </summary>
        internal MongoClient Client { get; set; }

        /// <summary>
        /// 数据库
        /// </summary>
        internal string DataBase { get; set; } = string.Empty;

        /// <summary>
        /// 初始化
        /// </summary>
        void Initialize()
        {
            if (MongoContainer.MongoClientSettingsOption != null)
            {
                Client = new MongoClient(MongoContainer.MongoClientSettingsOption.MongoClientSettings);
                DataBase = MongoContainer.MongoClientSettingsOption.Database;
            }

            if (MongoContainer.MongoUrlOption != null)
            {
                Client = new MongoClient(MongoContainer.MongoUrlOption.MongoUrl);
                DataBase = MongoContainer.MongoUrlOption.Database;
            }

            if (MongoContainer.MongoConnectionOption != null)
            {
                Client = new MongoClient(MongoContainer.MongoConnectionOption.ConnectionString);
                DataBase = MongoContainer.MongoConnectionOption.Database;
            }
        }

        /// <summary>
        /// 获取数据库
        /// </summary>
        /// <returns></returns>
        internal IMongoDatabase GetDatabase()
        {
            return Client.GetDatabase(DataBase);
        }

        /// <summary>
        /// 获取数据库
        /// </summary>
        /// <param name="database">数据库名称</param>
        /// <returns></returns>
        internal IMongoDatabase GetDatabase(string database)
        {
            return Client.GetDatabase(database);
        }
    }
}
