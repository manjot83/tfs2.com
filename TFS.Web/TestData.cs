﻿#if TESTDATA
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using NHibernate;
using TFS.Models;
using TFS.Extensions;
using TFS.Models.FlightPrograms;
using TFS.Models.PersonnelRecords;
using TFS.Models.FlightLogs;
using TFS.Models.Users;

namespace TFS.Web
{
    public static class TestData
    {
        public static void Execute(ISession session)
        {
            session.BeginTransaction();

            // Users
            var user_joseph = session.Save(new User
            {
                FirstName = "Joseph",
                LastName = "Daigle",
                DisplayName = "Joseph Daigle",
                Username = "j.daigle",
                Email = "j.daigle@tfs2.com",
                Disabled = false,
                Roles = new UserRoles
                {
                    UserManager = true,
                    ProgramManager = true,
                    PersonnelManager = true,
                    FlightLogManager = true,
                },
            });
            var user__bill = session.Save(new User
            {
                FirstName = "Bill",
                LastName = "Petit",
                DisplayName = "Bill Petit",
                Username = "w.petit",
                Email = "w.petit@tfs2.com",
                Disabled = false,
            });
            session.Save(new User
            {
                FirstName = "Mark",
                LastName = "Ott",
                DisplayName = "Mark Ott",
                Username = "m.ott",
                Email = "m.ott@tfs2.com",
                Disabled = true,
            });

            // Program Data
            var position_pilot = session.Save(new Position()
            {
                Title = "Pilot",
            });
            session.Save(new Position()
            {
                Title = "Flight Engineer",
            });
            session.Save(new Position()
            {
                Title = "Loadmaster",
            });

            // Person Data
            var person_joseph_entity = new Person()
            {
                User = session.Get<User>(user_joseph),
                HirePosition = session.Get<Position>(position_pilot),
                DateOfBirth = new DateTime(1985, 5, 2).ToUniversalTime(),
            };
            person_joseph_entity.Qualifications = new Qualifications()
            {
                Person = person_joseph_entity,
            };
            var person_joseph = session.Save(person_joseph_entity);

            var person_bill_entity = new Person()
            {
                User = session.Get<User>(user__bill),
                HirePosition = session.Get<Position>(position_pilot),
                DateOfBirth = new DateTime(1985, 5, 2).ToUniversalTime(),
            };
            person_bill_entity.Qualifications = new Qualifications()
            {
                Person = person_bill_entity,
            };
            var person_bill = session.Save(person_bill_entity);

            for (int i = 0; i < 50; i++)
            {
                var user = session.Save(new User
                {
                    FirstName = "Fake",
                    LastName = "User" + i,
                    DisplayName = "Fake User" + i,
                    Username = "f.user" + i,
                    Email = "f.user" + i + "@tfs2.com",
                    Disabled = false,
                });
                var person = new Person()
                {
                    User = session.Get<User>(user),
                    HirePosition = session.Get<Position>(position_pilot),
                };
                person.Qualifications = new Qualifications()
                {
                    Person = person,
                };
                session.Save(person);
            }

            // Example Flight Log Data
            var flightlog_example1 = session.Save(new FlightLog()
            {
                LogDate = DateTime.Now.ToUniversalTime(),
                LastModifiedDate = DateTime.Now.ToUniversalTime(),
                //Location = "Wako TX",
                AircraftMDS = "C-130J",
                AircraftSerialNumber = "THX 1138",
            });
            session.Save(new Mission()
            {
                FlightLog = session.Get<FlightLog>(flightlog_example1),
                Name = "Test Flight 1",
                FromICAO = "KATL",
                ToICAO = "KATL",
                TakeOffTime = "0930",
                LandingTime = "1645",
                TouchAndGos = 2,
                FullStops = 1,
                Sorties = 1,
                Totals = 1,
            });
            session.Save(new Mission()
            {
                FlightLog = session.Get<FlightLog>(flightlog_example1),
                Name = "Test Flight 2",
                FromICAO = "KATL",
                ToICAO = "KATL",
                TakeOffTime = "2200",
                LandingTime = "0100",
                TouchAndGos = 4,
                FullStops = 2,
                Sorties = 2,
                Totals = 1,
            });
            session.Save(new Mission()
            {
                FlightLog = session.Get<FlightLog>(flightlog_example1),
                Name = "Test Flight 2",
                FromICAO = "KATL",
                ToICAO = "KATL",
                TakeOffTime = "2359",
                LandingTime = "0100",
                TouchAndGos = 4,
                FullStops = 2,
                Sorties = 2,
                Totals = 1,
                AdditionalInfo = "Some Additional Info",
            });
            session.Save(new Mission()
            {
                FlightLog = session.Get<FlightLog>(flightlog_example1),
                Name = "Test Flight 2",
                FromICAO = "KATL",
                ToICAO = "KATL",
                TakeOffTime = "1200",
                LandingTime = "0000",
                TouchAndGos = 4,
                FullStops = 2,
                Sorties = 2,
                Totals = 1,
            });
            session.Save(new SquadronLog()
            {
                FlightLog = session.Get<FlightLog>(flightlog_example1),
                Person = session.Get<Person>(person_joseph),
                DutyCode = DutyCode.PIC,
                PrimaryHours = 2,
                Sorties = 3,
                PrimaryInstrumentHours = 3,
            });
            session.Save(new SquadronLog()
            {
                FlightLog = session.Get<FlightLog>(flightlog_example1),
                Person = session.Get<Person>(person_joseph),
                DutyCode = DutyCode.PIC,
                PrimaryHours = 2,
                Sorties = 3,
                PrimaryInstrumentHours = 3,
            });

            session.Transaction.Commit();
        }
    }
}
#endif