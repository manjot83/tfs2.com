using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models;
using TFS.Models.FlightLogs;
using System.Xml.Serialization;
using Centro.Helpers;
using System.Xml;

namespace TFS.Reports
{
    public class FlightTimeSummaryReportGenerator : ReportGenerator
    {
        public const string StylesheetResourceName = "TFS.Reports.FlightTimeSummary.xsl";

        public FlightTimeSummaryReportGenerator()
            : base(StylesheetResourceName)
        {
        }

        public override string GenerateXmlFor(IReportCapable domainObject)
        {
            if (!(domainObject is MissionLog))
                throw new ArgumentException(string.Format("Can only generate reports using types {0}", typeof(MissionLog).FullName));
            var missionLog = domainObject as MissionLog;
            var serializableMissionLog = new SerializableMissionLog(missionLog);
            return serializableMissionLog.ConvertToXml<SerializableMissionLog>();
        }

        [Serializable]
        [XmlRootAttribute(ElementName = "FlightTimeSummary")]
        public class SerializableMissionLog
        {
            public SerializableMissionLog()
            {
                GeneratedDate = DateTime.Now.ToShortDateString();
                OperatingUnit = "Tactical Flight Services";
                UnitCharged = "Tactical Flight Services";
            }
            public SerializableMissionLog(MissionLog missionLog)
                : this()
            {
                Date = missionLog.LogDate.ToString("MM/dd/yy");
                MDS = missionLog.AircraftMDS;
                Serial = missionLog.AircraftMDS;
                Location = missionLog.Location;
                var missions = new List<SerializableMission>();
                for (int i = 0; i < missionLog.Missions.Count; i++)
                {
                    var mission = missionLog.Missions[i];
                    missions.Add(new SerializableMission
                    {
                        Id = i.ToString(),
                        Name = mission.Name,
                        From = mission.FromICAO,
                        To = mission.ToICAO,
                        TakeOff = mission.TakeOffTime,
                        Landing = mission.LandingTime,
                        Flight = mission.ComputeFlightTime().TotalHours.ToString(),
                        TouchGo = mission.TouchAndGos.ToString(),
                        FullStop = mission.FullStops.ToString(),
                        Total = mission.Totals.ToString(),
                        Sorties = mission.Sorties.ToString(),
                        SpecialUse = mission.AdditionalInfo,
                    });
                }
                Missions = missions.ToArray();
                var squadronLogs = new List<SerializableSquadronLog>();
                for (int i = 0; i < missionLog.SquadronLogs.Count; i++)
                {
                    var squadronLog = missionLog.SquadronLogs[i];
                    squadronLogs.Add(new SerializableSquadronLog
                    {
                        FlyingUnit = "TFS",
                        SSN = squadronLog.Person.SocialSecurityLastFour,
                        Name = squadronLog.Person.FileByName(),
                        DutyCode = squadronLog.DutyCode.ToString(),
                        Primary = squadronLog.PrimaryHours.ToString(),
                        Secondary = squadronLog.SecondaryHours.ToString(),
                        Instructor = squadronLog.InstructorHours.ToString(),
                        Evaluator = squadronLog.EvaluatorHours.ToString(),
                        Other = squadronLog.OtherHours.ToString(),
                        Total = squadronLog.CalculateTotalHours().ToString(),
                        Sorties = squadronLog.Sorties.ToString(),
                        PrimaryNight = squadronLog.PrimaryNightHours.ToString(),
                        PrimaryInstructor = squadronLog.PrimaryInstrumentHours.ToString(),
                        SimulatedInstructor = squadronLog.SimulatedInstrumentHours.ToString(),

                    });
                }
                Squadron = squadronLogs.ToArray();
            }

            [XmlAttributeAttribute()]
            public string Date { get; set; }
            [XmlAttributeAttribute()]
            public string MDS { get; set; }
            [XmlAttributeAttribute()]
            public string Serial { get; set; }
            [XmlAttributeAttribute()]
            public string UnitCharged { get; set; }
            [XmlAttributeAttribute()]
            public string Location { get; set; }

            [XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            [XmlArrayItemAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false, ElementName = "Mission")]
            public SerializableMission[] Missions { get; set; }

            [XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            [XmlArrayItemAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false, ElementName = "Member")]
            public SerializableSquadronLog[] Squadron { get; set; }

            public string GeneratedDate { get; set; }
            public string OperatingUnit { get; set; }
            public string TotalFlightTime { get; set; }
            public string TotalTouchGo { get; set; }
            public string TotalFullStop { get; set; }
            public string TotalSorties { get; set; }
            public string PilotReview { get; set; }
            public string OpsReview { get; set; }
        }

        [Serializable]
        public class SerializableMission
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string From { get; set; }
            public string To { get; set; }
            public string TakeOff { get; set; }
            public string Landing { get; set; }
            public string Flight { get; set; }
            public string TouchGo { get; set; }
            public string FullStop { get; set; }
            public string Total { get; set; }
            public string Sorties { get; set; }
            public string SpecialUse { get; set; }
        }

        [Serializable]
        public class SerializableSquadronLog
        {
            public string FlyingUnit { get; set; }
            public string SSN { get; set; }
            public string Name { get; set; }
            public string DutyCode { get; set; }
            public string Primary { get; set; }
            public string Secondary { get; set; }
            public string Instructor { get; set; }
            public string Evaluator { get; set; }
            public string Other { get; set; }
            public string Total { get; set; }
            public string Sorties { get; set; }
            public string PrimaryNight { get; set; }
            public string PrimaryInstructor { get; set; }
            public string SimulatedInstructor { get; set; }
        }
    }
}
