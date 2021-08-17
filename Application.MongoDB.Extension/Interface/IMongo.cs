using MongoDB.Driver;
using System;

namespace Application.Mongo.Extension.Interface
{
    /// <summary>
    /// MongoDb接口
    /// </summary>
    public interface IMongo
    {
        /// <summary>
        /// 得到一组MongoDb的数据链接
        /// </summary>
        /// <returns></returns>
        IMongoCollection<TDocument> GetCollection<TDocument>();

        /// <summary>
        /// 得到一组MongoDb的数据链接
        /// </summary>
        /// <param name="settings">当前链接的配置</param>
        /// <returns></returns>
        IMongoCollection<TDocument> GetCollection<TDocument>(MongoCollectionSettings settings);

        /// <summary>
        /// 得到一组MongoDb的数据链接
        /// </summary>
        /// <param name="name">指定的实体链接名称</param>
        /// <returns></returns>
        IMongoCollection<TDocument> GetCollection<TDocument>(string name);

        /// <summary>
        /// 得到一组MongoDb的数据链接
        /// </summary>
        /// <param name="name">指定的实体链接名称</param>
        /// <param name="settings">当前链接的配置</param>
        /// <returns></returns>
        IMongoCollection<TDocument> GetCollection<TDocument>(string name, MongoCollectionSettings settings);
    }
}
