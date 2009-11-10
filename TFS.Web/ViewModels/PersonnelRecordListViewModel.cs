using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFS.Models;

namespace TFS.Web.ViewModels
{
    public class PersonnelRecordListViewModel : SortedListViewModel<User>
    {
        public string GetMissionInformation(User user)
        {
            if (user.Person == null)
                return "Personnel record not started";
            if (user.Person.SocialSecurityLastFour == null)
                return "Missing SSN";
            if (user.Person.DateOfBirth == null)
                return "Missing DoB";
            if (user.Person.PrimaryPhoneNumber == null ||
                user.Person.EmergencyContactName == null ||
                user.Person.EmergencyContactPhoneNumber == null ||
                user.Person.Address == null)
                return "Missing Contact Info";
            return string.Empty;
        }
    }
}
