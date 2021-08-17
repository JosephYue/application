using System;

namespace Application.Extension.Infrastructure.Crontab.Quartz.Attributes
{
    /// <summary>
    /// 定时任务验证类
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class JobAttribute : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">定时任务名称</param>
        /// <param name="group">定时任务分组</param>
        /// <param name="cornExpression">定时任务corn表达式</param>
        public JobAttribute(string name,
            string group,
            string cornExpression)
        {
            Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException("请检查定时任务名称") : name;
            Group = string.IsNullOrWhiteSpace(group) ? throw new ArgumentNullException("请检查定时任务分组") : group;
            CornExpression = string.IsNullOrWhiteSpace(cornExpression) ? throw new ArgumentNullException("请检查定时任务Corn表达式") : cornExpression;
        }

        /// <summary>
        /// 定时任务名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 定时任务分组
        /// </summary>
        public string Group { get; private set; }

        /// <summary>
        /// 定时任务Corn表达式
        /// </summary>
        public string CornExpression { get; private set; }
    }
}
