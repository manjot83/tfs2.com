using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TFS.Models.Validation
{
    public class DataAnnotationsValidator
    {
        public bool IsValid(object value)
        {
            return !ValidationErrorsFor(value).Any();
        }

        public IEnumerable<ValidationError> ValidationErrorsFor(object value)
        {
            return from prop in TypeDescriptor.GetProperties(value).Cast<PropertyDescriptor>()
                   from attribute in prop.Attributes.OfType<ValidationAttribute>()
                   where !attribute.IsValid(prop.GetValue(value))
                   select new ValidationError(prop.Name, attribute.FormatErrorMessage(string.Empty), value);
        }
    }
}
