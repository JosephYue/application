using Application.Extension.Infrastructure.Crontab.Quartz.Attributes;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Extension.Infrastructure.Crontab.Quartz
{
    /// <summary>
    /// 定时任务job服务
    /// </summary>
    public class JobHostedService : IHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IScheduler _scheduler;
        public JobHostedService(ISchedulerFactory schedulerFactory,
            IJobFactory jobFactory)
        {
            _schedulerFactory = schedulerFactory;

            #region 生成自己的调度器

            _scheduler = _schedulerFactory.GetScheduler().Result;
            _scheduler.JobFactory = jobFactory;

            #endregion
        }

        #region 生命周期线程开始方法

        /// <summary>
        /// 生命周期线程开始方法
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            //启动Quartz调度
            await _scheduler.Start(cancellationToken);

            var assembly = Assembly.GetEntryAssembly()!;

            var jobs = assembly.DefinedTypes.Where(r => r.IsClass && typeof(IJob).IsAssignableFrom(r)).ToList();

            var taskCount = jobs.Count();

            Task[] tasks = new Task[taskCount];

            for (int i = 0; i < taskCount; i++)
            {
                var job = jobs[i];

                tasks[i] = Task.Run(() =>
                {
                    var jobAttribute = job.GetCustomAttribute<JobAttribute>();

                    if (jobAttribute != null)
                    {
                        //3、创建一个触发器
                        var builder = TriggerBuilder.Create();
                        if (string.IsNullOrEmpty(jobAttribute.CornExpression))
                        {
                            builder.WithSimpleSchedule();
                        }
                        else
                        {
                            builder.WithCronSchedule(jobAttribute.CornExpression);
                        }
                        var trigger = builder.Build();

                        //4、创建任务
                        var jobDetail = JobBuilder.Create(job.AsType())
                                        .WithIdentity(jobAttribute.Name, jobAttribute.Group)
                                        .Build();

                        //5、将触发器和任务器绑定到调度器中
                        _scheduler.ScheduleJob(jobDetail, trigger, cancellationToken).GetAwaiter();
                    }
                });
            }

            Task.WaitAll(tasks);
        }

        #endregion

        #region 生命周期线程结束方法

        /// <summary>
        /// 生命周期线程结束方法
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _scheduler.Shutdown(cancellationToken);
        }

        #endregion
    }
}
