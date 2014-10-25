using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TFS.Models.Validation
{
    public class StringIsEmailAttribute : ValidationAttribute
    {
        private const string ATOM = "[^\\x00-\\x1F^\\(^\\)^\\<^\\>^\\@^\\,^\\;^\\:^\\\\^\\\"^\\.^\\[^\\]^\\s]";
        private const string DOMAIN = "([^\\x00-\\x1F^\\(^\\)^\\<^\\>^\\@^\\,^\\;^\\:^\\\\^\\\"^\\.^\\[^\\]^\\s]+(\\.[^\\x00-\\x1F^\\(^\\)^\\<^\\>^\\@^\\,^\\;^\\:^\\\\^\\\"^\\.^\\[^\\]^\\s]+)*";
        private const string IP_DOMAIN = @"\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\]";

        private readonly Regex regex;

        public StringIsEmailAttribute()
        {
            this.regex = new Regex("^" + ATOM + @"+(\." + ATOM + "+)*@" + DOMAIN + "|" + IP_DOMAIN + ")$", RegexOptions.Compiled);
            ErrorMessage = "The value must be an e-mail address.";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            var input = value as string;
            if (input == null)
                return false;
            return ((input.Length == 0) || this.regex.IsMatch(input));
        }
    }
}
