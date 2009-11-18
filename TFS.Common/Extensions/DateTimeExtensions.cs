using System;

namespace TFS.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime WithoutMilliseconds(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Kind);
        }
    }
}
