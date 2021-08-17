
using System;

namespace Application.EntityFrameworkCore.Extension.Config.Attributes
{
    /// <summary>
    /// EFCore OnModelCreating 重写标记
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class OnConfiguringAttribute : Attribute
    {
    }
}
