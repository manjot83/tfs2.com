using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.Models.PersonnelRecords
{
    public interface IPersonnelRecordsRepository
    {
        IList<Person> GetAllRecords();
        Person GetPerson(User user);
        Person GetPerson(string username);

        Person CreatePersonnelRecordFor(User user);
        Person CreatePersonnelRecordFor(string username);
    }
}
