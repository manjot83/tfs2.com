using System;
using System.Collections.Generic;
using TFS.Helpers;
using NUnit.Framework;
using TFS.Models.FlightLogs;
using TFS.Models.PersonnelRecords;
using TFS.Models.Reports;
using System.IO;
using System.Diagnostics;
using Iesi.Collections.Generic;
using TFS.Models.Users;

namespace TFS.Models.Tests.Reports
{
    [TestFixture]
    public class FlightTimeSummaryTests
    {
        private FlightLog CreateFlightLog()
        {
            var flightLog = new FlightLog
            {
                LogDate = DateTime.UtcNow,
                AircraftMDS = "C130J",
                AircraftSerialNumber = "THX1138",
                Location = "Marietta, GA",
            };
            flightLog.Missions = new HashedSet<Mission>
            {
                new Mission
                {
                    FlightLog = flightLog,
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
                    FlightLog = flightLog,
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
            flightLog.SquadronLogs = new HashedSet<SquadronLog>
            {
                new SquadronLog
                {
                    FlightLog = flightLog,
                    Person = new Person
                    {
                        User = new User 
                        {
                            FirstName = "Joseph",
                            LastName = "Daigle",
                        },
                        SocialSecurityLastFour = "0728",
                    },
                    DutyCode = DutyCode.PIC,
                    PrimaryHours = 2,
                    Sorties = 3,
                    PrimaryInstrumentHours = 3,
                },
                new SquadronLog
                {
                    FlightLog = flightLog,
                    Person = new Person
                    {
                        User = new User 
                        {
                            FirstName = "Joseph",
                            LastName = "Daigle",
                        },   
                        SocialSecurityLastFour = "0728",
                    },
                    DutyCode = DutyCode.EP,
                    PrimaryHours = 2,
                    Sorties = 3,
                    PrimaryInstrumentHours = 3,
                },
            };
            return flightLog;
        }

        [Test]
        public void Should_Serialize_To_Xml()
        {
            var report = new FlightTimeSummaryReport(CreateFlightLog());
            var xml = report.ConvertToXml<FlightTimeSummaryReport>();
            Console.Out.WriteLine(xml);
        }

        [Test]
        public void Should_Compile_XSLT()
        {
            new PdfReportGenerator(new FlightTimeSummaryReport(CreateFlightLog()));
        }

        [Test]
        public void Should_Generate_XML()
        {
            var xml = new PdfReportGenerator(new FlightTimeSummaryReport(CreateFlightLog())).GenerateXml();
            Console.Out.WriteLine(xml.ToString());
        }

        [Test]
        public void Should_Generate_XSLFO()
        {
            var xslfo = new PdfReportGenerator(new FlightTimeSummaryReport(CreateFlightLog())).GenerateXslFo();
            Console.Out.WriteLine(xslfo.ToString());
        }

        [Test]
        public void Should_Generate_PDF()
        {
            var bytes = new PdfReportGenerator(new FlightTimeSummaryReport(CreateFlightLog())).GenerateReport();
            var fileName = Path.GetTempFileName() + ".pdf";
            File.WriteAllBytes(fileName, bytes);
            Process.Start(fileName);
        }
    }
}
