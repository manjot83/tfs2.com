using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models;
using TFS.Models.Geography;
using TFS.Models.Programs;
using System.ComponentModel.DataAnnotations;

namespace TFS.Models.PersonnelRecords
{
    public class Person : BaseEntity, IKeyedModel
    {
        public virtual int? Id { get; private set; }

        public virtual User User { get; set; }

        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleInitial { get; set; }
        public virtual DateTime? DateOfBirth { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual string SocialSecurityLastFour { get; set; }

        public virtual USAddress Address { get; set; }
        public virtual string PrimaryPhoneNumber { get; set; }
        public virtual string AlternatePhoneNumber { get; set; }
        public virtual string AlternateEmail { get; set; }        
        public virtual string EmergencyContactName { get; set; }
        public virtual string EmergencyContactPhoneNumber { get; set; }

        public virtual ShirtSize ShirtSize { get; set; }
        public virtual FlightSuitSize FlightSuitSize { get; set; }

        public virtual Position HirePosition { get; set; }

        public virtual Qualifications Qualifications { get; set; }

        public virtual string FileByName()
        {
            return LastName + ", " + FirstName;
        }

        string IKeyedModel.Id
        {
            get { return User.Username; }
        }

        string IKeyedModel.DisplayText
        {
            get { return FileByName(); }
        }
    }
}
