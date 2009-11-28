using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFS.Models.PersonnelRecords;
using TFS.Models.FlightPrograms;
using System.Web.Mvc;

namespace TFS.Web.ViewModels.PersonnelRecords
{
    public class PersonnelRecordViewModel
    {
        public string Username { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public CompanyInfo CompanyInfo { get; set; }

        public bool EditingMyRecord { get; set; }
        public IEnumerable<SelectListItem> HirePositions { get; set; }

        public void SetHirePositions(IEnumerable<Position> hirePositions, Position currentPosition)
        {
            HirePositions = hirePositions.Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.Id.Value.ToString(),
                Selected = x == currentPosition
            }).OrderBy(x => x.Text);
        }
    }
}
