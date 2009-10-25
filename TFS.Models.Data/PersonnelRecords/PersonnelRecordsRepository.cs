using System.Linq;
using Centro.Data.DomainModel;
using NHibernate;
using NHibernate.Linq;
using TFS.Models.PersonnelRecords;

namespace TFS.Models.Data.PersonnelRecords
{
    public class PersonnelRecordsRepository : BaseRepository, IPersonnelRecordsRepository
    {
        public PersonnelRecordsRepository(ISession session)
            : base(session)
        {
        }

        public Person GetPerson(User user)
        {
            return Session.Linq<Person>().Where(x => x.User.Equals(user)).FirstOrDefault();
        }

        public Person GetPerson(string username)
        {
            return Session.Linq<Person>().Where(x => x.User.Username == username).FirstOrDefault();
        }

        public Person CreatePersonnelRecordFor(User user)
        {
            var person = GetPerson(user);
            if (person != null)
                return person;
            person = new Person
            {
                User = user,
            };
            person.Qualifications = new Qualifications
            {
                Person = person,
            };
            Session.Save(person);
            return (Person)Session.SaveOrUpdateCopy(person);
        }

        public Person CreatePersonnelRecordFor(string username)
        {
            var person = GetPerson(username);
            if (person != null)
                return person;
            var user = Session.Linq<User>().Where(x => x.Username == username).FirstOrDefault();
            person = new Person
            {
                User = user,
            };
            person.Qualifications = new Qualifications
            {
                Person = person,
            };
            Session.Save(person);
            return (Person)Session.SaveOrUpdateCopy(person);
        }
    }
}
