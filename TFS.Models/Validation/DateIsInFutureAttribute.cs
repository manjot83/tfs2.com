using System;
using System.ComponentModel.DataAnnotations;

namespace TFS.Models.Validation
{
    public class DateIsInFutureAttribute : ValidationAttribute
    {
        public DateIsInFutureAttribute()
        {
            ErrorMessage = "Date must be in the future.";
        }

        public override bool IsValid(object value)
        {
            return ((value == null) || ((value is DateTime) && (DateTime.Now.CompareTo(value) < 0)));
        }
    }
}
