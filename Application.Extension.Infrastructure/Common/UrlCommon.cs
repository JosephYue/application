using Application.Extension.Infrastructure.Exceptions;
using System;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Application.Extension.Infrastructure.Common
{
    /// <summary>
    /// url处理公共类
    /// </summary>
    public static class UrlCommon
    {
        #region 将查询字符串解析转换为名值集合

        /// <summary>
        /// 将查询字符串解析转换为名值集合
        /// </summary>
        /// <param name="queryString">需要查询的字符串</param>
        /// <param name="encoding">编码格式 isEncoded 为 true时需要传入编码格式</param>
        /// <param name="isEncoded">是否需要Encoded编码</param>
        /// <returns></returns>
        public static NameValueCollection GetQueryString(this string queryString, Encoding? encoding = null, bool isEncoded = false)
        {
            queryString = queryString.Replace("?", "");
            NameValueCollection result = new NameValueCollection(StringComparer.OrdinalIgnoreCase);
            if (!string.IsNullOrEmpty(queryString))
            {
                int count = queryString.Length;
                for (int i = 0; i < count; i++)
                {
                    int startIndex = i;
                    int index = -1;
                    while (i < count)
                    {
                        char item = queryString[i];
                        if (item == '=')
                        {
                            if (index < 0)
                            {
                                index = i;
                            }
                        }
                        else if (item == '&')
                        {
                            break;
                        }
                        i++;
                    }

                    string value = string.Empty;
                    string key;
                    if (index >= 0)
                    {
                        key = queryString.Substring(startIndex, index - startIndex);
                        value = queryString.Substring(index + 1, (i - index) - 1);
                    }
                    else
                    {
                        key = queryString.Substring(startIndex, i - startIndex);
                    }

                    if (isEncoded)
                    {
                        result[MyUrlDeCode(key, encoding)] = MyUrlDeCode(value, encoding);
                    }
                    else
                    {
                        result[key] = value;
                    }

                    if ((i == (count - 1)) && (queryString[i] == '&'))
                    {
                        result[key] = string.Empty;
                    }
                }
            }
            return result;
        }

        #endregion

        #region 解码URL

        /// <summary>
        /// 解码URL
        /// </summary>
        /// <param name="encoding">null为自动选择编码</param>
        /// <param name="str">需要解码的字符串</param>
        /// <returns></returns>
        public static string MyUrlDeCode(string str, Encoding? encoding)
        {
            if (encoding == null)
            {
                Encoding utf8 = Encoding.UTF8;
                //首先用utf-8进行解码                     
                string code = HttpUtility.UrlDecode(str.ToUpper(), utf8);
                //将已经解码的字符再次进行编码.
                string encode = HttpUtility.UrlEncode(code, utf8).ToUpper();
                if (str == encode)
                    encoding = Encoding.UTF8;
                else
                    encoding = Encoding.GetEncoding("gb2312");
            }
            return HttpUtility.UrlDecode(str, encoding);
        }

        #endregion

        #region 得到url地址

        /// <summary>
        /// 得到url地址
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetUrl(this string str)
        {
            string regexStr = "[a-zA-z]+://[^\\s]*";
            Regex reg = new Regex(regexStr, RegexOptions.Multiline);
            MatchCollection matchs = reg.Matches(str);
            foreach (Match? item in matchs)
            {
                if (item == null)
                {
                    continue;
                }

                if (item.Success)
                {
                    return item.Value;
                }
            }

            throw new BusinessException("无效的链接");
        }

        #endregion

        #region Url编码

        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="target">待加密字符串</param>
        /// <returns></returns>
        public static string UrlEncode(this string target)
        {
            return HttpUtility.UrlEncode(target);
        }

        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="target">待加密字符串</param>
        /// <param name="encoding">编码类型</param>
        /// <returns></returns>
        public static string UrlEncode(this string target, Encoding encoding)
        {
            return HttpUtility.UrlEncode(target, encoding);
        }

        #endregion

        #region Url解码

        /// <summary>
        ///
        /// </summary>
        /// <param name="target">待解密字符串</param>
        /// <returns></returns>
        public static string UrlDecode(this string target)
        {
            return HttpUtility.UrlDecode(target);
        }

        /// <summary>
        /// Url解码
        /// </summary>
        /// <param name="target">待解密字符串</param>
        /// <param name="encoding">编码类型</param>
        /// <returns></returns>
        public static string UrlDecode(this string target, Encoding encoding)
        {
            return HttpUtility.UrlDecode(target, encoding);
        }

        #endregion

        #region Html属性编码

        /// <summary>
        /// Html属性编码
        /// </summary>
        /// <param name="target">待加密字符串</param>
        /// <returns></returns>
        public static string AttributeEncode(this string target)
        {
            return HttpUtility.HtmlAttributeEncode(target);
        }

        #endregion

        #region Html编码

        /// <summary>
        /// Html编码
        /// </summary>
        /// <param name="target">待加密字符串</param>
        /// <returns></returns>
        public static string HtmlEncode(this string target)
        {
            return HttpUtility.HtmlEncode(target);
        }

        #endregion

        #region Html解码

        /// <summary>
        /// Html解码
        /// </summary>
        /// <param name="target">待解密字符串</param>
        /// <returns></returns>
        public static string HtmlDecode(this string target)
        {
            return HttpUtility.HtmlDecode(target);
        }

        #endregion
    }
}
