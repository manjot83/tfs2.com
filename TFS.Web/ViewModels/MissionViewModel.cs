using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFS.Models;
using System.ComponentModel.DataAnnotations;
using TFS.Models.FlightLogs;

namespace TFS.Web.ViewModels
{
    public class MissionViewModel : BaseValidatableEntity
    {
        public MissionViewModel()
        {
            Mission = new Mission();
        }

        public int FlightLogId { get; set; }

        public Mission Mission { get; set; }
    }
}
