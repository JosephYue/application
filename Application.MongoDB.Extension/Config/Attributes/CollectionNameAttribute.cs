using System;

namespace Application.Mongo.Extension.Config.Attributes
{
    /// <summary>
    /// MongoCollection的Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class CollectionNameAttribute : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">MongoCollection的name</param>
        public CollectionNameAttribute(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
        }

        /// <summary>
        /// MongoCollection的name
        /// </summary>
        public string Name { get; set; }
    }
}
