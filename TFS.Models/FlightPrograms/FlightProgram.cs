using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TFS.Models.FlightPrograms
{
    public class FlightProgram : BaseDomainObject
    {
        public FlightProgram()
        {
            Locations = new HashedSet<ProgramLocation>();
        }

        public virtual int? Id { get; private set; }

        [DomainEquality]
        [Required, StringLength(50)]
        public virtual string Name { get; set; }

        [DomainEquality]
        [Required, StringLength(50)]
        public virtual string AccountName { get; set; }

        [Required]
        public virtual bool Active { get; set; }

        public virtual ISet<ProgramLocation> Locations { get; set; }
    }
}
