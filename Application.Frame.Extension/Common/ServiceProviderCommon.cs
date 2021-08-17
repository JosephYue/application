using System;

namespace Application.Frame.Extension.Common
{
    /// <summary>
    /// 服务提供者公共方法（项目未初始化完成之前无法使用）
    /// Startup内:无法使用
    /// Program内:无法使用
    /// </summary>
    public class ServiceProviderCommon
    {
        /// <summary>
        /// 获取IServiceProvider
        /// </summary>
        /// <returns></returns>
        public static IServiceProvider? GetServiceProvider()
        {
            return FrameContainer.ServiceProvider ?? null;
        }
    }
}
