using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using TFS.Models.FlightLogs;

namespace TFS.Models.Reports
{
    [XmlRoot(ElementName = "FlightTimeSummary")]
    public class FlightTimeSummaryReport : IReport
    {
        string IReport.StylesheetResourceName
        {
            get { return "TFS.Models.Reports.FlightTimeSummary.xsl"; }
        }

        private MissionLog missionLog;

        public FlightTimeSummaryReport()
        {
            // Required for serialization
        }

        public FlightTimeSummaryReport(MissionLog missionLog)
        {
            this.missionLog = missionLog;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotSupportedException("Cannot deserialize a report");
        }

        public void WriteXml(XmlWriter writer)
        {
            WriteMissionLogAttributes(writer);
            WriteMissionLogElements(writer);
            writer.WriteStartElement("Missions");
            for (int i = 0; i < missionLog.Missions.Count; i++)
            {
                WriteMissionElement(writer, missionLog.Missions[i], i + 1);
            }
            writer.WriteEndElement();
            writer.WriteStartElement("Squadron");
            foreach (var member in missionLog.SquadronLogs)
            {
                WriteSquadronMember(writer, member);
            }
            writer.WriteEndElement();
        }

        private void WriteSquadronMember(XmlWriter writer, SquadronLog member)
        {
            writer.WriteStartElement("Member");
            writer.WriteElementString("FlyingUnit", member.FlyingUnit);
            writer.WriteElementString("Name", member.Person.FileByName());
            writer.WriteElementString("SSN", member.Person.SocialSecurityLastFour);
            writer.WriteElementString("DutyCode", member.DutyCode.ToString());
            writer.WriteElementString("Primary", member.PrimaryHours.ToString("N"));
            writer.WriteElementString("Secondary", member.SecondaryHours.ToString("N"));
            writer.WriteElementString("Instructor", member.InstructorHours.ToString("N"));
            writer.WriteElementString("Evaluator", member.EvaluatorHours.ToString("N"));
            writer.WriteElementString("Other", member.OtherHours.ToString("N"));
            writer.WriteElementString("Sorties", member.Sorties.ToString("N"));
            writer.WriteElementString("PrimaryNight", member.PrimaryNightHours.ToString("N"));
            writer.WriteElementString("PrimaryInstrument", member.PrimaryInstrumentHours.ToString("N"));
            writer.WriteElementString("SimulatedInstrument", member.SimulatedInstrumentHours.ToString("N"));
            writer.WriteElementString("Total", member.CalculateTotalHours().ToString("N"));
            writer.WriteEndElement();
        }

        private void WriteMissionElement(XmlWriter writer, Mission mission, int id)
        {
            writer.WriteStartElement("Mission");
            writer.WriteElementString("Id", id.ToString());
            writer.WriteElementString("Name", mission.Name);
            writer.WriteElementString("From", mission.FromICAO);
            writer.WriteElementString("To", mission.ToICAO);
            writer.WriteElementString("TakeOff", mission.TakeOffTime);
            writer.WriteElementString("Landing", mission.LandingTime);
            writer.WriteElementString("FlightTime", mission.ComputeFlightTime().TotalHours.ToString("N"));
            writer.WriteElementString("TouchAndGos", mission.TouchAndGos.ToString());
            writer.WriteElementString("FullStops", mission.FullStops.ToString());
            writer.WriteElementString("Sorties", mission.Sorties.ToString());
            writer.WriteElementString("Totals", mission.Totals.ToString());
            writer.WriteElementString("SpecialUse", mission.AdditionalInfo);
            writer.WriteEndElement();
        }

        private void WriteMissionLogElements(XmlWriter writer)
        {
            writer.WriteElementString("TotalCalculatedFlightTime", missionLog.CalculateTotalFlightTime().ToString("N"));
            writer.WriteElementString("TotalTouchAndGos", missionLog.CalculateTotalTouchAndGos().ToString());
            writer.WriteElementString("TotalFullStops", missionLog.CalculateTotalFullStops().ToString());
            writer.WriteElementString("TotalTotals", missionLog.CalculateTotals().ToString());
            writer.WriteElementString("TotalSorties", missionLog.CalculateTotalSorties().ToString());
        }

        private void WriteMissionLogAttributes(XmlWriter writer)
        {
            writer.WriteAttributeString("Date", missionLog.LogDate.ToString("MM/dd/yy"));
            writer.WriteAttributeString("MDS", missionLog.AircraftMDS);
            writer.WriteAttributeString("SerialNumber", missionLog.AircraftSerialNumber);
            writer.WriteAttributeString("Location", missionLog.Location);
            writer.WriteAttributeString("OperatingUnit", missionLog.OperatingUnit);
            writer.WriteAttributeString("GeneratedDate", DateTime.UtcNow.ToString("MM/dd/yy"));
        }
    }
}
