//using System.Threading.Tasks;

//namespace Application.Extension.Infrastructure.Framework.EntitiyExtensions.Elasticsearch
//{
//    public interface IElasticsearchRepository<TEntity> where TEntity : IElasticsearchAggregateRoot
//    {
//        /// <summary>
//        /// 添加/修改
//        /// </summary>
//        /// <param name="entity">实体</param>
//        /// <param name="index">数据库索引，不传走默认索引（当前对象的名称）</param>
//        void AddOrUpdate(TEntity entity, string index = "");

//        /// <summary>
//        /// 异步添加/修改
//        /// </summary>
//        /// <param name="entity">实体</param>
//        /// <param name="index">数据库索引，不传走默认索引（当前对象的名称）</param>
//        Task AddOrUpdateAsync(TEntity entity, string index = "");

//        /// <summary>
//        /// 删除
//        /// </summary>
//        /// <param name="entity">实体</param>
//        void Remove(TEntity entity);

//        /// <summary>
//        /// 删除
//        /// </summary>
//        /// <param name="entity">实体</param>
//        Task RemoveAsync(TEntity entity);
//    }
//}
