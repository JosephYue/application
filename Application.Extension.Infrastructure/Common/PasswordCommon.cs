using System;
using System.Security.Cryptography;
using System.Text;

namespace Application.Extension.Infrastructure.Common
{
    /// <summary>
    /// 密码公共方法
    /// </summary>
    public static class PasswordCommon
    {
        /// <summary>
        /// Get PBKDF2 checksum<br/>
        /// 获取PBKDF2的校验值<br/>
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="slat">The slat, length should be 8</param>
        /// <param name="iterations">Iteration times</param>
        /// <param name="hashLength">Hash length</param>
        /// <returns></returns>
        /// <example>
        /// <code language="cs">
        /// var hash = PasswordUtils.PBKDF2Sum(
        ///		Encoding.UTF8.GetBytes("123456"),
        ///		Encoding.UTF8.GetBytes("12344321"));
        ///	hash.ToHex() ==
        ///		"47e00677444b6d16c36d347a4fea584792fb4a50fe93e762c7e1adf4f73e2475"
        /// </code>
        /// </example>
        public static byte[] PBKDF2Sum(
            byte[] data, byte[] slat, int iterations = 1024, int hashLength = 32)
        {
            var hash = new Rfc2898DeriveBytes(data, slat, iterations).GetBytes(hashLength);
            return hash;
        }

        /// <summary>
        /// Get md5 checksum<br/>
        /// 获取MD5的校验值<br/>
        /// </summary>
        /// <example>
        /// <code language="cs">
        /// var hash = PasswordUtils.Md5Sum(Encoding.UTF8.GetBytes("123456"));
        /// hash.ToHex() == "e10adc3949ba59abbe56e057f20f883e")
        /// </code>
        /// </example>
        public static byte[] Md5Sum(byte[] data)
        {
            return MD5.Create().ComputeHash(data);
        }

        /// <summary>
        /// Get sha1 checksum<br/>
        /// 获取SHA1的校验值<br/>
        /// </summary>
        /// <example>
        /// <code language="cs">
        /// var hash = PasswordUtils.Sha1Sum(Encoding.UTF8.GetBytes("123456"));
        /// hash.ToHex() == "7c4a8d09ca3762af61e59520943dc26494f8941b"
        /// </code>
        /// </example>
        public static byte[] Sha1Sum(byte[] data)
        {
            return SHA1.Create().ComputeHash(data);
        }

        /// <summary>
        /// 检查加密的值一与值二是否相同
        /// </summary>
        /// <param name="valueOne">旧值</param>
        /// <param name="valueTwo">新值</param>
        /// <returns></returns>
        public static bool Check(this string valueOne, string valueTwo)
        {
            return Utils.JsonDeserialize<PasswordValueModel>(valueOne).Check(valueTwo);
        }

        /// <summary>
        /// 获取加密字符串
        /// </summary>
        /// <param name="value">需要加密的字符</param>
        /// <param name="slat">随机值的byte信息 不传则默认生成随机值</param>
        /// <param name="type">密码类型</param>
        /// <returns></returns>
        public static string FormatPassword(this string value,
            byte[]? slat = null, PasswordHashTypeEnum type = PasswordHashTypeEnum.PBKDF2)
        {
            return Utils.JsonSerializer(PasswordValueModel.FormatPassword(value, slat, type));
        }

        /// <summary>
        /// Password information<br/>
        /// 密码信息<br/>
        /// </summary>
        /// <example>
        /// <code language="cs">
        /// var info = PasswordValueModel.FromPassword("123456");
        /// info.Check("12345") == false
        /// info.Check("123456") == true
        /// </code>
        /// </example>
        internal class PasswordValueModel
        {
            /// <summary>
            /// Password type<br/>
            /// 密码类型<br/>
            /// </summary>
            public PasswordHashTypeEnum Type { get; set; } = PasswordHashTypeEnum.PBKDF2;

            /// <summary>
            /// Slat in base64<br/>
            /// base64格式的盐<br/>
            /// </summary>
            public string Slat { get; set; } = string.Empty;

            /// <summary>
            /// Hash in base64
            /// base64格式的校验值</summary>
            public string Hash { get; set; } = string.Empty;

            /// <summary>
            /// Check password, return true for success<br/>
            /// 检查密码, 成功时返回true<br/>
            /// </summary>
            /// <param name="password">The password</param>
            /// <returns></returns>
            internal bool Check(string password)
            {
                if (string.IsNullOrEmpty(password))
                {
                    return false;
                }
                var slat = Slat == null ? null : Convert.FromBase64String(Slat);
                var info = FormatPassword(password, slat, Type);
                return Hash == info.Hash;
            }

            /// <summary>
            /// Create password information from password<br/>
            /// 根据密码创建密码信息<br/>
            /// </summary>
            /// <param name="password">The password</param>
            /// <param name="slat">Slat, use a random value if gived null</param>
            /// <param name="type">Password type</param>
            internal static PasswordValueModel FormatPassword(string password,
               byte[]? slat = null, PasswordHashTypeEnum type = PasswordHashTypeEnum.PBKDF2)
            {
                if (string.IsNullOrEmpty(password))
                {
                    throw new ArgumentNullException("password can't be empty");
                }

                var info = new PasswordValueModel { Type = type };

                var passwordBytes = Encoding.UTF8.GetBytes(password);

                if (type == PasswordHashTypeEnum.PBKDF2)
                {
                    slat ??= RandomCommon.SystemRandomBytes(8);
                    info.Slat = Convert.ToBase64String(slat);
                    info.Hash = Convert.ToBase64String(PBKDF2Sum(passwordBytes, slat));
                }

                else if (type == PasswordHashTypeEnum.Md5)
                {
                    info.Hash = Convert.ToBase64String(Md5Sum(passwordBytes));
                }
                else if (type == PasswordHashTypeEnum.Sha1)
                {
                    info.Hash = Convert.ToBase64String(Sha1Sum(passwordBytes));
                }

                return info;
            }
        }

        /// <summary>
        /// Password hash type<br/>
        /// 密码的校验类型<br/>
        /// </summary>
        public enum PasswordHashTypeEnum
        {
            /// <summary>
            /// PBKDF2<br/>
            /// </summary>
            PBKDF2 = 0,
            /// <summary>
            /// Md5<br/>
            /// </summary>
            Md5 = 1,
            /// <summary>
            /// Sha1<br/>
            /// </summary>
            Sha1 = 2
        }
    }
}
