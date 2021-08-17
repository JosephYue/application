//using Application.Extension.Infrastructure.Framework.EntitiyExtensions.Elasticsearch;
//using Nest;
//using System.Threading.Tasks;

//namespace Application.Extension.Infrastructure.Framework.Core.Elasticsearch
//{
//    public class ElasticsearchRepositoryBase<TEntity> : IElasticsearchRepository<TEntity> where TEntity : ElasticsearchEntity, IElasticsearchAggregateRoot
//    {
//        private readonly IElasticClient _elasticClient;

//        public ElasticsearchRepositoryBase(IElasticClient elasticClient)
//        {
//            _elasticClient = elasticClient;
//        }

//        /// <summary>
//        /// 添加
//        /// </summary>
//        /// <param name="entity">实体</param>
//        /// <param name="index">数据库索引，不传走默认索引（当前对象的名称）</param>
//        public void AddOrUpdate(TEntity entity, string index = "")
//        {
//            if (!string.IsNullOrWhiteSpace(index))
//            {
//                _elasticClient.Index(entity, x => x.Index(index));

//                return;
//            }

//            _elasticClient.Index(entity, x => x.Index(typeof(TEntity).Name.ToLower()));
//        }

//        /// <summary>
//        /// 添加
//        /// </summary>
//        /// <param name="entity">实体</param>
//        /// <param name="index">数据库索引，不传走默认索引（当前对象的名称）</param>
//        public async Task AddOrUpdateAsync(TEntity entity, string index = "")
//        {
//            if (!string.IsNullOrWhiteSpace(index))
//            {
//                await _elasticClient.IndexAsync(entity, x => x.Index(index));

//                return;
//            }

//            await _elasticClient.IndexAsync(entity, x => x.Index(typeof(TEntity).Name.ToLower()));
//        }

//        /// <summary>
//        /// 删除
//        /// </summary>
//        /// <param name="entity">实体</param>
//        public void Remove(TEntity entity)
//        {
//            _elasticClient.Delete(new DocumentPath<TEntity>(entity.Id));
//        }

//        /// <summary>
//        /// 删除
//        /// </summary>
//        /// <param name="entity">实体</param>
//        public async Task RemoveAsync(TEntity entity)
//        {
//            await _elasticClient.DeleteAsync(new DocumentPath<TEntity>(entity.Id));
//        }
//    }
//}
