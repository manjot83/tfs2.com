using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFS.Models;
using System.ComponentModel.DataAnnotations;

namespace TFS.Web.ViewModels.FlightPrograms
{
    public class AircraftViewModel
    {
        public Guid? Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        public bool Active { get; set; }

        public string GetStatus()
        {
            if (Active)
                return "Active";
            else
                return "Inactive";
        }
    }
}
