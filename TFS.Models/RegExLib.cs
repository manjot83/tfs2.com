using System.Text.RegularExpressions;
using Centro.Extensions;

namespace TFS.Models
{
    public static class RegExLib
    {
        public const string USPhoneNumber = @"^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$";

        public static string ParseRegEx(string input, string pattern)
        {
            if (pattern == USPhoneNumber)
                return input.Substitute(RegExLib.USPhoneNumber, x => x.Success ? x.Groups[1].Value + x.Groups[2].Value + x.Groups[3].Value : string.Empty);
            else
                return string.Empty;
        }

    }
}
