namespace Application.Extension.Infrastructure.Event.Delegate
{
    /// <summary>
    /// 自定义EventHandler
    /// </summary>
    public class CustomEventHandlers
    {
        /// <summary>
        /// 委托
        /// </summary>
        /// <typeparam name="TEventArgs">泛型类型</typeparam>
        /// <param name="e">参数信息</param>
        public delegate void DomainEventHandler<TEventArgs>(TEventArgs e);
    }
}
