using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TFS.Models.Users
{
    public class UserRoles : BaseDomainEntity
    {
        [Required]
        [DomainEquality]
        public virtual bool UserManager { get; set; }

        [Required]
        [DomainEquality]
        public virtual bool PersonnelManager { get; set; }

        [Required]
        [DomainEquality]
        public virtual bool ProgramManager { get; set; }

        [Required]
        [DomainEquality]
        public virtual bool FlightLogManager { get; set; }
    }
}
