using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TFS.Models.Validation
{
    public class StringIsNumericAttribute : ValidationAttribute
    {
        public StringIsNumericAttribute()
        {
            ErrorMessage = "The value must be numberic";
        }

        internal static bool IsNumeric(object Expression)
        {
            double num;
            return double.TryParse(Convert.ToString(Expression), NumberStyles.Any, (IFormatProvider)NumberFormatInfo.InvariantInfo, out num);
        }

        public override bool IsValid(object value)
        {
            return ((value == null) || ((value is string) && IsNumeric(value)));
        }
    }
}
