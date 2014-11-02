using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.PersonnelRecords;

namespace TFS.Models.Users
{
    public interface IUserRepository : IRepository
    {
        IEnumerable<User> GetAllActiveUsers();
        IEnumerable<User> GetAllUsers();
        User GetUser(string username);

        IList<Person> GetAllActivePersons();
        Person GetPersonForUser(string username);

        User CreateUser(string username, string firstname, string lastname, string displayname, string title, int rateGroup);
        Person CreatePersonFor(User user);
        Qualifications CreateQualificationsFor(Person person);
    }
}
