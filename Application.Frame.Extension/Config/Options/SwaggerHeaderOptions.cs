using Microsoft.OpenApi.Models;
using System;

namespace Application.Frame.Extension.Config.Options
{
    /// <summary>
    /// Swagger的header配置
    /// </summary>
    public class SwaggerHeaderOptions
    {
        /// <summary>
        /// Attribute类型
        /// 加上此Attribute类型的方法都会加上配置的header信息
        /// </summary>
        public Type? AttributeType { get; set; }

        /// <summary>
        /// Api参数配置信息
        /// </summary>
        public OpenApiParameter OpenApiParameter { get; set; } = new OpenApiParameter();
    }
}
