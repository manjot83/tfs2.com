using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Centro.DomainModel;

namespace TFS.Models.FlightLogs
{
    public class Mission : BaseEntity
    {
        public virtual int? Id { get; set; }

        public virtual MissionSummary MissionSummary { get; set; }

        public virtual string Name { get; set; }
        public virtual string AdditionalInfo { get; set; }

        public virtual string FromICAO { get; set; }
        public virtual string ToICAO { get; set; }

        public virtual DateTime TakeOffTime { get; set; }
        public virtual DateTime LandTime { get; set; }
                
        public virtual int TouchAndGos { get; set;}
        public virtual int FullStops { get; set; }
        public virtual int Sorties { get; set; }
        public virtual int Totals { get; set; }
    }
}
