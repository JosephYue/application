using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace Application.Frame.Extension.Common
{
    public class OptionCommon
    {
        #region 获取Option的内容信息

        /// <summary>
        /// 获取Option的内容信息（项目未初始化完成之前无法使用）
        /// Startup内:无法使用
        /// Program内:无法使用
        /// </summary>
        /// <typeparam name="TOption">Option的泛型</typeparam>
        /// <returns></returns>
        public static TOption GetOption<TOption>() where TOption : class, new()
        {
            var option = ServiceProviderCommon.GetServiceProvider()?.GetService<IOptions<TOption>>();

            if (option is null)
            {
                return new TOption();
            }

            return option.Value;
        }

        /// <summary>
        /// 获取Option的内容信息（项目未初始化完成之前无法使用）
        /// Startup内:无法使用
        /// Program内:无法使用
        /// </summary>
        /// <param name="type">Option的Type 例：typeof(xxxOption)</param>
        /// <returns></returns>
        public static object? GetOption(Type type)
        {
            if (!type.IsClass)
            {
                return null;
            }

            return FrameContainer.Options.Where(x => x.Key == type).Select(x => x.Value).FirstOrDefault() ?? Activator.CreateInstance(type);
        }

        #endregion
    }
}
