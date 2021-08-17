using Application.SqlSugar.Extension.Interface;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Application.SqlSugar.Extension.Config.Auth
{
    /// <summary>
    /// SqlSugar事务
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class SqlSugarTransactionAttribute : Attribute, IFilterFactory
    {
        /// <summary>
        /// 获取一个值，该值指示是否 CreateInstance(IServiceProvider) 可以在请求之间重复使用结果。
        /// </summary>
        public bool IsReusable => false;

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <param name="serviceProvider">服务提供者</param>
        /// <returns></returns>
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new TransactionFilter(serviceProvider.GetService<IUnitOfWork>());
        }
    }

    /// <summary>
    /// 事务过滤器
    /// </summary>
    internal class TransactionFilter : IAsyncActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _unitOfWork.BeginTran();

            var result = await next();

            if (result.Exception != null)
            {
                _unitOfWork.RollbackTran();

                return;
            }

            _unitOfWork.CommitTran();
        }
    }
}
