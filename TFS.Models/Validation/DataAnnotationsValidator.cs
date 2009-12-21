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
            var errors = GetValidationErrorsForType(value);
            foreach (var property in TypeDescriptor.GetProperties(value).Cast<PropertyDescriptor>())
                errors = errors.Concat(GetValidationErrorsForProperty(property, value));
            return errors.ToArray();
        }


        private IEnumerable<ValidationError> GetValidationErrorsForType(object value)
        {
            return TypeDescriptor.GetAttributes(value)
                .OfType<ValidationAttribute>()
                .Where(x => !x.IsValid(value))
                .Select(x => new ValidationError(string.Empty, x.FormatErrorMessage(string.Empty), value));
        }

        private IEnumerable<ValidationError> GetValidationErrorsForProperty(PropertyDescriptor property, object model)
        {
            return property.Attributes
                .OfType<ValidationAttribute>()
                .Where(x => !x.IsValid(property.GetValue(model)))
                .Select(x => new ValidationError(property.Name, x.FormatErrorMessage(property.Name), model));
        }

        public void Validate(object value)
        {
            var validationErrors = ValidationErrorsFor(value);
            if (validationErrors.Any())
                throw new InvalidModelException(validationErrors);
        }
    }
}
