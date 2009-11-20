using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.Models.Users
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllActiveUsers();
        IEnumerable<User> GetAllUsers();
        User GetUser(string username);

        User AddUser(User user);
    }
}
