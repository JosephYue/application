﻿namespace Application.Extension.Infrastructure.Exceptions
{
    /// <summary>
    /// 请求参数有误的错误
    /// </summary>
    public class BadRequestException : HttpException
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="message">错误消息</param>
        public BadRequestException(string message) : base(400,message) { }
    }
}
