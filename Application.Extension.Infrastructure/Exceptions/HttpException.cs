using System;

namespace Application.Extension.Infrastructure.Exceptions
{
    /// <summary>
    /// Copyright (C) 2018-2099
    /// CLR版本:          4.0.30319.42000
    /// 机器名称:         DESKTOP-FLSPMG3
    /// 创建人:           lkk 
    /// 邮箱:             15757107211@163.com
    /// 创建时间:         2018/4/5 22:32:23
    /// </summary>
    public class HttpException : Exception
    {
        /// <summary>
        /// Status code<br/>
        /// 状态码<br/>
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Initialize<br/>
        /// 初始化<br/>
        /// </summary>
        /// <param name="statusCode">Status code</param>
        /// <param name="message">Exception message</param>
        public HttpException(int statusCode, string message = "") : base(message)
        {
            StatusCode = statusCode;
        }
    }
}