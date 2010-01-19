using System;
using System.ComponentModel.DataAnnotations;
using TFS.Models.Users;
using TFS.Models.Validation;

namespace TFS.Models.Help
{
    public class Question : BaseDomainObject
    {
        public virtual Guid? Id { get; private set; }

        [Required, DomainEquality]
        public virtual string Title { get; set; }

        [Required, StringLength(100)]
        public virtual string Content { get; set; }

        [DomainEquality, Required, DateTimeKind(DateTimeKind.Utc)]
        public virtual DateTime AskedOnDate { get; set; }

        [Required]
        public virtual User AskedBy { get; set; }

        public virtual Answer Answer { get; set; }

        [Required, DateTimeKind(DateTimeKind.Utc)]
        public virtual DateTime LastModifiedDate { get; set; }

        public virtual TimeSpan ComputeTimeSinceLastModified()
        {
            return DateTime.UtcNow.Subtract(LastModifiedDate);
        }

        public virtual void AddAnswer(Answer answer)
        {
            Answer = answer;
            answer.Question = this;
            Validate();
            answer.Validate();
        }
    }
}
