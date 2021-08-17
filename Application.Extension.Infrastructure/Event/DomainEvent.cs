using Application.Extension.Infrastructure.Event.Attributes;
using System;
using System.Linq;

namespace Application.Extension.Infrastructure.Event
{
    /// <summary>
    /// 领域事件
    /// </summary>
    public class DomainEvent
    {
        /// <summary>
        /// 注册领域事件
        /// </summary>
        public static void Register()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    var methods = type.GetMethods().Where(x => (x.IsPublic || x.IsPrivate) && x.CustomAttributes.Any(x => x.AttributeType == typeof(DomainEventAttribute))).ToList();

                    if (methods.Count() > 0)
                    {
                        foreach (var method in methods)
                        {
                            if (method != null)
                            {
                                if (method.DeclaringType != null)
                                {
                                    object? demethodInstance = Activator.CreateInstance(method.DeclaringType);

                                    method.Invoke(demethodInstance, null);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
