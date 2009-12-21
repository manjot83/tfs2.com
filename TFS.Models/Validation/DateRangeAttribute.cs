using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TFS.Models.Validation
{
    public class DateRangeAttribute : ValidationAttribute
    {
        private const string ErrorMessageText = "The date is out of range";
        private const string JavaScriptFunction = "DateIsInRange";
        public string Min { get; set; }
        public string Max { get; set; }
        public bool Exclusive { get; set; }

        public DateRangeAttribute()
            : base(ErrorMessageText)
        {
            Min = DateTime.MinValue.ToString();
            Max = DateTime.MaxValue.ToString();
            Exclusive = false;
        }

        public override string FormatErrorMessage(string name)
        {
            if (string.IsNullOrEmpty(name))
                return ErrorMessageText;
            else
                return name + " is out of range";
        }

        public override bool IsValid(object value)
        {
            var min = DateTime.MinValue;
            DateTime.TryParse(Min, out min);
            var max = DateTime.MaxValue;
            DateTime.TryParse(Max, out max);
            if (Exclusive)
                return ((value == null) || ((value is DateTime) && ((DateTime)value > min) && ((DateTime)value < max)));
            else
                return ((value == null) || ((value is DateTime) && ((DateTime)value >= min) && ((DateTime)value <= max)));
        }
    }
}
