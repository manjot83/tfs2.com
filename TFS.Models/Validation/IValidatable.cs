using System.Collections.Generic;

namespace TFS.Models.Validation
{
    public interface IValidatable
    {
        bool IsValid();
        IEnumerable<ValidationError> ValidationErrors();
    }
}
