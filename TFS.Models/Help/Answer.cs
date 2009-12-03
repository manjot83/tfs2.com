using System;
using System.ComponentModel.DataAnnotations;
using TFS.Models.Validation;

namespace TFS.Models.Help
{
    public class Answer : BaseDomainObject
    {
        public virtual int? Id { get; private set; }

        [DomainEquality, Required]
        public virtual Question Question { get; set; }

        [Required]
        public virtual string Content { get; set; }

        [Required, DateTimeKind(DateTimeKind.Utc)]
        public virtual DateTime AnsweredOnDate { get; set; }
    }
}
