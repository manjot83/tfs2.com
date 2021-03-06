﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Extensions;
using NHibernate;
using NHibernate.Linq;
using TFS.Models.PersonnelRecords;
using TFS.Models.Users;
using StructureMap;

namespace TFS.Models.Data.Implementations
{
    public class UserRepository : NHibernateRepository, IUserRepository
    {
        public UserRepository(INHibernateUnitOfWork nhibernateUnitOfWork, IContainer container)
            : base(nhibernateUnitOfWork, container)
        {
        }

        public User GetUser(string username)
        {
            return Query<User>().Where(x => x.Username == username).FirstOrDefault();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return Query<User>();
        }

        public IEnumerable<User> GetAllActiveUsers()
        {
            return Query<User>().Where(x => !x.Disabled);
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

        public IList<Person> GetAllActivePersons()
        {
            return GetAllActiveUsers()
                .ToList()
                .Where(x => x.Person != null)
                .Select(x => x.Person).ToList();
        }

        public Person GetPersonForUser(string username)
        {
            var user = GetUser(username);
            return user != null ? user.Person : null;
        }

        public User CreateUser(string username, string firstname, string lastname, string displayname, string title, int rateGroup, string passwordHash, string email = null)
        {
            var next_identity = this.UnitOfWork.Session.CreateSQLQuery("SELECT max([identity]) FROM Users").List<int>().Single();

            var user = new User
            {
                Username = username,
                FirstName = firstname,
                LastName = lastname,
                DisplayName = displayname,
                Title = title,
                RateGroup = rateGroup,
                Disabled = false,
                Identity = next_identity + 1,
                PasswordHash = passwordHash,
            };

            if (string.IsNullOrEmpty(email) || ! email.IsValidEmail())
            {
                user.SetDefaultEmailAddress(username);
            }
            else
            {
                user.Email = email;
            }
            
            user.Validate();
            return Persist<User>(user);
        }

        public Person CreatePersonFor(User user)
        {
            if (user.Person != null)
                throw new InvalidOperationException("User already has a Person object attached");
            var person = new Person
            {
                User = user,
            };
            user.Person = person;
            user.Validate();
            return person;
        }

        public Qualifications CreateQualificationsFor(Person person)
        {
            if (person.Qualifications != null)
                throw new InvalidOperationException("Person already has a Qualifications object attached");
            var qual = new Qualifications
            {
                Person = person,
            };
            person.Qualifications = qual;
            person.Validate();
            return qual;
        }
    }
}
