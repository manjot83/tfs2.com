using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TFS.Models.FlightPrograms
{
    public class ProgramLocation : BaseDomainObject
    {
        public virtual Guid? Id { get; private set; }

        [DomainEquality]
        [Required]
        public virtual FlightProgram Program { get; set; }

        [DomainEquality]
        [Required, StringLength(100)]
        public virtual string Name { get; set; }

        public virtual string ToDisplayString()
        {
            return Program.Name + " / " + Name;
        }
    }
}
