using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models;
using System.ComponentModel.DataAnnotations;

namespace TFS.Models.PersonnelRecords
{
    public class Qualifications : BaseDomainEntity
    {
        public Qualifications()
        {
            Certificates = new List<Certificate>();
        }

        public virtual int? Id { get; private set; }

        [Required]
        public virtual Person Person { get; set; }

        public virtual IList<Certificate> Certificates { get; set; }
        public virtual ServiceBranch BranchOfService { get; set; }
        public virtual FCFQualification MilitaryFCFQualification { get; set; }
        public virtual DateTime? LastBFR { get; set; }
        public virtual DateTime? LastMilitaryFlightPhysical { get; set; }
        public virtual DateTime? LastAltitudeChamber { get; set; }
        public virtual DateTime? LastEgreesTraining { get; set; }
        public virtual DateTime? LastSimulatorRefresher { get; set; }
        public virtual DateTime? LastCRM { get; set; }
        public virtual DateTime? LastLifeSupportTraining { get; set; }
        public virtual DateTime? LastFlight { get; set; }
    }
}
