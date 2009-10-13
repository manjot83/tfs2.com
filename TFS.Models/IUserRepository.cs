using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Centro.DomainModel;

namespace TFS.Models
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUser(string username);

        bool AuthenticateUser(string username, string password);

        bool ResetPasswordAsAdmin(string username, string password);

        bool ResetPasswordAsAdmin(User user, string password);

        bool ChangePassword(string username, string oldPassword, string newPassword);

        bool ChangePassword(User user, string oldPassword, string newPassword);

        int MinRequiredPasswordLength { get; }
    }
}
