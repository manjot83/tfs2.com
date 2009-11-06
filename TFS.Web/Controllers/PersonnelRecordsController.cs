using System;
using System.Linq;
using System.Web.Mvc;
using Centro.Web.Mvc;
using Centro.Web.Mvc.ActionFilters;
using TFS.Models;
using TFS.Models.Geography;
using TFS.Models.PersonnelRecords;
using TFS.Models.Programs;
using TFS.Web.ViewModels;
using System.Web.UI.WebControls;

namespace TFS.Web.Controllers
{
    [Authorize]
    public partial class PersonnelRecordsController : Controller
    {
        private readonly IPersonnelRecordsRepository personnelRecordsRepository;
        private readonly IProgramsRepository programsRepository;

        public PersonnelRecordsController(IPersonnelRecordsRepository personnelRecordsRepository, IProgramsRepository programsRepository)
        {
            this.personnelRecordsRepository = personnelRecordsRepository;
            this.programsRepository = programsRepository;
        }

        [RequireTransaction]
        public virtual ViewResult List(string sortType, SortDirection? sortDirection, int? page, int? itemsPerPage)
        {
            if (string.IsNullOrEmpty(sortType))
                sortType = "name";
            var viewModel = new SortedListViewModel<Person>()
            {
                SortDirection = sortDirection ?? SortDirection.Ascending,
                SortType = sortType,
                PagingEnabled = true,
                CurrentPage = page.HasValue ? page.Value : 1,
                ItemsPerPage = itemsPerPage.HasValue ? itemsPerPage.Value : SortedListViewModel<Person>.DefaultItemsPerPage,
            };

            var items = personnelRecordsRepository.GetAllRecords();
            viewModel.TotalItems = items.Count();
            viewModel.Items = items.Skip(viewModel.ItemsPerPage * (viewModel.CurrentPage - 1)).Take(viewModel.ItemsPerPage).ToList();

            return View(Views.List, viewModel);
        }

        [RequireTransaction]
        public virtual ViewResult EditMyRecord()
        {
            var person = personnelRecordsRepository.GetPerson(this.GetCurrentUser());
            if (person == null)
                person = personnelRecordsRepository.CreatePersonnelRecordFor(this.GetCurrentUser());
            var viewModel = GeneratePersonnelRecordViewModel(person, true);
            return View(MVC.PersonnelRecords.Views.EditRecord, viewModel);
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditPersonalInfo(string username, bool editingMyRecord, PersonnelRecordPersonalInfo personalInfo)
        {
            personalInfo.Validate(ModelState, string.Empty);
            var person = personnelRecordsRepository.GetPerson(username);
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
                throw new NotImplementedException();
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditContactInfo(string username, bool editingMyRecord, PersonnelRecordContactInfo contactInfo)
        {
            contactInfo.Validate(ModelState, string.Empty);
            var person = personnelRecordsRepository.GetPerson(username);
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
                throw new NotImplementedException();
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditCompanyInfo(string username, bool editingMyRecord, PersonnelRecordCompanyInfo companyInfo)
        {
            companyInfo.Validate(ModelState, string.Empty);
            var person = personnelRecordsRepository.GetPerson(username);
            if (!ModelState.IsValid)
                return View(MVC.PersonnelRecords.Views.EditRecord, GeneratePersonnelRecordViewModel(person, editingMyRecord));
            person.FlightSuitSize = companyInfo.FlightSuitSize;
            person.ShirtSize = companyInfo.ShirtSize;
            person.HirePosition = programsRepository.GetPositionById(companyInfo.HirePositionId);
            if (editingMyRecord)
                return RedirectToAction(MVC.PersonnelRecords.EditMyRecord());
            else
                throw new NotImplementedException();
        }

        private PersonnelRecordViewModel GeneratePersonnelRecordViewModel(Person person, bool editingMyRecord)
        {
            var viewModel = new PersonnelRecordViewModel
            {
                EditingMyRecord = editingMyRecord,
                Record = person,
            };
            viewModel.SetHirePositions(programsRepository.GetAllPositions(), person.HirePosition);
            return viewModel;
        }

    }
}
