using System;
using System.Linq;
using System.Text;
using TFS.Models;
using System.ComponentModel.DataAnnotations;
using Iesi.Collections.Generic;

namespace TFS.Models.PersonnelRecords
{
    public class Qualifications : BaseDomainObject
    {
        public Qualifications()
        {
            Certificates = new HashedSet<Certificate>();
        }

        public virtual Guid? Id { get; private set; }

        [DomainEquality]
        [Required]
        public virtual Person Person { get; set; }

        public virtual ISet<Certificate> Certificates { get; set; }
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
