using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Extensions;
using NHibernate;
using NHibernate.Linq;
using TFS.Models.PersonnelRecords;
using TFS.Models.Users;

namespace TFS.Models.Data.Users
{
    public class UserRepository : BaseDataAccessObject, IUserRepository
    {
        public UserRepository(ISession session)
            : base(session)
        {
        }

        public User GetUser(string username)
        {
            return Session.Linq<User>().Where(x => x.Username == username).FirstOrDefault();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return Session.Linq<User>();
        }

        public IEnumerable<User> GetAllActiveUsers()
        {
            return Session.Linq<User>().Where(x => !x.Disabled);
        }

        //public bool AuthenticateUser(string username, string password)
        //{
        //    if (string.IsNullOrEmpty(password))
        //        return false;
        //    var user = GetUser(username);
        //    if (user == null)
        //        return false;
        //    if (string.IsNullOrEmpty(user.PasswordHash))
        //        return false;
        //    var suppliedPasswordHash = password.Hash(Crypto.HashAlgorithm.SHA1);
        //    return user.PasswordHash.Equals(suppliedPasswordHash);
        //}
        //public bool ResetPasswordAsAdmin(string username, string password)
        //{
        //    return ResetPasswordAsAdmin(GetUser(username), password);
        //}

        //public bool ResetPasswordAsAdmin(User user, string password)
        //{
        //    if (user == null)
        //        return false;
        //    user.PasswordHash = password.Hash(Crypto.HashAlgorithm.SHA1);
        //    Session.SaveOrUpdate(user);
        //    return true;
        //}

        //public bool ChangePassword(string username, string oldPassword, string newPassword)
        //{
        //    return ChangePassword(GetUser(username), oldPassword, newPassword);
        //}

        //public bool ChangePassword(User user, string oldPassword, string newPassword)
        //{
        //    if (user == null)
        //        return false;
        //    if (!AuthenticateUser(user.Username, oldPassword))
        //        return false;
        //    if (string.IsNullOrEmpty(newPassword))
        //        return false;
        //    if (newPassword.Length < MinRequiredPasswordLength)
        //        return false;
        //    user.PasswordHash = newPassword.Hash(Crypto.HashAlgorithm.SHA1);
        //    Session.SaveOrUpdate(user);
        //    return true;
        //}

        public User AddUser(User user)
        {
            user.Validate();
            return Session.SaveOrUpdateCopy<User>(user);
        }
    }
}
