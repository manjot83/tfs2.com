using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFS.Models;
using System.ComponentModel.DataAnnotations;

namespace TFS.Web.ViewModels.FlightPrograms
{
    public class PositionViewModel
    {
        public Guid? Id { get; set; }

        [Required, StringLength(50)]
        public string Title { get; set; }
    }
}
