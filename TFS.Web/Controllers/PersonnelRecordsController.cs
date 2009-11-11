using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Centro.Web.Mvc;
using Centro.Web.Mvc.ActionFilters;
using TFS.Models;
using TFS.Models.Geography;
using TFS.Models.PersonnelRecords;
using TFS.Models.Programs;
using TFS.Web.ViewModels;
using TFS.Models.Reports;
using System;

namespace TFS.Web.Controllers
{
    [Authorize]
    public partial class PersonnelRecordsController : Controller
    {
        private readonly IUserManager userManager;
        private readonly IProgramsManager programsManager;

        public PersonnelRecordsController(IUserManager userManager, IProgramsManager programsManager)
        {
            this.userManager = userManager;
            this.programsManager = programsManager;
        }

        [RequireTransaction]
        public virtual ViewResult List(string sortType, SortDirection? sortDirection, int? page, int? itemsPerPage)
        {
            if (string.IsNullOrEmpty(sortType))
                sortType = "name";
            var viewModel = new PersonnelRecordListViewModel
            {
                SortDirection = sortDirection ?? SortDirection.Ascending,
                SortType = sortType,
                PagingEnabled = true,
                CurrentPage = page.HasValue ? page.Value : 1,
                ItemsPerPage = itemsPerPage.HasValue ? itemsPerPage.Value : SortedListViewModel<Person>.DefaultItemsPerPage,
            };

            IEnumerable<User> items = userManager.GetAllActiveUsers();
            if (viewModel.IsCurrentSortType("name") && viewModel.SortDirection == SortDirection.Ascending)
                items = items.OrderBy(x => x.FileByName());
            else if (viewModel.IsCurrentSortType("name"))
                items = items.OrderByDescending(x => x.FileByName());
            if (viewModel.IsCurrentSortType("status") && viewModel.SortDirection == SortDirection.Ascending)
                items = items.OrderBy(x => viewModel.GetMissionInformation(x));
            else if (viewModel.IsCurrentSortType("status"))
                items = items.OrderByDescending(x => viewModel.GetMissionInformation(x));
            viewModel.SetItems(items.ToList());

            return View(Views.List, viewModel);
        }

        [RequireTransaction]
        public virtual ViewResult EditRecord(string username)
        {
            var user = userManager.GetUser(username);
            var person = user.Person;
            if (person == null)
                person = userManager.CreatePersonFor(user);
            var viewModel = GeneratePersonnelRecordViewModel(person, false);
            return View(MVC.PersonnelRecords.Views.EditRecord, viewModel);
        }

        [RequireTransaction]
        public virtual ViewResult EditMyRecord()
        {
            var user = this.GetCurrentUser();
            var person = user.Person;
            if (person == null)
                person = userManager.CreatePersonFor(user);
            var viewModel = GeneratePersonnelRecordViewModel(person, true);
            return View(MVC.PersonnelRecords.Views.EditRecord, viewModel);
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditPersonalInfo(string username, bool editingMyRecord, PersonnelRecordPersonalInfo personalInfo)
        {
            personalInfo.Validate(ModelState, string.Empty);
            var person = userManager.GetUser(username).Person;
            if (!ModelState.IsValid)
                return View(MVC.PersonnelRecords.Views.EditRecord, GeneratePersonnelRecordViewModel(person, editingMyRecord));
            person.FirstName = personalInfo.FirstName;
            person.LastName = personalInfo.LastName;
            person.MiddleInitial = personalInfo.MiddleInitial;
            person.DateOfBirth = personalInfo.DateOfBirth.ToUniversalTime();
            person.Gender = personalInfo.Gender;
            person.SocialSecurityLastFour = personalInfo.SocialSecurityLastFour;
            if (editingMyRecord)
                return RedirectToAction(MVC.PersonnelRecords.EditMyRecord());
            else
                return RedirectToAction(MVC.PersonnelRecords.EditRecord(username));
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditContactInfo(string username, bool editingMyRecord, PersonnelRecordContactInfo contactInfo)
        {
            contactInfo.Validate(ModelState, string.Empty);
            var person = userManager.GetUser(username).Person;
            if (USState.FromAbbreviation(contactInfo.State.ToUpper()) == null)
                ModelState.AddModelError("State", "Must be a valid US state abbreviation.");
            if (!ModelState.IsValid)
                return View(MVC.PersonnelRecords.Views.EditRecord, GeneratePersonnelRecordViewModel(person, editingMyRecord));
            person.PrimaryPhoneNumber = RegExLib.ParseRegEx(contactInfo.PrimaryPhoneNumber, RegExLib.USPhoneNumber);
            person.AlternatePhoneNumber = RegExLib.ParseRegEx(contactInfo.AlternatePhoneNumber, RegExLib.USPhoneNumber);
            person.AlternateEmail = contactInfo.AlternateEmail;
            person.EmergencyContactName = contactInfo.EmergencyContactName;
            person.EmergencyContactPhoneNumber = RegExLib.ParseRegEx(contactInfo.EmergencyContactPhoneNumber, RegExLib.USPhoneNumber);
            if (person.Address == null)
                person.Address = new TFS.Models.Geography.USAddress();
            person.Address.StreetAddress = contactInfo.StreetAddress;
            person.Address.City = contactInfo.City;
            person.Address.State = USState.FromAbbreviation(contactInfo.State.ToUpper());
            person.Address.ZipCode = contactInfo.ZipCode;
            if (editingMyRecord)
                return RedirectToAction(MVC.PersonnelRecords.EditMyRecord());
            else
                return RedirectToAction(MVC.PersonnelRecords.EditRecord(username));
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditCompanyInfo(string username, bool editingMyRecord, PersonnelRecordCompanyInfo companyInfo)
        {
            companyInfo.Validate(ModelState, string.Empty);
            var person = userManager.GetUser(username).Person;
            if (!ModelState.IsValid)
                return View(MVC.PersonnelRecords.Views.EditRecord, GeneratePersonnelRecordViewModel(person, editingMyRecord));
            person.FlightSuitSize = companyInfo.FlightSuitSize;
            person.ShirtSize = companyInfo.ShirtSize;
            person.HirePosition = programsManager.GetPositionById(companyInfo.HirePositionId);
            if (editingMyRecord)
                return RedirectToAction(MVC.PersonnelRecords.EditMyRecord());
            else
                return RedirectToAction(MVC.PersonnelRecords.EditRecord(username));
        }

        private PersonnelRecordViewModel GeneratePersonnelRecordViewModel(Person person, bool editingMyRecord)
        {
            var viewModel = new PersonnelRecordViewModel
            {
                EditingMyRecord = editingMyRecord,
                Record = person,
            };
            viewModel.SetHirePositions(programsManager.GetAllPositions(), person.HirePosition);
            return viewModel;
        }

        [RequireTransaction]
        public virtual FileContentResult DownloadAllAsCsv()
        {
            var users = userManager.GetAllActiveUsers().OrderBy(x => x.FileByName());
            var reportGenerator = new CsvReportGenerator(new PersonnelFileReport(users));
            var bytes = reportGenerator.GenerateReport();
            return File(bytes, "text/csv", "PersonnelRecords(" + DateTime.Now.ToString("MM-dd-yy") + ").csv");
        }
    }
}
