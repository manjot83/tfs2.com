using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TFS.Models.PersonnelRecords;
using TFS.Web.ViewModels;
using Centro.Web.Mvc;
using TFS.Models.Programs;
using Centro.Web.Mvc.ActionFilters;
using TFS.Models.Geography;

namespace TFS.Web.Controllers
{
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
        public virtual ViewResult Mine()
        {
            var person = personnelRecordsRepository.GetPerson(this.GetCurrentUser());
            if (person == null)
                person = personnelRecordsRepository.CreatePersonnelRecordFor(this.GetCurrentUser());
            var viewModel = GeneratePersonnelRecordViewModel(person, true);            
            return View(MVC.PersonnelRecords.Views.Edit, viewModel);
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditPersonalInfo(string username, bool editingMine, PersonnelRecordPersonalInfo personalInfo)
        {
            personalInfo.Validate(ModelState, string.Empty);
            var person = personnelRecordsRepository.GetPerson(username);
            if (!ModelState.IsValid)
                return View(MVC.PersonnelRecords.Views.Edit, GeneratePersonnelRecordViewModel(person, editingMine));
            person.FirstName = personalInfo.FirstName;
            person.LastName = personalInfo.LastName;
            person.MiddleInitial = personalInfo.MiddleInitial;
            person.DateOfBirth = personalInfo.DateOfBirth;
            person.Gender = personalInfo.Gender;
            person.SocialSecurityLastFour = personalInfo.SocialSecurityLastFour;
            personnelRecordsRepository.SaveOrUpdate(person);
            if (editingMine)
                return RedirectToAction(MVC.PersonnelRecords.Mine());
            else
                throw new NotImplementedException();
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditContactInfo(string username, bool editingMine, PersonnelRecordContactInfo contactInfo)
        {
            contactInfo.Validate(ModelState, string.Empty);
            var person = personnelRecordsRepository.GetPerson(username);
            if (USState.FromAbbreviation(contactInfo.State.ToUpper()) == null)
                ModelState.AddModelError("State", "Must be a valid US state abbreviation.");
            if (!ModelState.IsValid)
                return View(MVC.PersonnelRecords.Views.Edit, GeneratePersonnelRecordViewModel(person, editingMine));
            person.PrimaryPhoneNumber = contactInfo.PrimaryPhoneNumber;
            person.AlternatePhoneNumber = contactInfo.AlternatePhoneNumber;
            person.AlternateEmail = contactInfo.AlternateEmail;
            person.EmergencyContactName = contactInfo.EmergencyContactName;
            person.EmergencyContactPhoneNumber = contactInfo.EmergencyContactPhoneNumber;
            if (person.Address == null)
                person.Address = new TFS.Models.Geography.USAddress();
            person.Address.StreetAddress = contactInfo.StreetAddress;
            person.Address.City = contactInfo.City;
            person.Address.State = USState.FromAbbreviation(contactInfo.State.ToUpper());
            person.Address.ZipCode = contactInfo.ZipCode;
            if (editingMine)
                return RedirectToAction(MVC.PersonnelRecords.Mine());
            else
                throw new NotImplementedException();
        }

        private PersonnelRecordViewModel GeneratePersonnelRecordViewModel(Person person, bool editingMine)
        {
            return new PersonnelRecordViewModel
            {
                EditingMine = editingMine,
                Record = person,
                HirePositions = programsRepository.GetAllPositions(),
            };
        }

    }
}
