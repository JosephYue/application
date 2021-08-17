using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace Application.Frame.Extension.Config.Filters
{
    /// <summary>
    /// SwaggerHeader过滤器
    /// </summary>
    public class SwaggerHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null) operation.Parameters = new List<OpenApiParameter>();

            if (context.ApiDescription.ActionDescriptor is ControllerActionDescriptor descriptor)
            {
                if (FrameContainer.FrameSwaggerOptions.SwaggerHeaderOptions.Count <= 0)
                {
                    return;
                }

                foreach (var headerOptions in FrameContainer.FrameSwaggerOptions.SwaggerHeaderOptions)
                {
                    if (headerOptions.AttributeType is null)
                    {
                        continue;
                    }

                    var actionAttributes = descriptor.ControllerTypeInfo?.BaseType?.GetCustomAttributes(headerOptions.AttributeType, true).ToList();

                    actionAttributes?.AddRange(descriptor.MethodInfo.GetCustomAttributes(headerOptions.AttributeType, inherit: true));

                    bool isAnonymous = actionAttributes.Any(a => a is AllowAnonymousAttribute);

                    //非匿名的方法,链接中添加accesstoken值
                    if (!isAnonymous && actionAttributes.Any(x => x.GetType() == headerOptions.AttributeType))
                    {
                        operation.Parameters.Add(headerOptions.OpenApiParameter);
                    }
                }
            }
        }
    }
}
