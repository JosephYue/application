using FluentValidation;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Application.Extension.Infrastructure.Validator
{
    public static class Validator
    {
        private static readonly object Locker = new object();

        private static ConcurrentDictionary<string, IValidator> _cacheValidators=new ConcurrentDictionary<string, IValidator>();

        /// <summary>
        /// 注册验证信息
        /// </summary>
        public static void Register()
        {
            lock (Locker)
            {
                if (_cacheValidators == null)
                {
                    _cacheValidators = new ConcurrentDictionary<string, IValidator>();

                    foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                    {
                        var types = assembly.GetTypes().Where(x => x.IsPublic && x.BaseType != null && x.BaseType.Name == typeof(AbstractValidator<>).Name && x.BaseType.FullName != null).ToList();

                        if (types.Count > 0)
                        {
                            foreach (var type in types)
                            {
                                if (type != null)
                                {
                                    var baseType = type.BaseType?.GetGenericArguments().FirstOrDefault();

                                    if (baseType != null)
                                    {
                                        var obj = Activator.CreateInstance(type);

                                        if (obj != null)
                                        {
                                            IValidator validator = (IValidator)obj;

                                            _cacheValidators.TryAdd(baseType.FullName ?? string.Empty, validator);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 验证是否成功
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        internal static bool IsValid<T>(this T request, out string msg) where T : class
        {
            msg = string.Empty;

            if (request is null)
            {
                return true;
            }

            if (_cacheValidators == null || !_cacheValidators.TryGetValue(request.GetType().FullName ?? string.Empty, out IValidator? validator))
            {
                return true;
            }

            var result = validator.Validate(new ValidationContext<T>(request));

            if (!result.IsValid)
            {
                // 返回第一个错误信息
                msg = result.Errors[0].ErrorMessage;

                return false;
            }

            return true;
        }
    }
}
