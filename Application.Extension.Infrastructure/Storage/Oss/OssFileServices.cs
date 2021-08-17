using Aliyun.OSS;
using Aliyun.OSS.Common;
using Application.Extension.Infrastructure.Common;
using Application.Extension.Infrastructure.Exceptions;
using Application.Extension.Infrastructure.Http.RestSharp;
using Application.Extension.Infrastructure.Storage.Oss.Enum;
using Application.Extension.Infrastructure.Storage.Oss.Interface;
using Application.Extension.Infrastructure.Storage.Oss.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;

namespace Application.Extension.Infrastructure.Storage.Oss
{
    /// <summary>
    /// 阿里云Oss上传下载服务
    /// </summary>
    public class OssFileServices : IOssFileServices
    {
        private readonly AliyunOssOptions _aliyunOssOption;

        public OssFileServices(IOptions<AliyunOssOptions> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(AliyunOssOptions));
            }

            _aliyunOssOption = options.Value;
        }

        #region 生成Url授权

        /// <summary>
        /// 生成Url授权
        /// </summary>
        /// <param name="url">文件存储路径</param>
        /// <returns></returns>
        public string GenerateAuthQuery(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return string.Empty;
            }

            if (_aliyunOssOption.IsPresignedUri)
            {
                return OssClient.GeneratePresignedUri(_aliyunOssOption.AliyunBucketName,
                        url, Utils.GetDateTime().AddHours(1), SignHttpMethod.Get).AbsoluteUri;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(_aliyunOssOption.DownEndPoint))
                {
                    return "https://" + _aliyunOssOption.DownEndPoint + "/" + url;
                }
                else
                {
                    return "https://" + _aliyunOssOption.AliyunBucketName + "." + _aliyunOssOption.AliyunEndPoint + "/" + url;
                }
            }
        }

        #endregion

        #region 去除url前缀

        /// <summary>
        /// 去除url前缀（域名和endpoint）
        /// </summary>
        /// <param name="authQuery"></param>
        /// <returns></returns>
        public string RemoveUrlPrefix(string authQuery)
        {
            if (string.IsNullOrWhiteSpace(authQuery))
            {
                return string.Empty;
            }

            if (!string.IsNullOrWhiteSpace(_aliyunOssOption.DownEndPoint))
            {
                authQuery = authQuery.Replace("https://" + _aliyunOssOption.DownEndPoint + "/", "");
            }
            else
            {
                authQuery = authQuery.Replace("https://" + _aliyunOssOption.AliyunBucketName + "." + _aliyunOssOption.AliyunEndPoint + "/", "");
            }

            return authQuery;
        }

        #endregion

        #region 上传

        /// <summary>
        /// 智能上传（假如流类型推断失败请使用指定文件类型上传）
        /// </summary>
        /// <param name="stream">文件流信息</param>
        /// <returns></returns>
        public string Upload(Stream stream)
        {
            var bytes = stream.StreamToBytes();

            var path = GetPath(_aliyunOssOption.AliyunPrefix, bytes.GetFileSuffix());
            try
            {
                OssClient.PutObject(_aliyunOssOption.AliyunBucketName,
                    path,
                    stream,
                    new ObjectMetadata
                    {
                        ExpirationTime = DateTime.MaxValue,
                        CacheControl = "No-Cache",
                        ContentType = bytes.GetContentType()
                    });
            }
            catch (OssException ex)
            {
                throw new BusinessException(
                    $"上传文件失败，错误码: {ex.ErrorCode}; 错误原因: {ex.Message}. \nRequestID:{ex.RequestId}\tHostID:{ex.HostId}");
            }
            catch (Exception e)
            {
                throw new BusinessException("上传文件失败,详细错误原因:" + e.Message);
            }

            return path;
        }

        /// <summary>
        /// 智能上传（假如流类型推断失败请使用指定文件类型上传）
        /// </summary>
        /// <param name="stream">文件流信息</param>
        /// <param name="path">oss文件存储地址</param>
        /// <returns></returns>
        public string Upload(Stream stream, string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            var bytes = stream.StreamToBytes();

            try
            {
                OssClient.PutObject(_aliyunOssOption.AliyunBucketName,
                    path,
                    stream,
                    new ObjectMetadata
                    {
                        ExpirationTime = DateTime.MaxValue,
                        CacheControl = "No-Cache",
                        ContentType = bytes.GetContentType()
                    });
            }
            catch (OssException ex)
            {
                throw new BusinessException(
                    $"上传文件失败，错误码: {ex.ErrorCode}; 错误原因: {ex.Message}. \nRequestID:{ex.RequestId}\tHostID:{ex.HostId}");
            }
            catch (Exception e)
            {
                throw new BusinessException("上传文件失败,详细错误原因:" + e.Message);
            }

            return path;
        }

        /// <summary>
        /// 指定文件类型上传
        /// </summary>
        /// <param name="stream">文件流信息</param>
        /// <param name="fileSuffix">文件后缀（例：.jpg）</param>
        /// <param name="contentType">内容类型（例：image/jpeg）</param>
        /// <returns></returns>
        public string Upload(Stream stream, string fileSuffix, string contentType)
        {

            var path = GetPath(_aliyunOssOption.AliyunPrefix, fileSuffix);
            try
            {
                OssClient.PutObject(_aliyunOssOption.AliyunBucketName,
                    path,
                    stream,
                    new ObjectMetadata
                    {
                        ExpirationTime = DateTime.MaxValue,
                        CacheControl = "No-Cache",
                        ContentType = contentType
                    });
            }
            catch (OssException ex)
            {
                throw new BusinessException(
                    $"上传文件失败，错误码: {ex.ErrorCode}; 错误原因: {ex.Message}. \nRequestID:{ex.RequestId}\tHostID:{ex.HostId}");
            }
            catch (Exception e)
            {
                throw new BusinessException("上传文件失败,详细错误原因:" + e.Message);
            }

            return path;
        }

        /// <summary>
        /// 指定文件类型上传
        /// </summary>
        /// <param name="stream">文件流信息</param>
        /// <param name="path">oss文件存储地址</param>
        /// <param name="fileSuffix">文件后缀（例：.jpg）</param>
        /// <param name="contentType">内容类型（例：image/jpeg）</param>
        /// <returns></returns>
        public string Upload(Stream stream, string path, string fileSuffix, string contentType)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            try
            {
                OssClient.PutObject(_aliyunOssOption.AliyunBucketName,
                    path,
                    stream,
                    new ObjectMetadata
                    {
                        ExpirationTime = DateTime.MaxValue,
                        CacheControl = "No-Cache",
                        ContentType = contentType
                    });
            }
            catch (OssException ex)
            {
                throw new BusinessException(
                    $"上传文件失败，错误码: {ex.ErrorCode}; 错误原因: {ex.Message}. \nRequestID:{ex.RequestId}\tHostID:{ex.HostId}");
            }
            catch (Exception e)
            {
                throw new BusinessException("上传文件失败,详细错误原因:" + e.Message);
            }

            return path;
        }

        /// <summary>
        /// 指定文件类型上传（部分类型不支持）
        /// </summary>
        /// <param name="stream">文件流信息</param>
        /// <param name="fileType">文件类型</param>
        /// <returns></returns>
        public string Upload(Stream stream, FileTypeEnum fileType)
        {
            var (fileSuffix, contentType) = GetFileTypeInfo(fileType);

            var path = GetPath(_aliyunOssOption.AliyunPrefix, fileSuffix);

            try
            {
                OssClient.PutObject(_aliyunOssOption.AliyunBucketName,
                    path,
                    stream,
                    new ObjectMetadata
                    {
                        ExpirationTime = DateTime.MaxValue,
                        CacheControl = "No-Cache",
                        ContentType = contentType
                    });
            }
            catch (OssException ex)
            {
                throw new BusinessException(
                    $"上传文件失败，错误码: {ex.ErrorCode}; 错误原因: {ex.Message}. \nRequestID:{ex.RequestId}\tHostID:{ex.HostId}");
            }
            catch (Exception e)
            {
                throw new BusinessException("上传文件失败,详细错误原因:" + e.Message);
            }

            return path;
        }

        /// <summary>
        /// 指定文件类型上传（部分类型不支持）
        /// </summary>
        /// <param name="stream">文件流信息</param>
        /// <param name="path">oss文件存储地址</param>
        /// <param name="fileType">文件类型</param>
        /// <returns></returns>
        public string Upload(Stream stream, string path, FileTypeEnum fileType)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            var (_, contentType) = GetFileTypeInfo(fileType);

            try
            {
                OssClient.PutObject(_aliyunOssOption.AliyunBucketName,
                    path,
                    stream,
                    new ObjectMetadata
                    {
                        ExpirationTime = DateTime.MaxValue,
                        CacheControl = "No-Cache",
                        ContentType = contentType
                    });
            }
            catch (OssException ex)
            {
                throw new BusinessException(
                    $"上传文件失败，错误码: {ex.ErrorCode}; 错误原因: {ex.Message}. \nRequestID:{ex.RequestId}\tHostID:{ex.HostId}");
            }
            catch (Exception e)
            {
                throw new BusinessException("上传文件失败,详细错误原因:" + e.Message);
            }

            return path;
        }

        #endregion

        #region 下载

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Stream Download(string url)
        {
            var key = url.Replace("https://" + _aliyunOssOption.AliyunBucketName + "." +
                                  _aliyunOssOption.AliyunEndPoint + "/", "");
            try
            {
                MemoryStream stream = new MemoryStream();
                var request = new GetObjectRequest(_aliyunOssOption.AliyunBucketName, key);
                var result = OssClient.GetObject(request, stream);
                stream.Seek(0, SeekOrigin.Begin);
                return stream;
            }
            catch (OssException ex)
            {
                throw new BusinessException(
                    $"Failed with error code: {ex.ErrorCode}; Error info: {ex.Message}. \nRequestID:{ex.RequestId}\tHostID:{ex.HostId}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="path"></param>
        public void Delete(string path)
        {
            try
            {
                OssClient.DeleteObject(_aliyunOssOption.AliyunBucketName, path);
            }
            catch (OssException ex)
            {
                throw new BusinessException(
                    $"删除文件失败，错误码: {ex.ErrorCode}; 错误原因: {ex.Message}. \nRequestID:{ex.RequestId}\tHostID:{ex.HostId}");
            }
            catch (Exception e)
            {
                throw new BusinessException("删除文件失败,详细错误原因:" + e.Message);
            }
        }

        #endregion

        #region 删除集合

        /// <summary>
        /// 删除集合
        /// </summary>
        /// <param name="pathList"></param>
        public void BatchDelete(List<string> pathList)
        {
            try
            {
                var result = OssClient.DeleteObjects(new DeleteObjectsRequest(_aliyunOssOption.AliyunBucketName, pathList));
            }
            catch (OssException ex)
            {
                throw new BusinessException(
                    $"删除文件失败，错误码: {ex.ErrorCode}; 错误原因: {ex.Message}. \nRequestID:{ex.RequestId}\tHostID:{ex.HostId}");
            }
            catch (Exception e)
            {
                throw new BusinessException("删除文件失败,详细错误原因:" + e.Message);
            }
        }

        #endregion

        #region 智能转换链接为本平台链接

        /// <summary>
        /// 智能转换链接为本平台链接
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="isNeedPrefix">是否需要携带域名前缀</param>
        /// <returns></returns>
        public string GetPlatformLink(string url, bool isNeedPrefix = false)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return "";
            }

            var bytes = RestSharpClient.Get(url, "").RawBytes;

            if (isNeedPrefix)
            {
                return GenerateAuthQuery(Upload(StreamCommon.BytesToStream(bytes)));
            }

            return Upload(StreamCommon.BytesToStream(bytes));
        }

        /// <summary>
        /// 智能转换链接为本平台链接
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="path">oss文件存储地址</param>
        /// <param name="isNeedPrefix">是否需要携带域名前缀</param>
        /// <returns></returns>
        public string GetPlatformLink(string url, string path, bool isNeedPrefix = false)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return "";
            }

            var bytes = RestSharpClient.Get(url, "").RawBytes;

            if (isNeedPrefix)
            {
                return GenerateAuthQuery(Upload(StreamCommon.BytesToStream(bytes)));
            }

            return Upload(StreamCommon.BytesToStream(bytes), path);
        }

        #endregion

        #region Private

        /// <summary>
        /// Oss请求
        /// </summary>
        OssClient OssClient
        {
            get
            {
                return new OssClient(_aliyunOssOption.AliyunEndPoint, _aliyunOssOption.AliyunAccessKeyId,
                  _aliyunOssOption.AliyunAccessKeySecret);
            }
        }

        /// <summary>
        /// 生成文件路径（默认）
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        string GetPath(string prefix, string fileType)
        {
            //生成guid
            var id = Guid.NewGuid().ToString().Replace("-", "");
            //文件路径
            var path = Utils.GetDateTime().ToString("yyyyMMdd") + "/" + id + fileType;

            return string.IsNullOrWhiteSpace(prefix) ? path : prefix + "/" + path;
        }

        /// <summary>
        /// 获取文件类型信息
        /// </summary>
        /// <param name="fileType">文件类型</param>
        /// <returns></returns>
        (string, string) GetFileTypeInfo(FileTypeEnum fileType)
        {
            return fileType switch
            {
                FileTypeEnum.GIF => (".gif", "image/gif"),
                FileTypeEnum.JPG => (".jpg", "image/jpg"),
                FileTypeEnum.GPEG => (".jpeg", "image/jpeg"),
                FileTypeEnum.PNG => (".png", "image/png"),
                FileTypeEnum.BMP => (".bmp", "application/x-bmp"),
                FileTypeEnum.MP3 => (".mp3", "audio/mp3"),
                FileTypeEnum.WMA => (".wma", "audio/x-ms-wma"),
                FileTypeEnum.WAV => (".wav", "audio/wav"),
                FileTypeEnum.AMR => (".amr", "audio/amr"),
                FileTypeEnum.MP4 => (".mp4", "video/mpeg4"),
                FileTypeEnum.XLSX => (".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"),
                FileTypeEnum.PDF => (".pdf", "application/pdf"),
                FileTypeEnum.TXT => (".txt", "text/plain"),
                FileTypeEnum.DOC => (".doc", "application/msword"),
                FileTypeEnum.ZIP => (".zip", "aplication/zip"),
                FileTypeEnum.XLS => (".xls", "application/vnd.ms-excel"),
                FileTypeEnum.CSV => (".csv", "text/csv"),
                FileTypeEnum.PPT => (".ppt", "application/vnd.ms-powerpoint"),
                FileTypeEnum.PPTX => (".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"),
                FileTypeEnum.DOCX => (".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"),
                _ => throw new BusinessException("不支持的文件类型，请使用指定文件类型上传接口"),
            };
        }

        #endregion
    }
}
