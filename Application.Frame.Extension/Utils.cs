using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace Application.Frame.Extension
{
    /// <summary>
    /// 内部工具类
    /// </summary>
    internal static class Utils
    {
        #region 微软源代码（绑定Configuration.GetSection获取的字符串到反射生成的一个对象）

        /// <summary>
        /// 绑定实体
        /// </summary>
        /// <param name="type">需要绑定的实体的类型</param>
        /// <param name="instance">实体对象</param>
        /// <param name="config">IConfiguration信息通过Configuration.GetSection获取</param>
        /// <param name="options">绑定的配置信息（默认false）</param>
        /// <returns></returns>
        public static object? BindInstance(this Type type, object? instance, IConfiguration config, BinderOptions options)
        {
            if (type == typeof(IConfigurationSection))
            {
                return config;
            }

            var section = config as IConfigurationSection;

            string? configValue = section?.Value;

            if (configValue != null && section != null && TryConvertValue(type, configValue, section.Path, out object? convertedValue, out Exception? error))
            {
                if (error != null)
                {
                    throw error;
                }

                // Leaf nodes are always reinitialized
                return convertedValue;
            }

            if (config != null && config.GetChildren().Any())
            {
                // If we don't have an instance, try to create one
                if (instance == null)
                {
                    // We are already done if binding to a new collection instance worked
                    instance = AttemptBindToCollectionInterfaces(type, config, options);
                    if (instance != null)
                    {
                        return instance;
                    }

                    instance = CreateInstance(type);
                }

                // See if its a Dictionary
                Type collectionInterface = FindOpenGenericInterface(typeof(IDictionary<,>), type);
                if (collectionInterface != null)
                {
                    BindDictionary(instance, collectionInterface, config, options);
                }
                else if (type.IsArray)
                {
                    instance = BindArray((Array)instance, config, options);
                }
                else
                {
                    // See if its an ICollection
                    collectionInterface = FindOpenGenericInterface(typeof(ICollection<>), type);
                    if (collectionInterface != null)
                    {
                        BindCollection(instance, collectionInterface, config, options);
                    }
                    // Something else
                    else
                    {
                        BindNonScalar(config, instance, options);
                    }
                }
            }

            return instance;
        }

        internal static partial class SR
        {
            private static ResourceManager? s_resourceManager;

            internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(SR)));

            /// <summary>Cannot create instance of type '{0}' because it is either abstract or an interface.</summary>
            internal static string @Error_CannotActivateAbstractOrInterface => GetResourceString("Error_CannotActivateAbstractOrInterface", @"Cannot create instance of type '{0}' because it is either abstract or an interface.");
            /// <summary>Failed to convert configuration value at '{0}' to type '{1}'.</summary>
            internal static string @Error_FailedBinding => GetResourceString("Error_FailedBinding", @"Failed to convert configuration value at '{0}' to type '{1}'.");
            /// <summary>Failed to create instance of type '{0}'.</summary>
            internal static string @Error_FailedToActivate => GetResourceString("Error_FailedToActivate", @"Failed to create instance of type '{0}'.");
            /// <summary>'{0}' was set on the provided {1}, but the following properties were not found on the instance of {2}: {3}</summary>
            internal static string @Error_MissingConfig => GetResourceString("Error_MissingConfig", @"'{0}' was set on the provided {1}, but the following properties were not found on the instance of {2}: {3}");
            /// <summary>Cannot create instance of type '{0}' because it is missing a public parameterless constructor.</summary>
            internal static string @Error_MissingParameterlessConstructor => GetResourceString("Error_MissingParameterlessConstructor", @"Cannot create instance of type '{0}' because it is missing a public parameterless constructor.");
            /// <summary>Cannot create instance of type '{0}' because multidimensional arrays are not supported.</summary>
            internal static string @Error_UnsupportedMultidimensionalArray => GetResourceString("Error_UnsupportedMultidimensionalArray", @"Cannot create instance of type '{0}' because multidimensional arrays are not supported.");

        }

        internal static partial class SR
        {
            private static readonly bool s_usingResourceKeys = AppContext.TryGetSwitch("System.Resources.UseSystemResourceKeys", out bool usingResourceKeys) ? usingResourceKeys : false;

            // This method is used to decide if we need to append the exception message parameters to the message when calling SR.Format.
            // by default it returns the value of System.Resources.UseSystemResourceKeys AppContext switch or false if not specified.
            // Native code generators can replace the value this returns based on user input at the time of native code generation.
            // The Linker is also capable of replacing the value of this method when the application is being trimmed.
            private static bool UsingResourceKeys() => s_usingResourceKeys;

            internal static string GetResourceString(string resourceKey)
            {
                if (UsingResourceKeys())
                {
                    return resourceKey;
                }

                string? resourceString = null;
                try
                {
                    resourceString =
#if SYSTEM_PRIVATE_CORELIB
                    InternalGetResourceString(resourceKey);
#else
                    ResourceManager.GetString(resourceKey);
#endif
                }
                catch (MissingManifestResourceException) { }

                return resourceString!; // only null if missing resources
            }

            internal static string GetResourceString(string resourceKey, string defaultString)
            {
                string resourceString = GetResourceString(resourceKey);

                return resourceKey == resourceString || resourceString == null ? defaultString : resourceString;
            }

            internal static string Format(string resourceFormat, object? p1)
            {
                if (UsingResourceKeys())
                {
                    return string.Join(", ", resourceFormat, p1);
                }

                return string.Format(resourceFormat, p1);
            }

            internal static string Format(string resourceFormat, object? p1, object? p2)
            {
                if (UsingResourceKeys())
                {
                    return string.Join(", ", resourceFormat, p1, p2);
                }

                return string.Format(resourceFormat, p1, p2);
            }

            internal static string Format(string resourceFormat, object? p1, object? p2, object? p3)
            {
                if (UsingResourceKeys())
                {
                    return string.Join(", ", resourceFormat, p1, p2, p3);
                }

                return string.Format(resourceFormat, p1, p2, p3);
            }

            internal static string Format(string resourceFormat, params object?[]? args)
            {
                if (args != null)
                {
                    if (UsingResourceKeys())
                    {
                        return resourceFormat + ", " + string.Join(", ", args);
                    }

                    return string.Format(resourceFormat, args);
                }

                return resourceFormat;
            }

            internal static string Format(IFormatProvider? provider, string resourceFormat, object? p1)
            {
                if (UsingResourceKeys())
                {
                    return string.Join(", ", resourceFormat, p1);
                }

                return string.Format(provider, resourceFormat, p1);
            }

            internal static string Format(IFormatProvider? provider, string resourceFormat, object? p1, object? p2)
            {
                if (UsingResourceKeys())
                {
                    return string.Join(", ", resourceFormat, p1, p2);
                }

                return string.Format(provider, resourceFormat, p1, p2);
            }

            internal static string Format(IFormatProvider? provider, string resourceFormat, object? p1, object? p2, object? p3)
            {
                if (UsingResourceKeys())
                {
                    return string.Join(", ", resourceFormat, p1, p2, p3);
                }

                return string.Format(provider, resourceFormat, p1, p2, p3);
            }

            internal static string Format(IFormatProvider? provider, string resourceFormat, params object?[]? args)
            {
                if (args != null)
                {
                    if (UsingResourceKeys())
                    {
                        return resourceFormat + ", " + string.Join(", ", args);
                    }

                    return string.Format(provider, resourceFormat, args);
                }

                return resourceFormat;
            }
        }

        private static bool TryConvertValue(Type? type, string value, string path, out object? result, out Exception? error)
        {
            error = null;
            result = null;

            if (type is null)
            {
                return false;
            }

            if (type == typeof(object))
            {
                result = value;
                return true;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (string.IsNullOrEmpty(value))
                {
                    return true;
                }
                return TryConvertValue(Nullable.GetUnderlyingType(type), value, path, out result, out error);
            }

            TypeConverter converter = TypeDescriptor.GetConverter(type);
            if (converter.CanConvertFrom(typeof(string)))
            {
                try
                {
                    result = converter.ConvertFromInvariantString(value);
                }
                catch (Exception ex)
                {
                    error = new InvalidOperationException(SR.Format(SR.Error_FailedBinding, path, type), ex);
                }
                return true;
            }

            if (type == typeof(byte[]))
            {
                try
                {
                    result = Convert.FromBase64String(value);
                }
                catch (FormatException ex)
                {
                    error = new InvalidOperationException(SR.Format(SR.Error_FailedBinding, path, type), ex);
                }
                return true;
            }

            return false;
        }

        private static object? AttemptBindToCollectionInterfaces(Type type, IConfiguration config, BinderOptions options)
        {
            if (!type.IsInterface)
            {
                return null;
            }

            Type collectionInterface = FindOpenGenericInterface(typeof(IReadOnlyList<>), type);
            if (collectionInterface != null)
            {
                // IEnumerable<T> is guaranteed to have exactly one parameter
                return BindToCollection(type, config, options);
            }

            collectionInterface = FindOpenGenericInterface(typeof(IReadOnlyDictionary<,>), type);
            if (collectionInterface != null)
            {
                Type dictionaryType = typeof(Dictionary<,>).MakeGenericType(type.GenericTypeArguments[0], type.GenericTypeArguments[1]);
                object? instance = Activator.CreateInstance(dictionaryType);
                BindDictionary(instance, dictionaryType, config, options);
                return instance;
            }

            collectionInterface = FindOpenGenericInterface(typeof(IDictionary<,>), type);
            if (collectionInterface != null)
            {
                object? instance = Activator.CreateInstance(typeof(Dictionary<,>).MakeGenericType(type.GenericTypeArguments[0], type.GenericTypeArguments[1]));
                BindDictionary(instance, collectionInterface, config, options);
                return instance;
            }

            collectionInterface = FindOpenGenericInterface(typeof(IReadOnlyCollection<>), type);
            if (collectionInterface != null)
            {
                // IReadOnlyCollection<T> is guaranteed to have exactly one parameter
                return BindToCollection(type, config, options);
            }

            collectionInterface = FindOpenGenericInterface(typeof(ICollection<>), type);
            if (collectionInterface != null)
            {
                // ICollection<T> is guaranteed to have exactly one parameter
                return BindToCollection(type, config, options);
            }

            collectionInterface = FindOpenGenericInterface(typeof(IEnumerable<>), type);
            if (collectionInterface != null)
            {
                // IEnumerable<T> is guaranteed to have exactly one parameter
                return BindToCollection(type, config, options);
            }

            return null;
        }

        private static object BindToCollection(Type type, IConfiguration config, BinderOptions options)
        {
            Type genericType = typeof(List<>).MakeGenericType(type.GenericTypeArguments[0]);
            object? instance = Activator.CreateInstance(genericType);
            BindCollection(instance, genericType, config, options);

            if (instance is null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            return instance;
        }

        private static Array BindArray(Array source, IConfiguration config, BinderOptions options)
        {
            IConfigurationSection[] children = config.GetChildren().ToArray();
            int arrayLength = source.Length;
            Type? elementType = source.GetType().GetElementType();

            if (elementType is null)
            {
                throw new ArgumentNullException(nameof(elementType));
            }

            var newArray = Array.CreateInstance(elementType, arrayLength + children.Length);

            // binding to array has to preserve already initialized arrays with values
            if (arrayLength > 0)
            {
                Array.Copy(source, newArray, arrayLength);
            }

            for (int i = 0; i < children.Length; i++)
            {
                try
                {
                    object? item = BindInstance(
                        type: elementType,
                        instance: null,
                        config: children[i],
                        options: options);

                    if (item != null)
                    {
                        newArray.SetValue(item, arrayLength + i);
                    }
                }
                catch
                {
                }
            }

            return newArray;
        }

        private static void BindCollection(object? collection, Type collectionType, IConfiguration config, BinderOptions options)
        {
            // ICollection<T> is guaranteed to have exactly one parameter
            Type itemType = collectionType.GenericTypeArguments[0];
            MethodInfo? addMethod = collectionType.GetMethod("Add", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (IConfigurationSection section in config.GetChildren())
            {
                try
                {
                    object? item = BindInstance(
                        type: itemType,
                        instance: null,
                        config: section,
                        options: options);

                    if (item != null)
                    {
                        addMethod?.Invoke(collection, new[] { item });
                    }
                }
                catch
                {
                }
            }
        }

        private static object CreateInstance(Type type)
        {
            if (type.IsInterface || type.IsAbstract)
            {
                throw new InvalidOperationException(SR.Format(SR.Error_CannotActivateAbstractOrInterface, type));
            }

            if (type.IsArray)
            {
                if (type.GetArrayRank() > 1)
                {
                    throw new InvalidOperationException(SR.Format(SR.Error_UnsupportedMultidimensionalArray, type));
                }

                var elementType = type.GetElementType();

                if (elementType is null)
                {
                    throw new ArgumentNullException(nameof(elementType));
                }

                return Array.CreateInstance(elementType, 0);
            }

            if (!type.IsValueType)
            {
                bool hasDefaultConstructor = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly).Any(ctor => ctor.IsPublic && ctor.GetParameters().Length == 0);
                if (!hasDefaultConstructor)
                {
                    throw new InvalidOperationException(SR.Format(SR.Error_MissingParameterlessConstructor, type));
                }
            }

            try
            {
                return Activator.CreateInstance(type) ?? throw new ArgumentNullException(nameof(type));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(SR.Format(SR.Error_FailedToActivate, type), ex);
            }
        }

        private static void BindNonScalar(this IConfiguration configuration, object instance, BinderOptions options)
        {
            if (instance != null)
            {
                List<PropertyInfo> modelProperties = GetAllProperties(instance.GetType());

                foreach (PropertyInfo property in modelProperties)
                {
                    BindProperty(property, instance, configuration, options);
                }
            }
        }

        private static List<PropertyInfo> GetAllProperties(Type type)
        {
            var allProperties = new List<PropertyInfo>();

            if (type is null)
            {
                return allProperties;
            }

            do
            {
                allProperties.AddRange(type?.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly)!);
                type = type?.BaseType!;
            }
            while (type != typeof(object));

            return allProperties;
        }

        private static void BindProperty(PropertyInfo property, object instance, IConfiguration config, BinderOptions options)
        {
            // We don't support set only, non public, or indexer properties
            if (property.GetMethod == null ||
                (!options.BindNonPublicProperties && !property.GetMethod.IsPublic) ||
                property.GetMethod.GetParameters().Length > 0)
            {
                return;
            }

            object? propertyValue = property.GetValue(instance);
            bool hasSetter = property.SetMethod != null && (property.SetMethod.IsPublic || options.BindNonPublicProperties);

            if (propertyValue == null && !hasSetter)
            {
                // Property doesn't have a value and we cannot set it so there is no
                // point in going further down the graph
                return;
            }

            propertyValue = GetPropertyValue(property, instance, config, options);

            if (propertyValue != null && hasSetter)
            {
                property.SetValue(instance, propertyValue);
            }
        }

        private static object GetPropertyValue(PropertyInfo property, object instance, IConfiguration config, BinderOptions options)
        {
            string propertyName = GetPropertyName(property);
            return BindInstance(
                property.PropertyType,
                property.GetValue(instance),
                config.GetSection(propertyName),
                options)!;
        }

        private static string GetPropertyName(MemberInfo property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            // Check for a custom property name used for configuration key binding
            foreach (var attributeData in property.GetCustomAttributesData())
            {
                // Ensure ConfigurationKeyName constructor signature matches expectations
                if (attributeData.ConstructorArguments.Count != 1)
                {
                    break;
                }

                // Assumes ConfigurationKeyName constructor first arg is the string key name
                string name = attributeData
                    .ConstructorArguments[0]
                    .Value?
                    .ToString()!;

                return !string.IsNullOrWhiteSpace(name) ? name : property.Name;
            }

            return property.Name;
        }

        private static Type FindOpenGenericInterface(Type expected, Type actual)
        {
            if (actual.IsGenericType &&
                actual.GetGenericTypeDefinition() == expected)
            {
                return actual;
            }

            Type[] interfaces = actual.GetInterfaces();
            foreach (Type interfaceType in interfaces)
            {
                if (interfaceType.IsGenericType &&
                    interfaceType.GetGenericTypeDefinition() == expected)
                {
                    return interfaceType;
                }
            }
            return null!;
        }

        private static void BindDictionary(object? dictionary, Type dictionaryType, IConfiguration config, BinderOptions options)
        {
            // IDictionary<K,V> is guaranteed to have exactly two parameters
            Type keyType = dictionaryType.GenericTypeArguments[0];
            Type valueType = dictionaryType.GenericTypeArguments[1];
            bool keyTypeIsEnum = keyType.IsEnum;

            if (keyType != typeof(string) && !keyTypeIsEnum)
            {
                // We only support string and enum keys
                return;
            }

            PropertyInfo? setter = dictionaryType.GetProperty("Item", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly)!;
            foreach (IConfigurationSection child in config.GetChildren())
            {
                object? item = BindInstance(
                    type: valueType,
                    instance: null,
                    config: child,
                    options: options);
                if (item != null)
                {
                    if (keyType == typeof(string))
                    {
                        string key = child.Key;
                        setter.SetValue(dictionary, item, new object[] { key });
                    }
                    else if (keyTypeIsEnum)
                    {
                        object key = Enum.Parse(keyType, child.Key);
                        setter.SetValue(dictionary, item, new object[] { key });
                    }
                }
            }
        }

        #endregion
    }
}
