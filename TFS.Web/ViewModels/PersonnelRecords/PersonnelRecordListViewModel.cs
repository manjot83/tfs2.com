using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFS.Models;
using TFS.Models.Users;

namespace TFS.Web.ViewModels.PersonnelRecords
{
    public class PersonnelRecordListViewModel
    {
        public string FileByName { get; set; }
        public string Username { get; set; }
        public string Status { get; set; }

        public static string GetStatus(User user)
        {
            if (user.Person == null)
                return  "Personnel record not started";
            else if (user.Person.SocialSecurityLastFour == null)
                return "Missing SSN";
            else if (user.Person.DateOfBirth == null)
                return "Missing DoB";
            else if (user.Person.PrimaryPhoneNumber == null ||
                user.Person.EmergencyContactName == null ||
                user.Person.EmergencyContactPhoneNumber == null ||
                user.Person.Address == null)
                return "Missing Contact Info";
            else
                return string.Empty;
        }
    }
}
