using Application.Extension.Infrastructure.Storage.Oss.Enum;
using System.Collections.Generic;
using System.IO;

namespace Application.Extension.Infrastructure.Storage.Oss.Interface
{
    /// <summary>
    /// 阿里云Oss上传下载服务
    /// </summary>
    public interface IOssFileServices
    {
        /// <summary>
        /// 拼接域名前缀
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        string GenerateAuthQuery(string url);

        /// <summary>
        /// 移除域名前缀
        /// </summary>
        /// <param name="authQuery"></param>
        /// <returns></returns>
        string RemoveUrlPrefix(string authQuery);

        /// <summary>
        /// 智能上传（假如流类型推断失败请使用指定文件类型上传）
        /// </summary>
        /// <param name="stream">文件流信息</param>
        /// <returns></returns>
        string Upload(Stream stream);

        /// <summary>
        /// 智能上传（假如流类型推断失败请使用指定文件类型上传）
        /// </summary>
        /// <param name="stream">文件流信息</param>
        /// <param name="path">oss文件存储地址</param>
        /// <returns></returns>
        string Upload(Stream stream, string path);

        /// <summary>
        /// 指定文件类型上传
        /// </summary>
        /// <param name="stream">文件流信息</param>
        /// <param name="fileSuffix">文件后缀（例：.jpg）</param>
        /// <param name="contentType">内容类型（例：image/jpeg）</param>
        /// <returns></returns>
        string Upload(Stream stream, string fileSuffix, string contentType);

        /// <summary>
        /// 指定文件类型上传
        /// </summary>
        /// <param name="stream">文件流信息</param>
        /// <param name="path">oss文件存储地址</param>
        /// <param name="fileSuffix">文件后缀（例：.jpg）</param>
        /// <param name="contentType">内容类型（例：image/jpeg）</param>
        /// <returns></returns>
        string Upload(Stream stream, string path, string fileSuffix, string contentType);

        /// <summary>
        /// 指定文件类型上传（部分类型不支持）
        /// </summary>
        /// <param name="stream">文件流信息</param>
        /// <param name="fileType">文件类型</param>
        /// <returns></returns>
        string Upload(Stream stream, FileTypeEnum fileType);

        /// <summary>
        /// 指定文件类型上传（部分类型不支持）
        /// </summary>
        /// <param name="stream">文件流信息</param>
        /// <param name="path">oss文件存储地址</param>
        /// <param name="fileType">文件类型</param>
        /// <returns></returns>
        string Upload(Stream stream, string path, FileTypeEnum fileType);

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Stream Download(string url);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="path"></param>
        void Delete(string path);

        /// <summary>
        /// 删除集合
        /// </summary>
        /// <param name="pathList"></param>
        void BatchDelete(List<string> pathList);

        /// <summary>
        /// 智能转换链接为本平台链接
        /// </summary>
        /// <param name="url">url地址  必须是url地址</param>
        /// <param name="isNeedPrefix">是否需要携带域名前缀</param>
        /// <returns></returns>
        string GetPlatformLink(string url, bool isNeedPrefix = false);

        /// <summary>
        /// 智能转换链接为本平台链接
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="path">oss文件存储地址</param>
        /// <param name="isNeedPrefix">是否需要携带域名前缀</param>
        /// <returns></returns>
        string GetPlatformLink(string url, string path, bool isNeedPrefix = false);
    }
}
