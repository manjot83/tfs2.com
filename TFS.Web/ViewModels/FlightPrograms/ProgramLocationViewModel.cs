using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFS.Models;
using System.ComponentModel.DataAnnotations;

namespace TFS.Web.ViewModels.FlightPrograms
{
    public class ProgramLocationViewModel
    {
        public Guid? Id { get; set; }

        public Guid ProgramId { get; set; }
        public string ProgramName { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
    }
}
