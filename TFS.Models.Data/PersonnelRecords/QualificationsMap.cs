using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.PersonnelRecords;
using FluentNHibernate.Mapping;
using Centro.Data.UserTypes;
using TFS.Models.Data.UserTypes;

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

            HasOne(x => x.Person)
                .ForeignKey("FK_Qualifications_Person")
                .Constrained()
                .Cascade.All();
            HasManyToMany(x => x.Certificates)
                .Table("QualificationsCertificates")
                .ForeignKeyConstraintNames("FK_QualificationsCertificates_Qualifications", "FK_QualificationsCertificates_Certificates")
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
                .CustomType<UtcDateTimeUserType>()
                .Nullable();
            Map(x => x.LastBFR)
                .CustomType<UtcDateTimeUserType>()
                .Nullable();
            Map(x => x.LastCRM)
                .CustomType<UtcDateTimeUserType>()
                .Nullable();
            Map(x => x.LastEgreesTraining)
                .CustomType<UtcDateTimeUserType>()
                .Nullable();
            Map(x => x.LastFlight)
                .CustomType<UtcDateTimeUserType>()
                .Nullable();
            Map(x => x.LastLifeSupportTraining)
                .CustomType<UtcDateTimeUserType>()
                .Nullable();
            Map(x => x.LastMilitaryFlightPhysical)
                .CustomType<UtcDateTimeUserType>()
                .Nullable();
            Map(x => x.LastSimulatorRefresher)
                .CustomType<UtcDateTimeUserType>()
                .Nullable();
        }
    }
}
