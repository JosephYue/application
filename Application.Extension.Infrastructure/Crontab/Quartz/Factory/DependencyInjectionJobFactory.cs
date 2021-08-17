using Quartz;
using Quartz.Spi;
using System;

namespace Application.Extension.Infrastructure.Crontab.Quartz.Factory
{
    internal class DependencyInjectionJobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DependencyInjectionJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 创建一个新任务
        /// </summary>
        /// <param name="bundle">触发器</param>
        /// <param name="scheduler">调度器</param>
        /// <returns></returns>
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
#pragma warning disable CS8603 // 可能返回 null 引用。
            return _serviceProvider.GetService(bundle.JobDetail.JobType) as IJob;
#pragma warning restore CS8603 // 可能返回 null 引用。
        }

        #region 释放任务

        /// <summary>
        /// 释放任务
        /// </summary>
        /// <param name="job">任务</param>
        public void ReturnJob(IJob job)
        {
            var disposable = job as IDisposable;
            disposable?.Dispose();
        }

        #endregion
    }
}
