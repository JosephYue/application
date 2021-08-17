using System;

namespace Application.Extension.Infrastructure.Event.Attributes
{
    /// <summary>
    /// 事件Attribute 只有带了此标识才会被认为事件（使用此标识需要注册启动 DomainEvent.Enable()）
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class DomainEventAttribute : Attribute
    {

    }
}
