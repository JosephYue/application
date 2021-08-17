using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Frame.Extension.Config.Options
{
    /// <summary>
    /// Swagger配置信息
    /// </summary>
    public sealed class FrameSwaggerOptions
    {
        /// <summary>
        /// 是否启用Swagger文档
        /// </summary>
        public bool EnableSwagger { get; set; } = true;

        /// <summary>
        /// 默认的swagger页面配置
        /// </summary>
        public SwaggerOpenApiInfo DefaultSwaggerConfig { get; set; } = new SwaggerOpenApiInfo()
        {
            GroupName = "default",
            OpenApiInfo = new OpenApiInfo()
            {
                Description = "Default Open Api",//描述
                Title = "Default Open Api",//标题
                Version = "1.0.0",//版本
            }
        };

        /// <summary>
        /// Swagger的分组配置
        /// </summary>
        public List<SwaggerOpenApiInfo> GroupSwaggerConfigs { get; set; } = new List<SwaggerOpenApiInfo>();

        /// <summary>
        /// Swagger的header配置
        /// </summary>
        public List<SwaggerHeaderOptions> SwaggerHeaderOptions { get; set; } = new List<SwaggerHeaderOptions>();

        /// <summary>
        /// Swagger配置信息
        /// </summary>
        public Action<SwaggerGenOptions>? SwaggerGenOptions { get; set; } = null;

        /// <summary>
        /// SwaggerUI的配置信息
        /// </summary>
        public Action<SwaggerUIOptions>? SwaggerUIOptions { get; set; } = null;

        /// <summary>
        /// XML 描述文件
        /// </summary>
        internal string[] XmlComments 
        {
            get
            {
                var frameworkPackageName = typeof(FrameSwaggerOptions).Assembly.GetName().Name;

                return FrameContainer.Assemblies.Where(u => u.GetName().Name != frameworkPackageName).Select(t => t.GetName().Name).ToArray()!;
            }
        }
    }

    public sealed class SwaggerOpenApiInfo
    {
        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName { get; set; } = string.Empty;

        /// <summary>
        /// 开放的接口信息
        /// </summary>
        public OpenApiInfo OpenApiInfo { get; set; } = new OpenApiInfo();
    }
}
