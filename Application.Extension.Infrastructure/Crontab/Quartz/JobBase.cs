using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Threading.Tasks;

namespace Application.Extension.Infrastructure.Crontab.Quartz
{
    public abstract class JobBase : IJob
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public JobBase(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        /// <summary>
        /// 执行定时任务
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Execute(IJobExecutionContext context)
        {
            using var scop = _serviceScopeFactory.CreateScope();
            ServerProvider = scop.ServiceProvider;
            await Processing();
        }

        /// <summary>
        /// 抽象方法 定时任务执行顺序写在此处
        /// </summary>
        /// <returns></returns>
        public abstract Task Processing();

        /// <summary>
        /// 获取服务信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T GetService<T>()
        {
            if (ServerProvider == null)
            {
                throw new ArgumentNullException(nameof(ServerProvider));
            }

#pragma warning disable CS8603 // 可能返回 null 引用。
            return ServerProvider.GetService<T>();
#pragma warning restore CS8603 // 可能返回 null 引用。
        }

        #region Private

        /// <summary>
        /// 服务提供者
        /// </summary>
        IServiceProvider? ServerProvider { get; set; }

        #endregion
    }
}
