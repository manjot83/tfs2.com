using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TFS.Models.FlightPrograms
{
    public class AircraftMDS : BaseDomainObject
    {
        public virtual int? Id { get; private set; }

        [DomainEquality]
        [Required, StringLength(50)]
        public virtual string Name { get; set; }
    }
}
