using System.ComponentModel.DataAnnotations;
using System;

namespace TFS.Models.FlightPrograms
{
    public class Position : BaseDomainObject
    {
        public virtual Guid? Id { get; private set; }

        [DomainEquality]
        [Required, StringLength(50)]
        public virtual string Title { get; set; }
    }
}
