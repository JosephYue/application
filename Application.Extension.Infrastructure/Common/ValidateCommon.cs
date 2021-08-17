using System;
using System.Text.RegularExpressions;

namespace Application.Extension.Infrastructure.Common
{
    /// <summary>
    /// 验证方法
    /// </summary>
    public static class ValidateCommon
    {
        #region 是否为Double类型

        /// <summary>
        /// 是否为Double类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsDouble(this object expression)
        {
            return expression.ConvertToDouble() != null;
        }

        #endregion

        #region 是否为Decimal类型

        /// <summary>
        /// 是否为Decimal类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsDecimal(this object expression)
        {
            return expression.ConvertToDecimal() != null;
        }

        #endregion

        #region 是否为Long类型

        /// <summary>
        /// 是否为Long类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsLong(this object expression)
        {
            return expression.ConvertToLong() != null;
        }

        #endregion

        #region 是否为Int类型

        /// <summary>
        /// 是否为Int类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsInt(this object expression)
        {
            return expression.ConvertToInt() != null;
        }

        #endregion

        #region 判断是否是手机号

        /// <summary>
        /// 判断是否是手机号
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static bool IsMobile(this string mobile)
        {
            if (string.IsNullOrWhiteSpace(mobile))
            {
                return false;
            }

            return Regex.IsMatch(mobile, @"^(13|14|15|16|18|19|17)\d{9}$");
        }

        #endregion

        #region 判断是否是身份证

        /// <summary>
        /// 判断是否是身份证（通用）
        /// </summary>
        /// <param name="card">身份证号</param>
        /// <returns></returns>
        public static bool IsCard(this string card)
        {
            Regex objReg = new Regex(@"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$");
            return objReg.IsMatch(card);
        }

        /// <summary>
        /// 身份证符合18位身份证标准
        /// </summary>
        /// <param name="card">身份证号码</param>
        /// <returns></returns>
        public static bool IsIDCard18(string card)
        {
            if (long.TryParse(card.Remove(17), out long n) == false || n < Math.Pow(10, 16) || long.TryParse(card.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }

            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";

            if (address.IndexOf(card.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = card.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            if (DateTime.TryParse(birth, out _) == false)
            {
                return false;//生日验证
            }

            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = card.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }

            Math.DivRem(sum, 11, out int y);

            if (arrVarifyCode[y] != card.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }

            return true;//符合GB11643-1999标准
        }

        /// <summary>
        /// 身份证符合15位身份证标准
        /// </summary>
        /// <param name="card">身份证号码</param>
        /// <returns></returns>
        public static bool IsIDCard15(this string card)
        {
            if (long.TryParse(card, out long n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }

            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";

            if (address.IndexOf(card.Remove(2)) == -1)
            {
                return false;//省份验证
            }

            string birth = card.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            if (DateTime.TryParse(birth, out _) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }

        #endregion

        #region 判断是否为url

        /// <summary>
        /// 判断是否为url
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsUrl(this string str)
        {
            try
            {
                string Url = @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
                return Regex.IsMatch(str, Url);
            }
            catch (Exception)
            {
                return false;
            }
        }

        ///// <summary>
        ///// 验证网址
        ///// </summary>
        ///// <param name="source"></param>
        ///// <returns></returns>
        //public static bool IsUrl(string source)
        //{
        //    return Regex.IsMatch(source, @"^(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)|(www\.))+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?$", RegexOptions.IgnoreCase);
        //}

        /// <summary>
        /// 判断是否为url
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool HasUrl(this string str)
        {
            return Regex.IsMatch(str, @"(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)|(www\.))+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?", RegexOptions.IgnoreCase);
        }

        #endregion

        #region 验证是否为邮箱

        /// <summary>
        /// 验证是否为邮箱
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsEmail(this string str)
        {
            try
            {
                string expression = @"^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$";
                return Regex.IsMatch(str, expression, RegexOptions.Compiled);
            }
            catch (Exception)
            {
                return false;
            }
        }

        ///// <summary>
        ///// 验证邮箱
        ///// </summary>
        ///// <param name="str">字符串</param>
        ///// <returns></returns>
        //public static bool IsEmail(this string str)
        //{
        //    return Regex.IsMatch(str, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", RegexOptions.IgnoreCase);
        //}

        /// <summary>
        /// 是否包含有限
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool HasEmail(this string str)
        {
            return Regex.IsMatch(str, @"[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})", RegexOptions.IgnoreCase);
        }

        #endregion

        #region 验证IP

        /// <summary>
        /// 验证IP
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsIP(this string str)
        {
            return Regex.IsMatch(str, @"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 是否有ip
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool HasIP(string str)
        {
            return Regex.IsMatch(str, @"(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])", RegexOptions.IgnoreCase);
        }

        #endregion
    }
}
