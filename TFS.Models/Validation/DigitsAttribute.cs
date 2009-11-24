using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TFS.Models.Validation
{
    public class DigitsAttribute : ValidationAttribute
    {
        public DigitsAttribute()
        {
            ErrorMessage = "The value must contain no integer or fractional digits";
        }

        public DigitsAttribute(int integerDigits)
            : this()
        {
            this.IntegerDigits = integerDigits;
            ErrorMessage = string.Format("The value must contain {0} integer and no fractional digits", integerDigits);
        }

        public DigitsAttribute(int integerDigits, int fractionalDigits)
            : this(integerDigits)
        {
            this.FractionalDigits = fractionalDigits;
            ErrorMessage = string.Format("The value must contain {0} integer and {1} fractional digits", integerDigits, fractionalDigits);
        }

        public int IntegerDigits { get; set; }
        public int FractionalDigits { get; set; }

        public override bool IsValid(object value)
        {
            string input;
            if (value == null)
                return true;
            if (value is string)
            {
                try
                {
                    input = Convert.ToDouble(value).ToString();
                }
                catch (FormatException)
                {
                    return false;
                }
            }
            else if (StringIsNumericAttribute.IsNumeric(value))
                input = value.ToString();
            else
                return false;

            string currencyDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            int index = input.IndexOf(currencyDecimalSeparator);
            int integerPart = (index == -1) ? input.Length : index;
            int fractionalPart = (index == -1) ? 0 : ((input.Length - index) - 1);
            if ((integerPart == 1) && (input[0] == '0'))
            {
                integerPart--;
            }
            return ((integerPart <= IntegerDigits) && (fractionalPart <= FractionalDigits));

        }
    }
}
