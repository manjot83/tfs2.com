using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TFS.Models.FlightLogs;
using TFS.Models.Reports;
using System.IO;
using System.Diagnostics;
using TFS.Models.PersonnelRecords;

namespace TFS.Models.Tests.Reports
{
    [TestFixture]
    public class FlightTimeSummaryTests
    {
        private MissionLog GenerateMissionLog()
        {
            var missionLog = new MissionLog
            {
                LogDate = DateTime.UtcNow,
                AircraftMDS = "C130J",
                AircraftSerialNumber = "THX1138",
                Location = "Marietta, GA",
            };
            missionLog.Missions = new List<Mission>
            {
                new Mission
                {
                    MissionLog = missionLog,
                    Name = "Test Flight 1",
                    FromICAO = "KATL",
                    ToICAO = "KATL",
                    TakeOffTime = "0930",
                    LandingTime = "1645",
                    TouchAndGos = 2,
                    FullStops = 1,
                    Sorties = 1,
                    Totals = 1,
                    AdditionalInfo = "not empty",
                },
                new Mission
                {
                    MissionLog = missionLog,
                    Name = "Test Flight 2",
                    FromICAO = "KATL",
                    ToICAO = "KATL",
                    TakeOffTime = "2200",
                    LandingTime = "0100",
                    TouchAndGos = 4,
                    FullStops = 2,
                    Sorties = 2,
                    Totals = 1,
                    AdditionalInfo = "not empty",
                }
            };
            missionLog.SquadronLogs = new List<SquadronLog>
            {
                new SquadronLog
                {
                    MissionLog = missionLog,
                    Person = new Person
                    {
                        FirstName = "Joseph",
                        LastName = "Daigle",
                        SocialSecurityLastFour = "0728",
                    },
                    DutyCode = DutyCode.PIC,
                    PrimaryHours = 2,
                    Sorties = 3,
                    PrimaryInstrumentHours = 3,
                },
                new SquadronLog
                {
                    MissionLog = missionLog,
                    Person = new Person
                    {
                        FirstName = "Joseph",
                        LastName = "Daigle",
                        SocialSecurityLastFour = "0728",
                    },
                    DutyCode = DutyCode.EP,
                    PrimaryHours = 2,
                    Sorties = 3,
                    PrimaryInstrumentHours = 3,
                },
            };
            return missionLog;
        }

        [Test]
        public void Should_Compile_XSLT()
        {
            new ReportGenerator(GenerateMissionLog());
        }

        [Test]
        public void Should_Generate_XML()
        {
            var xml = new ReportGenerator(GenerateMissionLog()).GenerateXml();
            Console.Out.WriteLine(xml.ToString());
        }

        [Test]
        public void Should_Generate_XSLFO()
        {
            var xslfo = new ReportGenerator(GenerateMissionLog()).GenerateXslFo();
            Console.Out.WriteLine(xslfo.ToString());
        }

        [Test]
        public void Should_Generate_PDF()
        {
            var bytes = new ReportGenerator(GenerateMissionLog()).GenerateReport();
            var fileName = Path.GetTempFileName() + ".pdf";
            File.WriteAllBytes(fileName, bytes);
            Process.Start(fileName);
        }
    }
}
