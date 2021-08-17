namespace Application.Extension.Infrastructure.Exceptions
{
    public class BusinessException : HttpException
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="message">错误消息</param>
        public BusinessException(string message = "系统繁忙，请稍后再试") : base(201, message) { }
    }
}
