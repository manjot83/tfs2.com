using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AutoMapper;
using TFS.Models.Geography;
using TFS.Models.PersonnelRecords;
using TFS.Models.FlightPrograms;
using TFS.Models.Reports;
using TFS.Models.Users;
using TFS.Web.ActionFilters;
using TFS.Web.ViewModels;
using TFS.Web.ViewModels.PersonnelRecords;
using TFS.Models;
using NHibernate;

namespace TFS.Web.Controllers
{
    [Authorize]
    public partial class PersonnelRecordsController : Controller
    {
        private readonly ISession session;
        private readonly IUserRepository userRepository;
        private readonly IFlightProgramsRepository flightProgramsRepository;

        public PersonnelRecordsController(ISession session, IUserRepository userRepository, IFlightProgramsRepository flightProgramsRepository)
        {
            this.session = session;
            this.userRepository = userRepository;
            this.flightProgramsRepository = flightProgramsRepository;
        }

        [UnitOfWork]
        public virtual ViewResult List(string sortType, SortDirection? sortDirection, int? page, int? itemsPerPage)
        {
            if (string.IsNullOrEmpty(sortType))
                sortType = "name";
            var viewModel = new SortedListViewModel<PersonnelRecordListViewModel>
            {
                SortDirection = sortDirection ?? SortDirection.Ascending,
                SortType = sortType,
                PagingEnabled = true,
                CurrentPage = page.HasValue ? page.Value : 1,
                ItemsPerPage = itemsPerPage.HasValue ? itemsPerPage.Value : SortedListViewModel<PersonnelRecordListViewModel>.DefaultItemsPerPage,
            };

            IEnumerable<User> users = userRepository.GetAllActiveUsers().ToList();
            var items = Mapper.Map<IEnumerable<User>, IEnumerable<PersonnelRecordListViewModel>>(users);
            if (viewModel.IsCurrentSortType("name") && viewModel.SortDirection == SortDirection.Ascending)
                items = items.OrderBy(x => x.FileByName);
            else if (viewModel.IsCurrentSortType("name"))
                items = items.OrderByDescending(x => x.FileByName);
            if (viewModel.IsCurrentSortType("status") && viewModel.SortDirection == SortDirection.Ascending)
                items = items.OrderBy(x => x.Status);
            else if (viewModel.IsCurrentSortType("status"))
                items = items.OrderByDescending(x => x.Status);
            viewModel.SetItems(items.ToList());

            return View(Views.List, viewModel);
        }

        [UnitOfWork]
        public virtual ViewResult EditRecord(string username)
        {
            var user = userRepository.GetUser(username);
            var person = user.Person;
            if (person == null)
                person = userRepository.CreatePersonFor(user);
            if (person.Qualifications == null)
                userRepository.CreateQualificationsFor(person);
            var viewModel = GeneratePersonnelRecordViewModel(person, false);
            return View(MVC.PersonnelRecords.Views.EditRecord, viewModel);
        }

        [UnitOfWork]
        public virtual ViewResult EditMyRecord()
        {
            var user = this.GetCurrentUser();
            var person = user.Person;
            if (person == null)
                person = userRepository.CreatePersonFor(user);
            if (person.Qualifications == null)
                userRepository.CreateQualificationsFor(person);
            var viewModel = GeneratePersonnelRecordViewModel(person, true);
            return View(MVC.PersonnelRecords.Views.EditRecord, viewModel);
        }

        [UnitOfWork]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditPersonalInfo(string username, bool editingMyRecord, PersonalInfo personalInfo)
        {
            personalInfo.Validate(ModelState, string.Empty);
            var person = this.GetUser(username).Person;
            if (!ModelState.IsValid)
                return View(MVC.PersonnelRecords.Views.EditRecord, GeneratePersonnelRecordViewModel(person, editingMyRecord));
            Mapper.Map<PersonalInfo, Person>(personalInfo, person);
            if (editingMyRecord)
                return RedirectToAction(MVC.PersonnelRecords.EditMyRecord());
            else
                return RedirectToAction(MVC.PersonnelRecords.EditRecord(username));
        }

        [UnitOfWork]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditContactInfo(string username, bool editingMyRecord, ContactInfo contactInfo)
        {
            contactInfo.Validate(ModelState, string.Empty);
            var person = this.GetUser(username).Person;
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

        [UnitOfWork]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditCompanyInfo(string username, bool editingMyRecord, CompanyInfo companyInfo)
        {
            companyInfo.Validate(ModelState, string.Empty);
            var person = this.GetUser(username).Person;
            if (!ModelState.IsValid)
                return View(MVC.PersonnelRecords.Views.EditRecord, GeneratePersonnelRecordViewModel(person, editingMyRecord));
            Mapper.Map<CompanyInfo, Person>(companyInfo, person);
            person.HirePosition = session.Get<Position>(companyInfo.HirePositionId.Value);
            if (editingMyRecord)
                return RedirectToAction(MVC.PersonnelRecords.EditMyRecord());
            else
                return RedirectToAction(MVC.PersonnelRecords.EditRecord(username));
        }

        [UnitOfWork]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditQualifications(string username, bool editingMyRecord, QualificationViewModel qualifications)
        {
            qualifications.Validate(ModelState, string.Empty);
            var person = this.GetUser(username).Person;
            if (!ModelState.IsValid)
                return View(MVC.PersonnelRecords.Views.EditRecord, GeneratePersonnelRecordViewModel(person, editingMyRecord));

            if (editingMyRecord)
                return RedirectToAction(MVC.PersonnelRecords.EditMyRecord());
            else
                return RedirectToAction(MVC.PersonnelRecords.EditRecord(username));
        }

        [NonAction]
        private PersonnelRecordViewModel GeneratePersonnelRecordViewModel(Person person, bool editingMyRecord)
        {
            var viewModel = new PersonnelRecordViewModel();
            Mapper.Map<Person, PersonnelRecordViewModel>(person, viewModel);
            viewModel.EditingMyRecord = editingMyRecord;
            viewModel.SetHirePositions(flightProgramsRepository.GetAllPositions(), person.HirePosition);
            return viewModel;
        }

        [UnitOfWork]
        public virtual FileContentResult DownloadAllAsCsv()
        {
            var users = userRepository.GetAllActiveUsers().OrderBy(x => x.FileByName());
            var reportGenerator = new CsvReportGenerator(new PersonnelFileReport(users));
            var bytes = reportGenerator.GenerateReport();
            return File(bytes, "text/csv", "PersonnelRecords(" + DateTime.Now.ToString("MM-dd-yy") + ").csv");
        }
    }
}
