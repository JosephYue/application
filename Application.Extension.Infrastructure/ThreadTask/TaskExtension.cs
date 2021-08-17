using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Extension.Infrastructure.ThreadTask
{
    public static class TaskExtension
    {
        /// <summary>
        /// 执行任务（快速执行任务委托，简化重复代码）
        /// </summary>
        /// <param name="tasks">任务集合</param>
        public static void ExecuteTasks(this List<Action> tasks)
        {
            var taskCount = tasks.Count();

            var therdTasks = new Task[taskCount];

            for (int i = 0; i < taskCount; i++)
            {
                therdTasks[i] = Task.Run(tasks[i]);
            }

            Task.WaitAll(therdTasks);
        }
    }
}
