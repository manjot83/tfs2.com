using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models;
using TFS.Models.PersonnelRecords;

namespace TFS.Models
{
    public interface IUserManager
    {
        IEnumerable<User> GetAllActiveUsers();
        IEnumerable<User> GetAllUsers();
        User GetUser(string username);        

        User CreateUser(string username, string firstname, string lastname, string displayname);

        Person CreatePersonFor(User user);
        Qualifications CreateQualificationsFor(Person person);
    }
}
