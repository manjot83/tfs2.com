using System;
using System.ComponentModel.DataAnnotations;

namespace TFS.Models.Validation
{
    public class DateIsInPastAttribute : ValidationAttribute
    {
        public DateIsInPastAttribute()
        {
            ErrorMessage = "Date must be in the past.";
        }

        public override bool IsValid(object value)
        {
            return ((value == null) || ((value is DateTime) && (DateTime.Now.CompareTo(value) > 0)));
        }
    }
}
