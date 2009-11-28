using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFS.Models;
using System.ComponentModel.DataAnnotations;

namespace TFS.Web.ViewModels.FlightPrograms
{
    public class FlightProgramListItemViewModel : BaseValidatableObject
    {
        public int? Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string AccountName { get; set; }
        [Required]
        public bool Active { get; set; }

        public int? LocationsCount { get; set; }

        public string GetStatus()
        {
            if (Active)
                return "Active";
            else
                return "Inactive";
        }
    }
}
