using Application.Extension.Infrastructure.Http.RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Application.Extension.Infrastructure.Common
{
    /// <summary>
    /// 流信息基础操作
    /// </summary>
    public static class StreamCommon
    {
        #region 流信息基础操作

        /// <summary>
        /// 根据文件内容得到内容后缀。
        /// </summary>
        /// <param name="bytes">文件内容。</param>
        /// <returns>内容类型（例：.jpg）。</returns>
        public static string GetFileSuffix(this byte[] bytes)
        {
            var fileCode = GetFileCode(bytes);
            var item = FileFormats.First(i => i.Value.Equals(fileCode));
            var extensions = item.Key;
            return ContentTypeExtensionsMapping.ContainsKey(extensions)
                ? extensions
                : string.Empty;
        }

        /// <summary>
        /// 根据文件内容得到内容类型。
        /// </summary>
        /// <param name="bytes">文件内容。</param>
        /// <returns>内容类型（例：image/jpeg）。</returns>
        public static string GetContentType(this byte[] bytes)
        {
            var fileCode = GetFileCode(bytes);
            var item = FileFormats.First(i => i.Value.Equals(fileCode));
            var extensions = item.Key;
            return ContentTypeExtensionsMapping.ContainsKey(extensions)
                ? ContentTypeExtensionsMapping.Where(x => x.Key == extensions).Select(x => x.Value).FirstOrDefault()
                : string.Empty;
        }

        /// <summary>
        /// 获取一个随机的文件名称。
        /// </summary>
        /// <param name="data">文件字节组（主要用来得到文件扩展名）。</param>
        /// <returns>一个随机的文件名称。</returns>
        public static string GetRandomFileName(this byte[] data)
        {
            var fileCode = GetFileCode(data);
            var item = FileFormats.First(i => i.Value.Equals(fileCode));
            return Guid.NewGuid().ToString("n") + item.Key;
        }

        private static string GetFileCode(byte[] bytes)
        {
            return bytes[0].ToString(CultureInfo.InvariantCulture) + bytes[1];
        }

        #endregion

        #region 基本配置字段

        private static readonly IDictionary<string, string> FileFormats = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {".gif","7173"},
            {".jpg","255216"},
            {".jpeg","255216"},
            {".png","13780"},
            {".bmp","6677"},
            {".swf","6787"},
            {".flv", "7076"},
            {".wma","4838"},
            {".wav","8273"},
            {".amr","3533"},
            {".mp4","00"},
            {".mp3","255251"},
            {".pdf","3780" },
            {".txt","12334" },
            {".zip","8297"},
        };

        private static readonly IDictionary<string, string> ContentTypeExtensionsMapping = new Dictionary<string, string>
        {
            {".gif", "image/gif"},
            {".jpg", "image/jpg"},
            {".jpeg", "image/jpeg"},
            {".png", "image/png"},
            {".bmp", "application/x-bmp"},
            {".mp3", "audio/mp3"},
            {".wma", "audio/x-ms-wma"},
            {".wav", "audio/wav"},
            {".amr", "audio/amr"},
            {".mp4","video/mpeg4"},
            {".xlsx","application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
            {".pdf","application/pdf" },
            {".txt","text/plain" },
            {".doc","application/msword" },
            {".xls","application/vnd.ms-excel" },
            {".zip","aplication/zip" },
            {".csv","text/csv"},
            {".ppt","application/vnd.ms-powerpoint" },
            {".pptx","application/vnd.openxmlformats-officedocument.presentationml.presentation" },
            {".docx","application/vnd.openxmlformats-officedocument.wordprocessingml.document" }
        };

        #endregion

        #region 将 byte[] 转成 Stream

        /// 将 byte[] 转成 Stream
        public static Stream BytesToStream(this byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);

            return stream;
        }

        #endregion

        #region 将Stream转成byte[]

        /// <summary>
        /// 将Stream转成byte[]
        /// </summary>
        /// <param name="stream">stream流信息</param>
        /// <returns></returns>
        public static byte[] StreamToBytes(this Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        #endregion

        #region 从文件读取Stream

        /// <summary>
        /// 从文件读取Stream
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <returns></returns>
        public static Stream FileToStream(this string fileName)
        {
            // 打开文件
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            // 读取文件的 byte[]
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            // 把 byte[] 转换成 Stream
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        #endregion

        #region 从文件读取byte

        /// <summary>
        /// 从文件读取byte
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <returns></returns>
        public static byte[] FileToByte(this string fileName)
        {
            // 打开文件
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            // 读取文件的 byte[]
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            return bytes;
        }

        #endregion

        #region 将Stream写入文件

        /// <summary>
        /// 将Stream写入文件
        /// </summary>
        /// <param name="stream">stream流信息</param>
        /// <param name="fileName">写入的路径</param>
        public static void StreamToFile(this Stream stream, string fileName)
        {
            // 把 Stream 转换成 byte[]
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            // 把 byte[] 写入文件
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }

        #endregion

        #region 将byte写入文件

        /// <summary>
        /// 将Stream写入文件
        /// </summary>
        /// <param name="bytes">byte流信息</param>
        /// <param name="fileName">写入的路径</param>
        public static void ByteToFile(this byte[] bytes, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }

        #endregion

        #region 获取Url的Stream信息

        /// <summary>
        /// 获取Url的Stream信息
        /// </summary>
        /// <param name="url">网站地址</param>
        /// <returns></returns>
        public static Stream UrlToStream(this string url)
        {
            var result = RestSharpClient.Get(url);
            return result.RawBytes.BytesToStream();
        }

        #endregion

        #region 获取Url的Byte信息

        /// <summary>
        /// 获取Url的Byte信息
        /// </summary>
        /// <param name="url">网址信息</param>
        /// <returns></returns>
        public static byte[] UrlToBytes(this string url)
        {
            var result = RestSharpClient.Get(url);
            return result.RawBytes;
        }

        #endregion
    }
}
