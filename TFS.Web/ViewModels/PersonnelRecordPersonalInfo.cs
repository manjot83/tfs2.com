using System;
using System.ComponentModel.DataAnnotations;
using Centro.DomainModel;
using TFS.Models.PersonnelRecords;

namespace TFS.Web.ViewModels
{
    public class PersonnelRecordPersonalInfo : BaseEntity
    {
        [Required, StringLength(50)]
        public virtual string LastName { get; set; }
        [Required, StringLength(50)]
        public virtual string FirstName { get; set; }
        [StringLength(5)]
        public virtual string MiddleInitial { get; set; }
        [Required]
        //[Range(typeof(DateTime), "01/01/1990", "01/01/2100")]
        public virtual DateTime DateOfBirth { get; set; }
        [Required]
        public virtual Gender Gender { get; set; }
        [Required, StringLength(4), RegularExpression(@"\d\d\d\d", ErrorMessage="Must contain 4 numbers.")]
        public virtual string SocialSecurityLastFour { get; set; }
    }
}
