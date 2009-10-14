using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.PersonnelRecords;
using FluentNHibernate.Mapping;
using Centro.Data.UserTypes;

namespace TFS.Models.Data.PersonnelRecords
{
    public class QualificationsMap : ClassMap<Qualifications>
    {
        public QualificationsMap()
        {
            Table("Qualifications");

            Id(x => x.Id)
                .Column("PersonId")
                .GeneratedBy.Foreign("Person")
                .Not.Nullable();

            HasOne(x => x.Person).Constrained().Cascade.SaveUpdate();
            HasManyToMany(x => x.Certificates)
                .Table("QualificationsCertificates")
                .ParentKeyColumn("PersonId")
                .ChildKeyColumn("CertificateId")
                .Cascade.SaveUpdate();

            Map(x => x.BranchOfService)
                .CustomType<EnumerationUserType<ServiceBranch>>()
                .Nullable();
            Map(x => x.MilitaryFCFQualification)
                .CustomType<EnumerationUserType<FCFQualification>>()
                .Nullable();
            Map(x => x.LastAltitudeChamber)
                .Nullable();
            Map(x => x.LastBFR)
                .Nullable();
            Map(x => x.LastCRM)
                .Nullable();
            Map(x => x.LastEgreesTraining)
                .Nullable();
            Map(x => x.LastFlight)
                .Nullable();
            Map(x => x.LastLifeSupportTraining)
                .Nullable();
            Map(x => x.LastMilitaryFlightPhysical)
                .Nullable();
            Map(x => x.LastSimulatorRefresher)
                .Nullable();
        }
    }
}
