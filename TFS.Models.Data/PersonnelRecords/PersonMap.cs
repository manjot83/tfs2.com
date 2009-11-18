using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.PersonnelRecords;
using FluentNHibernate.Mapping;
using TFS.Models.Data.UserTypes;

namespace TFS.Models.Data.PersonnelRecords
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Table("Persons");

            Id(x => x.Id)
                .Column("PersonId")
                .GeneratedBy.Foreign("User")
                .Not.Nullable();

            HasOne(x => x.User)
                .ForeignKey("FK_Persons_Users")
                .Constrained()
                .Cascade.All();
            HasOne(x => x.Qualifications)
                .Cascade.All();

            References(x => x.HirePosition)
                .ForeignKey("FK_Persons_Positions")
                .Column("HirePositionId")
                .Nullable();

            Map(x => x.LastName)
                .Length(50)
                .Nullable();
            Map(x => x.FirstName)
                .Length(50)
                .Nullable();
            Map(x => x.MiddleInitial)
                .Length(50)
                .Nullable();
            Map(x => x.DateOfBirth)
                .CustomType<UtcDateTimeUserType>()
                .Nullable();
            Map(x => x.Gender)
                .CustomType<Gender>()
                .Nullable();
            Map(x => x.SocialSecurityLastFour)
                .Length(4)
                .Nullable();
            Map(x => x.PrimaryPhoneNumber)
                .Length(10)
                .Nullable();
            Map(x => x.AlternatePhoneNumber)
                .Length(10)
                .Nullable();
            Map(x => x.AlternateEmail)
                .Length(254)
                .Nullable();
            Map(x => x.EmergencyContactName)
                .Length(50)
                .Nullable();
            Map(x => x.EmergencyContactPhoneNumber)
                .Length(50)
                .Nullable();
            Map(x => x.ShirtSize)
                .CustomType<ShirtSize>()
                .Nullable();
            Map(x => x.FlightSuitSize)
                .CustomType<FlightSuitSize>()
                .Nullable();

            Component(x => x.Address, m =>
            {
                m.Map(x => x.StreetAddress)
                    .Length(100)
                    .Nullable();
                m.Map(x => x.City)
                    .Length(50)
                    .Nullable();
                m.Map(x => x.State)
                    .CustomType<USStateUserType>()
                    .Nullable();
                m.Map(x => x.ZipCode)
                    .Length(5)
                    .Nullable();
            });
        }
    }
}
