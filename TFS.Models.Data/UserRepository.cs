using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Centro.Data.DomainModel;
using Centro.Extensions;
using NHibernate;
using NHibernate.Linq;
using TFS.Models.PersonnelRecords;

namespace TFS.Models.Data
{
    public class UserRepository : BaseRepository, IUserRepository
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

        public User CreateUser(string username, string firstname, string lastname, string displayname)
        {
            var user = new User
            {
                Username = username,
                FirstName = firstname,
                LastName = lastname,
                DisplayName = displayname,
                Disabled = false,
            };
            user.SetDefaultEmailAddress(username);
            return (User)Session.SaveOrUpdateCopy(user);
        }

        public Person CreatePersonFor(User user)
        {
            var person = new Person
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                User = user,
            };
            person = (Person)Session.SaveOrUpdateCopy(person);
            user.Person = person;
            return person;
        }
    }
}
