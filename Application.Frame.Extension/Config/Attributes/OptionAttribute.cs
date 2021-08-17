using System;

namespace Application.Frame.Extension.Config.Attributes
{
    /// <summary>
    /// Option标识 带有此标识会被自动识别匹配appsettings.json内的字段
    /// 注：可用构造函数注入，可注入到构造函数中直接使用
    /// 注：假如有多个层级，请将层级路径传入，否则将无法正确识别匹配（例：Logging:LogLevel）
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class OptionAttribute : Attribute
    {
        /// <summary>
        /// 构造函数
        /// 注：假如有多个层级，请将层级路径传入，否则将无法正确识别匹配
        /// </summary>
        /// <param name="url"></param>
        public OptionAttribute(string url)
        {
            Url = url;
        }

        /// <summary>
        /// 路径
        /// </summary>
        public string Url { get; set; }
    }
}
