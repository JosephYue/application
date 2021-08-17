namespace Application.Extension.Infrastructure.Exceptions
{
    public class UserFriendlyException : HttpException
    {
        /// <summary>
        /// 友好异常 
        /// </summary>
        /// <param name="statusCode">状态码</param>
        /// <param name="message">错误信息</param>
        public UserFriendlyException(string message, int statusCode = 201) : base(statusCode, message)
        {

        }
    }
}
