using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Application.Frame.Extension.Config.Filters
{
    /// <summary>
    /// Startup 中间件
    /// </summary>
    internal class ActionMiddlewareStartupFilter : IStartupFilter
    {
        private readonly Action<IApplicationBuilder> _middlewareDelegate;
        private readonly bool _pre;//是否在管道前运行

        /// <summary>
        /// Startup 中间件
        /// </summary>
        /// <param name="middlewareDelegate">中间件委托</param>
        /// <param name="pre">是否前置（标识注册的管道在之前执行还是之后执行）</param>
        public ActionMiddlewareStartupFilter(Action<IApplicationBuilder> middlewareDelegate, bool pre = true)
        {
            _middlewareDelegate = middlewareDelegate;
            if (middlewareDelegate == null)
            {
                throw new ArgumentNullException(nameof(middlewareDelegate));
            }
            _pre = pre;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            //管道执行顺序
            //放在 next(app)之前的代码 先执行
            //放在 next(app)之后的代码 后执行

            return (app) =>
            {
                if (_pre) next(app);

                _middlewareDelegate.Invoke(app);

                if (!_pre) next(app);

                //注册全局静态变量
                FrameContainer.ServiceProvider = app.ApplicationServices;
            };
        }
    }
}
