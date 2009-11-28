using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models;
using TFS.Models.PersonnelRecords;

namespace TFS.Models.Users
{
    public class UserManager
    {
        public UserManager(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public IUserRepository UserRepository { get; private set; }

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
            return UserRepository.AddUser(user);
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
            return qual;
        }
    }
}
