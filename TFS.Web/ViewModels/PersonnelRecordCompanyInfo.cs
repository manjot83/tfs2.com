using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFS.Models;
using TFS.Models.PersonnelRecords;
using System.ComponentModel.DataAnnotations;

namespace TFS.Web.ViewModels
{
    public class PersonnelRecordCompanyInfo : BaseValidatableEntity
    {
        [Required]
        public virtual ShirtSize ShirtSize{ get; set; }
        [Required]
        public virtual FlightSuitSize FlightSuitSize { get; set; }
        [Required]
        public virtual int HirePositionId { get; set; }
    }
}
