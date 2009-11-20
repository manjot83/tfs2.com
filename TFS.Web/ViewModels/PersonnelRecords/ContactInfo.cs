﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFS.Models;
using TFS.Models.Geography;
using System.ComponentModel.DataAnnotations;
using TFS.Models;

namespace TFS.Web.ViewModels.PersonnelRecords
{
    public class ContactInfo : BaseValidatableEntity
    {
        [Required]
        public virtual string AddressStreetAddress { get; set; }
        [Required]
        public virtual string AddressCity { get; set; }
        [Required]
        [RegularExpression(@"[A-Z,a-z]{2}", ErrorMessage = "Must contain state abbreviation.")]
        public virtual string AddressState { get; set; }
        [Required]
        [RegularExpression(@"\d{5}", ErrorMessage = "Must contain 5 numbers.")]
        public virtual string AddressZipCode { get; set; }
        [RegularExpression(RegExLib.USPhoneNumber, ErrorMessage = "Must contain a phone number")]
        public virtual string PrimaryPhoneNumber { get; set; }
        [RegularExpression(RegExLib.USPhoneNumber, ErrorMessage = "Must contain a phone number")]
        public virtual string AlternatePhoneNumber { get; set; }
        //[Required]        
        public virtual string AlternateEmail { get; set; }
        //[Required]
        public virtual string EmergencyContactName { get; set; }
        [RegularExpression(RegExLib.USPhoneNumber, ErrorMessage = "Must contain a phone number")]
        public virtual string EmergencyContactPhoneNumber { get; set; }
    }
}