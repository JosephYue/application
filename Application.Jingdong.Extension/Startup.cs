using Application.Jingdong.Extension.JingDongAlliance;
using Application.Jingdong.Extension.JingDongAlliance.Interface;
using Application.Jingdong.Extension.JingDongKepler;
using Application.Jingdong.Extension.JingDongKepler.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Jingdong.Extension
{
    public static class Startup
    {
        /// <summary>
        /// 添加京东服务
        /// </summary>
        /// <param name="service">服务集合</param>
        public static void AddJingDongServers(this IServiceCollection service)
        {
            service.AddHttpClient();
            service.AddSingleton<IKeplerServices, KeplerServices>();
            service.AddSingleton<IJdApiServices, JdApiServices>();
        }
    }
}
