using System.Linq;
using Centro.Data.DomainModel;
using NHibernate;
using NHibernate.Linq;
using TFS.Models.PersonnelRecords;
using System.Collections.Generic;
using NHibernate.Criterion;

namespace TFS.Models.Data.PersonnelRecords
{
    public class PersonnelRecordsRepository : BaseRepository, IPersonnelRecordsRepository
    {
        public PersonnelRecordsRepository(ISession session)
            : base(session)
        {
        }

        public IList<Person> GetAllRecords()
        {
            return Session.Linq<Person>().Where(x => !x.User.Disabled).ToList();
        }

        public Person GetPerson(User user)
        {
            return GetPerson(user.Username);
        }

        public Person GetPerson(string username)
        {
            return Session.Linq<Person>().Where(x => x.User.Username == username).FirstOrDefault();
        }

        public Person CreatePersonnelRecordFor(User user)
        {
            var person = new Person
            {
                User = user,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
            person.Qualifications = new Qualifications
            {
                Person = person,
            };
            Session.Save(person);
            Session.Save(person.Qualifications);
            return (Person)Session.SaveOrUpdateCopy(person);
        }

        public Person CreatePersonnelRecordFor(string username)
        {
            var user = Session.Linq<User>().Where(x => x.Username == username).FirstOrDefault();
            return CreatePersonnelRecordFor(user);
        }


    }
}
