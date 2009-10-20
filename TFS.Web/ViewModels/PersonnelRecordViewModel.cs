using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFS.Models.PersonnelRecords;
using TFS.Models.Programs;

namespace TFS.Web.ViewModels
{
    public class PersonnelRecordViewModel
    {
        public IEnumerable<Position> HirePositions { get; set; }
        public Person Record { get; set; }
        public bool EditingMine { get; set; }
    }
}
