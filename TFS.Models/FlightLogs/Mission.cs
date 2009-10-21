using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Centro.DomainModel;
using System.ComponentModel.DataAnnotations;

namespace TFS.Models.FlightLogs
{
    public class Mission : BaseEntity
    {
        public virtual int? Id { get; set; }

        public virtual MissionLog MissionLog { get; set; }

        [DomainSignature, Required, StringLength(50)]
        public virtual string Name { get; set; }
        [DomainSignature, Required, StringLength(100)]
        public virtual string AdditionalInfo { get; set; }

        [DomainSignature, Required, StringLength(4)]
        public virtual string FromICAO { get; set; }
        [DomainSignature, Required, StringLength(4)]
        public virtual string ToICAO { get; set; }

        [DomainSignature, Required]
        public virtual DateTime TakeOffTime { get; set; }
        [DomainSignature, Required]
        public virtual DateTime LandTime { get; set; }

        [DomainSignature, Required]
        public virtual int TouchAndGos { get; set;}
        [DomainSignature, Required]
        public virtual int FullStops { get; set; }
        [DomainSignature, Required]
        public virtual int Sorties { get; set; }
        [DomainSignature, Required]
        public virtual int Totals { get; set; }
    }
}
