using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TFS.Models.Validation
{
    public class DateTimeKindAttribute : ValidationAttribute
    {
        public DateTimeKind Kind { get; set; }

        public DateTimeKindAttribute()
            :this("Invalid DateTimeKind")
        {
        }

        public DateTimeKindAttribute(DateTimeKind kind)
            : this(kind, "Invalid DateTimeKind, must be "+kind.ToString())
        {
        }

        public DateTimeKindAttribute(string errorMessage)
            : base(errorMessage)
        {
        }

        public DateTimeKindAttribute(DateTimeKind kind, string errorMessage)
            : base(errorMessage)
        {
            Kind = kind;
        }

        public override bool IsValid(object value)
        {
            if (value == null || !(value is DateTime))
                return true;
            return ((DateTime)value).Kind == Kind;
        }
    }
}
