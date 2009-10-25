using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Centro.DomainModel;

namespace TFS.Models
{
    public interface IUserRepository : IRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(string username);        

        User CreateUser(string username, string firstname, string lastname, string displayname);
    }
}
