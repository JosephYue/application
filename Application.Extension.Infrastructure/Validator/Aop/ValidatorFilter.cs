using Application.Extension.Infrastructure.Exceptions;
using Application.Extension.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Extension.Infrastructure.Validator.Aop
{
    public class ValidatorFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionArguments != null)
            {
                var request = context.ActionArguments.FirstOrDefault();

                var isValid = request.Value.IsValid(out var message);

                if (!isValid)
                {
                    throw new BusinessException(message);
                }
            }

            await next();
        }
    }
}
