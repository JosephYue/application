using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Application.Extension.Infrastructure.Common
{
    /// <summary>
    /// 安全公共基础类
    /// </summary>
    public static class SecurityCommon
    {
        #region AES加密

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <param name="key"></param>
        /// <param name="errCode">错误码</param>
        /// <returns></returns>
        public static string AesEncrypt(this string toEncrypt, string key, int? errCode = null)
        {
            if (string.IsNullOrWhiteSpace(toEncrypt))
            {
                return string.Empty;
            }

            if (key.Length != 32)
            {
                throw new Exception("Aes秘钥异常");
            }

            // 256-AES key
            byte[] keyArray = Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);

            RijndaelManaged rDel = new RijndaelManaged
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);


            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        #endregion

        #region AES解密

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="toDecrypt"></param>
        /// <param name="key"></param>
        /// <param name="errCode">错误码</param>
        /// <returns></returns>
        public static string Decrypt(this string toDecrypt, string key, int? errCode = null)
        {
            if (string.IsNullOrWhiteSpace(toDecrypt))
                return string.Empty;

            if (key.Length != 32)
            {
                throw new Exception("Aes秘钥异常");
            }

            try
            {
                // 256-AES key
                byte[] keyArray = Encoding.UTF8.GetBytes(key);
                byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

                RijndaelManaged rDel = new RijndaelManaged
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };

                ICryptoTransform cTransform = rDel.CreateDecryptor();


                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return Encoding.UTF8.GetString(resultArray);
            }
            catch
            {
                return toDecrypt;
            }
        }

        #endregion

        #region MD5加密

        /// <summary>
        /// Md5加密，返回16位结果
        /// </summary>
        /// <param name="input">待加密字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <param name="isUpper">是否转大写</param>
        public static string GetMd5HashBy16(this string input, Encoding? encoding = null, bool isUpper = true)
        {
            return GetMd5Hash(input, true, encoding, isUpper);
        }

        /// <summary>
        /// MD5加密(32位)
        /// </summary>
        /// <param name="input">待加密字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string GetMd5Hash(this string input, Encoding? encoding = null, bool isUpper = true)
        {
            return GetMd5Hash(input, false, encoding, isUpper);
        }

        /// <summary>
        /// 得到md5加密结果
        /// </summary>
        /// <param name="input">待加密字符串</param>
        /// <param name="is16">是否16位加密，是否32位加密</param>
        /// <param name="encoding">编码方式</param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        private static string GetMd5Hash(string input, bool is16, Encoding? encoding = null, bool isUpper = true)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            MD5 myMd5 = new MD5CryptoServiceProvider();
            var signed = myMd5.ComputeHash(encoding.GetBytes(input));
            string signResult = is16 ? GetSignResult(signed, 4, 8) : GetSignResult(signed);
            return isUpper ? signResult.ToUpper() : signResult.ToLower();
        }

        /// <summary>
        /// MD5加密方法
        /// startIndex为空为32位加密
        /// </summary>
        /// <param name="signed"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string GetSignResult(byte[] signed, int? startIndex = null, int? length = null)
        {
            return (startIndex == null
                ? BitConverter.ToString(signed)
                : BitConverter.ToString(signed, (int)startIndex, length ?? default(int))).Replace("-", "");
        }

        #endregion

        #region BASE64加密

        /// <summary>
        /// BASE64 加密
        /// </summary>
        /// <param name="value">待加密字段</param>
        /// <returns></returns>
        public static string Base64Encrypt(this string value)
        {
            var btArray = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(btArray, 0, btArray.Length);
        }

        #endregion

        #region Base64解密

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="ciphervalue">密文</param>
        /// <returns></returns>
        public static string Base64Decrypt(this string ciphervalue)
        {
            return Encoding.Default.GetString(Convert.FromBase64String(ciphervalue));
        }

        #endregion

        #region SHA 加密

        /// <summary>
        /// SHA1 加密
        /// </summary>
        public static string Sha1(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"未将对象引用设置到对象的实例。");
            }

            var encoding = Encoding.UTF8;
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            return HashAlgorithmBase(sha1, value, encoding);
        }

        /// <summary>
        /// SHA256 加密
        /// </summary>
        public static string Sha256(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"未将对象引用设置到对象的实例。");
            }

            var encoding = Encoding.UTF8;
            SHA256 sha256 = new SHA256Managed();
            return HashAlgorithmBase(sha256, value, encoding);
        }

        /// <summary>
        /// SHA512 加密
        /// </summary>
        public static string Sha512(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"未将对象引用设置到对象的实例。");
            }
            var encoding = Encoding.UTF8;
            SHA512 sha512 = new SHA512Managed();
            return HashAlgorithmBase(sha512, value, encoding);
        }

        #endregion

        #region HMAC 加密

        /// <summary>
        /// HmacSha1 加密
        /// </summary>
        public static string HmacSha1(this string value, string keyVal)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"未将对象引用设置到对象的实例。");
            }
            var encoding = Encoding.UTF8;
            byte[] keyStr = encoding.GetBytes(keyVal);
            HMACSHA1 hmacSha1 = new HMACSHA1(keyStr);
            return HashAlgorithmBase(hmacSha1, value, encoding);
        }

        /// <summary>
        /// HmacSha256 加密
        /// </summary>
        public static string HmacSha256(this string value, string keyVal)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"未将对象引用设置到对象的实例。");
            }
            var encoding = Encoding.UTF8;
            byte[] keyStr = encoding.GetBytes(keyVal);
            HMACSHA256 hmacSha256 = new HMACSHA256(keyStr);
            return HashAlgorithmBase(hmacSha256, value, encoding);
        }

        /// <summary>
        /// HmacSha384 加密
        /// </summary>
        public static string HmacSha384(this string value, string keyVal)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"未将对象引用设置到对象的实例。");
            }
            var encoding = Encoding.UTF8;
            byte[] keyStr = encoding.GetBytes(keyVal);
            HMACSHA384 hmacSha384 = new HMACSHA384(keyStr);
            return HashAlgorithmBase(hmacSha384, value, encoding);
        }

        /// <summary>
        /// HmacSha512 加密
        /// </summary>
        public static string HmacSha512(this string value, string keyVal)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"未将对象引用设置到对象的实例。");
            }
            var encoding = Encoding.UTF8;
            byte[] keyStr = encoding.GetBytes(keyVal);
            HMACSHA512 hmacSha512 = new HMACSHA512(keyStr);
            return HashAlgorithmBase(hmacSha512, value, encoding);
        }

        /// <summary>
        /// HmacMd5 加密
        /// </summary>
        public static string HmacMd5(this string value, string keyVal)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"未将对象引用设置到对象的实例。");
            }
            var encoding = Encoding.UTF8;
            byte[] keyStr = encoding.GetBytes(keyVal);
            HMACMD5 hmacMd5 = new HMACMD5(keyStr);
            return HashAlgorithmBase(hmacMd5, value, encoding);
        }

        #endregion

        #region Private

        #region HashAlgorithm 加密统一方法

        /// <summary>
        /// HashAlgorithm 加密统一方法
        /// </summary>
        private static string HashAlgorithmBase(HashAlgorithm hashAlgorithmObj, string source, Encoding encoding)
        {
            byte[] btStr = encoding.GetBytes(source);
            byte[] hashStr = hashAlgorithmObj.ComputeHash(btStr);
            return hashStr.Bytes2Str();
        }

        #endregion

        #region 转换成字符串

        /// <summary>
        /// 转换成字符串
        /// </summary>
        private static string Bytes2Str(this IEnumerable<byte> source, string formatStr = "{0:X2}")
        {
            var pwd = new StringBuilder();
            foreach (var btStr in source) { pwd.AppendFormat(formatStr, btStr); }
            return pwd.ToString();
        }

        #endregion

        #endregion
    }
}
