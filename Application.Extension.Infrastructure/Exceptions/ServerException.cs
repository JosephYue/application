namespace Application.Extension.Infrastructure.Exceptions
{
    public class ServerException : HttpException
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="message">错误消息</param>
        public ServerException(string message) : base(400, message) { }
    }
}
