using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Centro.DomainModel;
using TFS.Models.PersonnelRecords;
using System.ComponentModel.DataAnnotations;

namespace TFS.Web.ViewModels
{
    public class PersonnelRecordCompanyInfo : BaseEntity
    {
        [Required]
        public virtual ShirtSize ShirtSize{ get; set; }
        [Required]
        public virtual FlightSuitSize FlightSuitSize { get; set; }
        [Required]
        public virtual int HirePositionId { get; set; }
    }
}
