﻿#if SQLITE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using NHibernate;
using TFS.Models;
using Centro.Extensions;
using TFS.Models.Programs;
using TFS.Models.PersonnelRecords;
using TFS.Models.FlightLogs;

namespace TFS.Web
{
    public static class SQLiteTestData
    {
        public static void Execute()
        {
            var session = ObjectFactory.GetInstance<ISession>();

            // Users
            var user_joseph = session.Save(new User
            {
                FirstName = "Joseph",
                LastName = "Daigle",
                DisplayName = "Joseph Daigle",
                Username = "j.daigle",
                Email = "j.daigle@tfs2.com",
                Disabled = false,
                PasswordHash = "j.daigle".Hash(Crypto.HashAlgorithm.SHA1),
            });
            var user__bill = session.Save(new User
            {
                FirstName = "Bill",
                LastName = "Petit",
                DisplayName = "Bill Petit",
                Username = "w.petit",
                Email = "w.petit@tfs2.com",
                Disabled = false,
                PasswordHash = "w.petit".Hash(Crypto.HashAlgorithm.SHA1),
            });
            session.Save(new User
            {
                FirstName = "Mark",
                LastName = "Ott",
                DisplayName = "Mark Ott",
                Username = "m.ott",
                Email = "m.ott@tfs2.com",
                Disabled = true,
                PasswordHash = null,
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
                FirstName = "Joe",
                LastName = "Daigle",
                DateOfBirth = new DateTime(1985, 5, 2),
            };
            person_joseph_entity.Qualifications = new Qualifications()
            {
                Person = person_joseph_entity,
            };
            var person_joseph = session.Save(person_joseph_entity);

            // Example Flight Log Data
            var missionlog_example1 = session.Save(new MissionLog()
            {
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Location = "Wako TX",
                AircraftModel = "C-130J",
                AircraftSerialNumber = "THX 1138",
            });
            session.Save(new Mission()
            {
                MissionLog = session.Get<MissionLog>(missionlog_example1),
                Name = "Test Flight 1",
                FromICAO = "KATL",
                ToICAO = "KATL",
                TakeOffTime = DateTime.Now.Subtract(new TimeSpan(5, 0, 0)),
                LandTime = DateTime.Now.Subtract(new TimeSpan(4, 0, 0)),
                TouchAndGos = 2,
                FullStops = 1,
                Sorties = 1,
                Totals = 1,
            });
            session.Save(new Mission()
            {
                MissionLog = session.Get<MissionLog>(missionlog_example1),
                Name = "Test Flight 2",
                FromICAO = "KATL",
                ToICAO = "KATL",
                TakeOffTime = DateTime.Now.Subtract(new TimeSpan(3, 0, 0)),
                LandTime = DateTime.Now.Subtract(new TimeSpan(2, 0, 0)),
                TouchAndGos = 4,
                FullStops = 2,
                Sorties = 2,
                Totals = 1,
            });
            session.Save(new SquadronLog()
            {
                MissionLog = session.Get<MissionLog>(missionlog_example1),
                Person = session.Get<Person>(person_joseph),
                DutyCode = DutyCode.PIC,
                PrimaryHours = 2,
                Sorties = 3,
                PrimaryInstrumentHours = 3,
            });
            session.Save(new SquadronLog()
            {
                MissionLog = session.Get<MissionLog>(missionlog_example1),
                Person = session.Get<Person>(person_joseph),
                DutyCode = DutyCode.PIC,
                PrimaryHours = 2,
                Sorties = 3,
                PrimaryInstrumentHours = 3,
            });
        }
    }
}
#endif