using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Validation;

namespace TFS.Models
{
    public abstract class BaseValidatableEntity : IValidatable
    {
        private readonly static DataAnnotationsValidator Validator;

        static BaseValidatableEntity()
        {
            Validator = new DataAnnotationsValidator();
        }

        public virtual IEnumerable<ValidationError> GetCustomValidationErrors()
        {
            return new List<ValidationError>();
        }

        public virtual bool IsValid()
        {
            return Validator.IsValid(this) && !GetCustomValidationErrors().Any();
        }

        public virtual IEnumerable<ValidationError> ValidationErrors()
        {
            return Validator.ValidationErrorsFor(this).Concat(GetCustomValidationErrors());
        }

        /// <summary>
        /// Throws an InvalidModelException if the domain object is not valid.
        /// </summary>
        /// <exception cref="InvalidModelException">If the domain object is not valid.</exception>
        public virtual void Validate()
        {
            var validationErrors = ValidationErrors();
            if (validationErrors.Any())
                throw new InvalidModelException(validationErrors);
        }
    }
}
