using Application.Mongo.Extension.Config.Attributes;
using Application.Mongo.Extension.Config.Options;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Application.Mongo.Extension.Config
{
    /// <summary>
    /// mongodb配置信息
    /// </summary>
    internal class MongoContainer
    {
        /// <summary>
        /// 基础配置
        /// </summary>
        public static MongoConnectionOption? MongoConnectionOption { get; set; }

        /// <summary>
        /// MongoClientSettings配置
        /// </summary>
        public static MongoClientSettingsOption? MongoClientSettingsOption { get; set; }

        /// <summary>
        /// MongoUrl配置
        /// </summary>
        public static MongoUrlOption? MongoUrlOption { get; set; }

        /// <summary>
        /// MongoCollection的名称集合 元组 第一个  CollectionNameAttribute 的name 第二个 当前类型的 Name 
        /// </summary>
        public static Dictionary<Type, string> CollectionNames { get; set; } = new Dictionary<Type, string>();

        /// <summary>
        /// 设置MongoCollection的名称集合
        /// </summary>
        public static void SetCollectionNames()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    var attribute = type.GetCustomAttribute<CollectionNameAttribute>();

                    if (attribute is null)
                    {
                        continue;
                    }

                    CollectionNames.Add(type, attribute.Name);
                }
            }
        }
    }
}
