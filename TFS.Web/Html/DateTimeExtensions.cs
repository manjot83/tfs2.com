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
            return ToShortDateOrEmptyString((DateTime?)dateTime);
        }

        public static string ToShortDateOrEmptyString(this DateTime? dateTime)
        {
            if (!dateTime.HasValue || dateTime == DateTime.MinValue)
                return string.Empty;
            return dateTime.Value.ToString("MM/dd/yyyy");
        }

        public static string ToShortMilitaryTime(this DateTime dateTime)
        {
            return ToShortMilitaryTime((DateTime?)dateTime);
        }

        public static string ToShortMilitaryTime(this DateTime? dateTime)
        {
            if (!dateTime.HasValue || dateTime == DateTime.MinValue)
                return string.Empty;
            return dateTime.Value.ToString("HHMM");
        }
    }
}
