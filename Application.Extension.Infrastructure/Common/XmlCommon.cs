using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Application.Extension.Infrastructure.Common
{
    /// <summary>
    /// xml方法
    /// </summary>
    public static class XmlCommon
    {
        #region 将XmlDocument转化为string

        /// <summary>
        /// 将XmlDocument转化为string
        /// </summary>
        /// <param name="xmlDoc">xml对象</param>
        /// <returns></returns>
        public static string ConvertXmlToString(XmlDocument xmlDoc)
        {
            MemoryStream stream = new MemoryStream();

            XmlTextWriter writer = new XmlTextWriter(stream, null)
            {
                Formatting = Formatting.Indented
            };

            xmlDoc.Save(writer);
            StreamReader sr = new StreamReader(stream, Encoding.UTF8);
            stream.Position = 0;
            string xmlString = sr.ReadToEnd();
            sr.Close();
            stream.Close();
            return xmlString;
        }

        #endregion

        #region XML序列化

        /// <summary>
        /// XML序列化
        /// </summary>
        /// <typeparam name="T">返回参数</typeparam>
        /// <param name="obj">XML</param>
        /// <returns></returns>
        public static string XMLSerialize<T>(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringWriter writer = new StringWriter(CultureInfo.InvariantCulture);
            serializer.Serialize(writer, obj);
            string xml = writer.ToString();
            writer.Close();
            writer.Dispose();

            return xml;
        }

        #endregion

        #region Xml反序列化

        /// <summary>
        /// Xml反序列化
        /// </summary>
        /// <typeparam name="T">返回参数</typeparam>
        /// <param name="xml">XML</param>
        /// <returns></returns>
        public static T XMLDeserialize<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader reader = new StringReader(xml);
            T result = (T)(serializer.Deserialize(reader));
            reader.Close();
            reader.Dispose();

            return result;
        }

        #endregion
    }
}
