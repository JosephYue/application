using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Application.Frame.Extension.Config.Filters
{
    /// <summary>
    /// 枚举过滤器
    /// </summary>
    public class EnumSchemaFilter : ISchemaFilter
    {
        /// <summary>
        /// 实现过滤器方法
        /// </summary>
        /// <param name="model"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiSchema model, SchemaFilterContext context)
        {
            var type = context.Type;

            // 排除其他程序集的枚举
            if (type.IsEnum && FrameContainer.Assemblies.ToList().Contains(type.Assembly))
            {
                model.Enum.Clear();
                var stringBuilder = new StringBuilder();
                stringBuilder.Append($"{model.Description}<br />");

                var enumValues = Enum.GetValues(type);
                foreach (var value in enumValues)
                {
                    if (value==null)
                    {
                        continue;
                    }

                    // 获取枚举成员特性
                    var fieldinfo = type.GetField(Enum.GetName(type, value)!);
                    var descriptionAttribute = fieldinfo?.GetCustomAttribute<DescriptionAttribute>(true);
                    model.Enum.Add(OpenApiAnyFactory.CreateFromJson(JsonConvert.SerializeObject(value)));

                    stringBuilder.Append($"&nbsp;{descriptionAttribute?.Description} {value} = {(TryToInt(value, out int number) ? number : value)}<br />");
                }
                model.Description = stringBuilder.ToString();
            }

            //本地函数
            static bool TryToInt(object obj, out int result)
            {
                try
                {
                    result = Convert.ToInt32(obj);
                    return true;
                }
                catch
                {
                    result = 0;
                    return false;
                }
            }
        }
    }
}
