using Application.Extension.Infrastructure.InfluxDb.Options;
using InfluxData.Net.Common.Infrastructure;
using InfluxData.Net.InfluxDb.ClientModules;
using InfluxData.Net.InfluxDb.Models;
using InfluxData.Net.InfluxDb.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Extension.Infrastructure.InfluxDb
{
    public class BasicClientModuleDecorator : IBasicClientModule
    {
        private readonly IBasicClientModule _basicClientModule;
        private readonly InfluxDbClientOptions _clientOptions;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basicClientModule"></param>
        /// <param name="clientOptions"></param>
        public BasicClientModuleDecorator(IBasicClientModule basicClientModule,
            InfluxDbClientOptions clientOptions)
        {
            _basicClientModule = basicClientModule;
            _clientOptions = clientOptions;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="queries"></param>
        /// <param name="dbName"></param>
        /// <param name="epochFormat"></param>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IEnumerable<Serie>>> MultiQueryAsync(IEnumerable<string> queries, string dbName = "", string epochFormat = "", long? chunkSize = null)
        {
            if (dbName == null)
            {
                dbName = _clientOptions.DbName;
            }

            return await _basicClientModule.MultiQueryAsync(queries, dbName, epochFormat, chunkSize);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query"></param>
        /// <param name="dbName"></param>
        /// <param name="epochFormat"></param>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Serie>> QueryAsync(string query, string dbName = "", string epochFormat = "", long? chunkSize = null)
        {
            if (dbName == null)
            {
                dbName = _clientOptions.DbName;
            }

            return await _basicClientModule.QueryAsync(query, dbName, epochFormat, chunkSize);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="queries"></param>
        /// <param name="dbName"></param>
        /// <param name="epochFormat"></param>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Serie>> QueryAsync(IEnumerable<string> queries, string dbName = "", string epochFormat = "", long? chunkSize = null)
        {
            if (dbName == null)
            {
                dbName = _clientOptions.DbName;
            }

            return await _basicClientModule.QueryAsync(queries, dbName, epochFormat, chunkSize);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="queryTemplate"></param>
        /// <param name="parameters"></param>
        /// <param name="dbName"></param>
        /// <param name="epochFormat"></param>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Serie>> QueryAsync(string queryTemplate, object parameters, string dbName = "", string epochFormat = "", long? chunkSize = null)
        {
            if (dbName == null)
            {
                dbName = _clientOptions.DbName;
            }

            return await _basicClientModule.QueryAsync(queryTemplate, parameters, dbName, epochFormat, chunkSize);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="point"></param>
        /// <param name="dbName"></param>
        /// <param name="retentionPolicy"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public async Task<IInfluxDataApiResponse> WriteAsync(Point point, string dbName = "", string retentionPolicy = "", string precision = "ms")
        {
            if (dbName == null)
            {
                dbName = _clientOptions.DbName;
            }

            return await _basicClientModule.WriteAsync(point, dbName, retentionPolicy, precision);
        }

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="points"></param>
        /// <param name="dbName"></param>
        /// <param name="retentionPolicy"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public async Task<IInfluxDataApiResponse> WriteAsync(IEnumerable<Point> points, string dbName = "", string retentionPolicy = "", string precision = "ms")
        {
            if (dbName == null)
            {
                dbName = _clientOptions.DbName;
            }

            return await _basicClientModule.WriteAsync(points, dbName, retentionPolicy, precision);
        }
    }
}
