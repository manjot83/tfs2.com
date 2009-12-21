using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TFS.Models.Validation
{
    public class MilitaryTimeFormatAttribute : ValidationAttribute
    {
        private const string ErrorMessageText = "Must represent 24hr time in the format HHMM";

        public override string FormatErrorMessage(string name)
        {
            if (string.IsNullOrEmpty(name))
                return ErrorMessageText;
            else
                return name + " " + ErrorMessageText;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            var time = 0;
            if (!int.TryParse(value.ToString(), out time) || time > 2359 || time < 0)
                return false;
            return true;
        }
    }
}
