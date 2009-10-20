using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFS.Web.Html
{
    public static class DateTimeExtensions
    {
        public static string ToShortDateOrEmptyString(this DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
                return string.Empty;
            return dateTime.ToShortDateString();
        }
    }
}
