using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFS.Models;
using TFS.Models.PersonnelRecords;
using System.ComponentModel.DataAnnotations;
using TFS.Models.FlightLogs;

namespace TFS.Web.ViewModels.FlightLogs
{
    public class SquadronLogViewModel
    {
        public int? Id { get; set; }
        public int? FlightLogId { get; set; }

        public IList<Person> AvailablePersons { get; set; }

        public string PersonFileByName { get; set; }
        [Required]
        public string PersonUsername { get; set; }
        [Required]
        public DutyCode DutyCode { get; set; }
        [Required]
        public double PrimaryHours { get; set; }
        [Required]
        public double SecondaryHours { get; set; }
        [Required]
        public double InstructorHours { get; set; }
        [Required]
        public double EvaluatorHours { get; set; }
        [Required]
        public double OtherHours { get; set; }
        [Required]
        public int Sorties { get; set; }
        [Required]
        public double PrimaryNightHours { get; set; }
        [Required]
        public double PrimaryInstrumentHours { get; set; }
        [Required]
        public double SimulatedInstrumentHours { get; set; }

        public double TotalHours { get; set; }

        internal void SetAvailablePersons(IEnumerable<Person> availablePersons)
        {
            AvailablePersons = availablePersons.OrderBy(x => x.FileByName()).ToList();
        }
    }
}
