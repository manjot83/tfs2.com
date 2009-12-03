using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.PersonnelRecords;

namespace TFS.Models.Users
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllActiveUsers();
        IEnumerable<User> GetAllUsers();
        User GetUser(string username);

        User AddUser(User user);

        IList<Person> GetAllActivePersons();
        Person GetPersonForUser(string username);
    }
}
