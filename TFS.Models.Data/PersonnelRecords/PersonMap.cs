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
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Table("Persons");

            Id(x => x.Id)
                .Column("PersonId")
                .GeneratedBy.Foreign("User")
                .Not.Nullable();

            HasOne(x => x.User).Constrained().Cascade.SaveUpdate();
            HasOne(x => x.Qualifications).Constrained().Cascade.SaveUpdate();

            References(x => x.HirePosition)
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
                .Nullable();
            Map(x => x.Gender)
                .CustomType<EnumerationUserType<Gender>>()
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
            Map(x => x.EmergencyContactName)
                .Length(50)
                .Nullable();
            Map(x => x.EmergencyContactPhoneNumber)
                .Length(50)
                .Nullable();
            Map(x => x.ShirtSize)
                .CustomType<EnumerationUserType<ShirtSize>>()
                .Nullable();
            Map(x => x.FlightSuitSize)
                .CustomType<EnumerationUserType<FlightSuitSize>>()
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
