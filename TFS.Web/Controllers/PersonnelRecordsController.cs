using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TFS.Models;
using TFS.Models.Geography;
using TFS.Models.PersonnelRecords;
using TFS.Models.Programs;
using TFS.Web.ViewModels;
using TFS.Models.Reports;
using System;
using TFS.Web.ActionFilters;
using TFS.Models.Users;
using TFS.Web.ViewModels.PersonnelRecords;
using AutoMapper;

namespace TFS.Web.Controllers
{
    [DomainAuthorize]
    public partial class PersonnelRecordsController : Controller
    {
        private readonly UserManager userManager;
        private readonly IProgramsManager programsManager;

        public PersonnelRecordsController(UserManager userManager, IProgramsManager programsManager)
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

            IEnumerable<User> items = userManager.UserRepository.GetAllActiveUsers();
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
            var user = userManager.UserRepository.GetUser(username);
            var person = user.Person;
            if (person == null)
                person = userManager.CreatePersonFor(user);
            if (person.Qualifications == null)
                userManager.CreateQualificationsFor(person);
            var viewModel = GeneratePersonnelRecordViewModel(person, false);
            return View(MVC.PersonnelRecords.Views.EditRecord, viewModel);
        }

        [RequireTransaction]
        public virtual ViewResult EditMyRecord()
        {
            var user = userManager.UserRepository.GetUser(User.Identity.Name);
            var person = user.Person;
            if (person == null)
                person = userManager.CreatePersonFor(user);
            if (person.Qualifications == null)
                userManager.CreateQualificationsFor(person);
            var viewModel = GeneratePersonnelRecordViewModel(person, true);
            return View(MVC.PersonnelRecords.Views.EditRecord, viewModel);
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditPersonalInfo(string username, bool editingMyRecord, PersonalInfo personalInfo)
        {
            personalInfo.Validate(ModelState, string.Empty);
            var person = userManager.UserRepository.GetUser(username).Person;
            if (!ModelState.IsValid)
                return View(MVC.PersonnelRecords.Views.EditRecord, GeneratePersonnelRecordViewModel(person, editingMyRecord));
            Mapper.Map<PersonalInfo, Person>(personalInfo, person);
            if (editingMyRecord)
                return RedirectToAction(MVC.PersonnelRecords.EditMyRecord());
            else
                return RedirectToAction(MVC.PersonnelRecords.EditRecord(username));
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditContactInfo(string username, bool editingMyRecord, ContactInfo contactInfo)
        {
            contactInfo.Validate(ModelState, string.Empty);
            var person = userManager.UserRepository.GetUser(username).Person;
            if (USState.FromAbbreviation(contactInfo.AddressState.ToUpper()) == null)
                ModelState.AddModelError("State", "Must be a valid US state abbreviation.");
            if (!ModelState.IsValid)
                return View(MVC.PersonnelRecords.Views.EditRecord, GeneratePersonnelRecordViewModel(person, editingMyRecord));
            Mapper.Map<ContactInfo, Person>(contactInfo, person);
            if (editingMyRecord)
                return RedirectToAction(MVC.PersonnelRecords.EditMyRecord());
            else
                return RedirectToAction(MVC.PersonnelRecords.EditRecord(username));
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditCompanyInfo(string username, bool editingMyRecord, CompanyInfo companyInfo)
        {
            companyInfo.Validate(ModelState, string.Empty);
            var person = userManager.UserRepository.GetUser(username).Person;
            if (!ModelState.IsValid)
                return View(MVC.PersonnelRecords.Views.EditRecord, GeneratePersonnelRecordViewModel(person, editingMyRecord));
            Mapper.Map<CompanyInfo, Person>(companyInfo, person);
            person.HirePosition = programsManager.GetPositionById(companyInfo.HirePositionId.Value);
            if (editingMyRecord)
                return RedirectToAction(MVC.PersonnelRecords.EditMyRecord());
            else
                return RedirectToAction(MVC.PersonnelRecords.EditRecord(username));
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditQualifications(string username, bool editingMyRecord, QualificationViewModel qualifications)
        {
            qualifications.Validate(ModelState, string.Empty);
            var person = userManager.UserRepository.GetUser(username).Person;
            if (!ModelState.IsValid)
                return View(MVC.PersonnelRecords.Views.EditRecord, GeneratePersonnelRecordViewModel(person, editingMyRecord));

            if (editingMyRecord)
                return RedirectToAction(MVC.PersonnelRecords.EditMyRecord());
            else
                return RedirectToAction(MVC.PersonnelRecords.EditRecord(username));
        }

        private PersonnelRecordViewModel GeneratePersonnelRecordViewModel(Person person, bool editingMyRecord)
        {
            var viewModel = new PersonnelRecordViewModel();
            Mapper.Map<Person, PersonnelRecordViewModel>(person, viewModel);
            viewModel.EditingMyRecord = editingMyRecord;
            viewModel.SetHirePositions(programsManager.GetAllPositions(), person.HirePosition);
            return viewModel;
        }

        [RequireTransaction]
        public virtual FileContentResult DownloadAllAsCsv()
        {
            var users = userManager.UserRepository.GetAllActiveUsers().OrderBy(x => x.FileByName());
            var reportGenerator = new CsvReportGenerator(new PersonnelFileReport(users));
            var bytes = reportGenerator.GenerateReport();
            return File(bytes, "text/csv", "PersonnelRecords(" + DateTime.Now.ToString("MM-dd-yy") + ").csv");
        }
    }
}
