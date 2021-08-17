using System;

namespace Application.Extension.Infrastructure.Common
{
    /// <summary>
    /// 时间操作类
    /// </summary>
    public static class TimeCommon
    {
        #region 获取Unix时间

        /// <summary>
        /// 获取Unix时间
        /// </summary>
        /// <param name="isMillisecond">是否是毫秒时间戳</param>
        /// <returns></returns>
        public static long UnixTimeNow(bool isMillisecond = true)
        {
            if (isMillisecond)
            {
                return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
            }
            else
            {
                return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            }
        }

        #endregion

        #region 时间戳转为DateTime

        /// <summary>
        /// 时间戳转为DateTime
        /// </summary>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="isMillisecond">是否是毫秒时间戳</param>
        /// <returns></returns>
        public static DateTime ConvertToDateTime(this long timeStamp, bool isMillisecond = true)
        {
            if (isMillisecond)
            {
                return DateTimeOffset.FromUnixTimeMilliseconds(timeStamp).ToUniversalTime().AddHours(8).DateTime;
            }
            else
            {
                return DateTimeOffset.FromUnixTimeSeconds(timeStamp).ToUniversalTime().AddHours(8).DateTime;
            }
        }

        #endregion

        #region 时间转换为时间戳

        /// <summary>
        /// 时间转换为时间戳
        /// </summary>
        /// <param name="time">时间信息</param>
        /// <param name="isMillisecond">是否是毫秒级时间戳</param>
        /// <returns></returns>
        public static long ConvertDateToUnix(this DateTime time, bool isMillisecond = true)
        {
            DateTime Jan1stTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            if (!isMillisecond)
            {
                return (long)(time.AddHours(-8) - Jan1stTime).TotalSeconds;
            }

            return (long)(time.AddHours(-8) - Jan1stTime).TotalMilliseconds;
        }

        #endregion

        #region 时间戳

        #region 获取当月时间

        /// <summary>
        /// 获取当月时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetThisMonth()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
        }

        #endregion

        #region 获取下月时间

        /// <summary>
        /// 获取下月时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNextMonth()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0).AddMonths(1);
        }

        #endregion

        #region 获取上月时间

        /// <summary>
        /// 获取上月时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetLastMonth()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0).AddMonths(-1);
        }

        #endregion

        #region 获取今日时间

        /// <summary>
        /// 获取今日时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetToday()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        }

        #endregion

        #region 获取昨日时间

        /// <summary>
        /// 获取昨日时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetYesterday()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(-1);
        }

        #endregion

        #region 获取明日时间

        /// <summary>
        /// 获取明日时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetTomorrow()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(1);
        }

        #endregion

        #region 获取 本周、本月、本季度、本年 的开始时间或结束时间

        /// <summary>
        /// 获取 本周、本月、本季度、本年 的开始时间
        /// </summary>
        /// <param name="TimeType">Week、Month、Season、Year</param>
        /// <param name="now"></param>
        /// <returns></returns>
        public static DateTime? GetTimeStart(string TimeType, DateTime now)
        {
            switch (TimeType)
            {
                case "Week":
                    return now.AddDays(-(int)now.DayOfWeek + 1);
                case "Month":
                    return now.AddDays(-now.Day + 1);
                case "Season":
                    var time = now.AddMonths(0 - ((now.Month - 1) % 3));
                    return time.AddDays(-time.Day + 1);
                case "Year":
                    return now.AddDays(-now.DayOfYear + 1);
                default:
                    return null;
            }
        }

        /// <summary>
        /// 获取 本周、本月、本季度、本年 的结束时间
        /// </summary>
        /// <param name="TimeType">Week、Month、Season、Year</param>
        /// <param name="now"></param>
        /// <returns></returns>
        public static DateTime? GetTimeEnd(string TimeType, DateTime now)
        {
            switch (TimeType)
            {
                case "Week":
                    return now.AddDays(7 - (int)now.DayOfWeek);
                case "Month":
                    return now.AddMonths(1).AddDays(-now.AddMonths(1).Day + 1).AddDays(-1);
                case "Season":
                    var time = now.AddMonths((3 - ((now.Month - 1) % 3) - 1));
                    return time.AddMonths(1).AddDays(-time.AddMonths(1).Day + 1).AddDays(-1);
                case "Year":
                    var time2 = now.AddYears(1);
                    return time2.AddDays(-time2.DayOfYear);
                default:
                    return null;
            }
        }

        #endregion

        #endregion
    }
}
