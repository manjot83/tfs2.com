using System;
using AutoMapper;
using TFS.Models;
using TFS.Models.Geography;
using TFS.Models.PersonnelRecords;
using TFS.Models.Users;
using TFS.Web.ViewModels;
using TFS.Web.ViewModels.PersonnelRecords;
using TFS.Models.FlightLogs;
using TFS.Web.ViewModels.FlightLogs;
using TFS.Models.FlightPrograms;
using TFS.Web.ViewModels.FlightPrograms;
using TFS.Models.Messages;
using TFS.Web.ViewModels.Messages;

namespace TFS.Web
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeAutoMapper()
        {
            Setup_UserViewModel();
            Setup_PersonnelRecordViewModel();
            Setup_FlightLogViewModel();
            Setup_FlightPrograms();
            Setup_Messages();

#if DEBUG
            Mapper.AssertConfigurationIsValid();
#endif
        }

        private static void Setup_Messages()
        {
            Mapper.CreateMap<Message, MessageViewModel>()
                  .ForMember(x => x.CanEdit, m => m.Ignore());
            Mapper.CreateMap<Announcement, AnnouncementViewModel>()
                   .ForMember(x => x.CanEdit, m => m.Ignore());
            Mapper.CreateMap<UserAlert, UserAlertViewModel>()
                  .ForMember(x => x.ForUsername, m => m.MapFrom(x => x.User.Username))
                  .ForMember(x => x.ForFileByName, m => m.MapFrom(x => x.User.FileByName()))
                  .ForMember(x => x.CanEdit, m => m.Ignore());
            Mapper.CreateMap<SystemAlert, SystemAlertViewModel>()
                  .ForMember(x => x.CanEdit, m => m.Ignore());
        }

        private static void Setup_FlightPrograms()
        {
            Mapper.CreateMap<FlightProgram, FlightProgramListItemViewModel>();
            Mapper.CreateMap<FlightProgram, FlightProgramViewModel>();
            Mapper.CreateMap<FlightProgramViewModel, FlightProgram>()
                  .ForMember(x => x.Id, m => m.Ignore())
                  .ForMember(x => x.Locations, m => m.Ignore());
            Mapper.CreateMap<ProgramLocation, ProgramLocationViewModel>();
            Mapper.CreateMap<ProgramLocationViewModel, ProgramLocation>()
                  .ForMember(x => x.Id, m => m.Ignore())
                  .ForMember(x => x.Program, m => m.Ignore());
            Mapper.CreateMap<Position, PositionViewModel>();
            Mapper.CreateMap<PositionViewModel, Position>()
                   .ForMember(x => x.Id, m => m.Ignore());
        }

        private static void Setup_FlightLogViewModel()
        {
            Mapper.CreateMap<FlightLog, FlightLogListItemViewModel>()
                  .ForMember(x => x.Location, m => m.MapFrom(x => x.Location.Name))
                  .ForMember(x => x.Program, m => m.MapFrom(x => x.Location.Program.Name));
            Mapper.CreateMap<FlightLog, FlightLogViewModel>()
                  .ForMember(x => x.ActiveLocations, m => m.Ignore())
                  .ForMember(x => x.PreviouslySaved, m => m.Ignore());
            Mapper.CreateMap<FlightLogViewModel, FlightLog>()
                  .ForMember(x => x.LogDate, m => m.MapFrom(x => x.LogDate.ToUniversalTime()))
                  .ForMember(x => x.Id, m => m.Ignore())
                  .ForMember(x => x.LastModifiedDate, m => m.Ignore())
                  .ForMember(x => x.OperatingUnit, m => m.Ignore())
                  .ForMember(x => x.Missions, m => m.Ignore())
                  .ForMember(x => x.SquadronLogs, m => m.Ignore())
                  .ForMember(x => x.Location, m => m.Ignore());
            Mapper.CreateMap<Mission, MissionViewModel>()
                  .ForMember(x => x.FlightLogId, m => m.MapFrom(x => x.FlightLog.Id.Value))
                  .ForMember(x => x.TotalFlightTime, m => m.MapFrom(x => x.ComputeFlightTime().TotalHours));
            Mapper.CreateMap<MissionViewModel, Mission>()
                  .ForMember(x => x.Id, m => m.Ignore())
                  .ForMember(x => x.FlightLog, m => m.Ignore());
            Mapper.CreateMap<SquadronLog, TFS.Web.ViewModels.FlightLogs.SquadronLogViewModel>()
                  .ForMember(x => x.FlightLogId, m => m.MapFrom(x => x.FlightLog.Id.Value))
                  .ForMember(x => x.PersonUsername, m => m.MapFrom(x => x.Person.User.Username))
                  .ForMember(x => x.TotalHours, m => m.MapFrom(x => x.CalculateTotalHours()))
                  .ForMember(x => x.AvailablePersons, m => m.Ignore());
            Mapper.CreateMap<TFS.Web.ViewModels.FlightLogs.SquadronLogViewModel, SquadronLog>()
                  .ForMember(x => x.Id, m => m.Ignore())
                  .ForMember(x => x.FlightLog, m => m.Ignore())
                  .ForMember(x => x.FlyingUnit, m => m.Ignore())
                  .ForMember(x => x.Person, m => m.Ignore());
        }

        private static void Setup_PersonnelRecordViewModel()
        {
            Mapper.CreateMap<Person, PersonnelRecordViewModel>()
                  .ForMember(x => x.Username, m => m.MapFrom(x => x.User.Username))
                  .ForMember(x => x.PersonalInfo, m => m.MapFrom(x => x))
                  .ForMember(x => x.ContactInfo, m => m.MapFrom(x => x))
                  .ForMember(x => x.CompanyInfo, m => m.MapFrom(x => x))
                  .ForMember(x => x.EditingMyRecord, m => m.Ignore())
                  .ForMember(x => x.HirePositions, m => m.Ignore());
            Mapper.CreateMap<Person, PersonalInfo>()
                  .ForMember(x => x.FirstName, m => m.MapFrom(x => x.User.FirstName))
                  .ForMember(x => x.LastName, m => m.MapFrom(x => x.User.LastName));
            Mapper.CreateMap<Person, ContactInfo>()
                  .ForMember(x => x.AddressState, m => m.MapFrom(x => x.Address != null ? x.Address.State.Abbreviation : null));
            Mapper.CreateMap<Person, CompanyInfo>()
                  .ForMember(x => x.HirePositionId, m => m.MapFrom(x => x.HirePosition != null ? x.HirePosition.Id : null));
            Mapper.CreateMap<PersonalInfo, Person>()
                  .ForMember(x => x.Id, m => m.Ignore())
                  .ForMember(x => x.User, m => m.Ignore())
                  .ForMember(x => x.Qualifications, m => m.Ignore())
                  .ForMember(x => x.Address, m => m.Ignore())
                  .ForMember(x => x.AlternateEmail, m => m.Ignore())
                  .ForMember(x => x.AlternatePhoneNumber, m => m.Ignore())
                  .ForMember(x => x.EmergencyContactName, m => m.Ignore())
                  .ForMember(x => x.EmergencyContactPhoneNumber, m => m.Ignore())
                  .ForMember(x => x.FlightSuitSize, m => m.Ignore())
                  .ForMember(x => x.HirePosition, m => m.Ignore())
                  .ForMember(x => x.PrimaryPhoneNumber, m => m.Ignore())
                  .ForMember(x => x.ShirtSize, m => m.Ignore())
                  .ForMember(x => x.DateOfBirth, m => m.MapFrom(x => x.DateOfBirth.HasValue ? x.DateOfBirth.Value.ToUniversalTime() : (DateTime?)null))
                  .AfterMap((x,y) => {
                      y.User.FirstName = x.FirstName;
                      y.User.LastName = x.LastName;
                  });
            Mapper.CreateMap<ContactInfo, Person>()
                  .ForMember(x => x.Id, m => m.Ignore())
                  .ForMember(x => x.User, m => m.Ignore())
                  .ForMember(x => x.Qualifications, m => m.Ignore())
                  .ForMember(x => x.FlightSuitSize, m => m.Ignore())
                  .ForMember(x => x.HirePosition, m => m.Ignore())
                  .ForMember(x => x.ShirtSize, m => m.Ignore())
                  .ForMember(x => x.MiddleInitial, m => m.Ignore())
                  .ForMember(x => x.DateOfBirth, m => m.Ignore())
                  .ForMember(x => x.Gender, m => m.Ignore())
                  .ForMember(x => x.SocialSecurityLastFour, m => m.Ignore())
                  .ForMember(x => x.Address, m => m.MapFrom(x =>
                  {
                      return new USAddress
                      {
                          StreetAddress = x.AddressStreetAddress,
                          City = x.AddressCity,
                          State = USState.FromAbbreviation(x.AddressState.ToUpper()),
                          ZipCode = x.AddressZipCode,
                      };
                  }))
                  .ForMember(x => x.PrimaryPhoneNumber, m => m.MapFrom(x => RegExLib.ParseRegEx(x.PrimaryPhoneNumber, RegExLib.USPhoneNumber)))
                  .ForMember(x => x.AlternatePhoneNumber, m => m.MapFrom(x => RegExLib.ParseRegEx(x.AlternatePhoneNumber, RegExLib.USPhoneNumber)))
                  .ForMember(x => x.EmergencyContactPhoneNumber, m => m.MapFrom(x => RegExLib.ParseRegEx(x.EmergencyContactPhoneNumber, RegExLib.USPhoneNumber)));
            Mapper.CreateMap<CompanyInfo, Person>()
                  .ForMember(x => x.Id, m => m.Ignore())
                  .ForMember(x => x.User, m => m.Ignore())
                  .ForMember(x => x.Qualifications, m => m.Ignore())
                  .ForMember(x => x.Address, m => m.Ignore())
                  .ForMember(x => x.AlternateEmail, m => m.Ignore())
                  .ForMember(x => x.AlternatePhoneNumber, m => m.Ignore())
                  .ForMember(x => x.EmergencyContactName, m => m.Ignore())
                  .ForMember(x => x.EmergencyContactPhoneNumber, m => m.Ignore())
                  .ForMember(x => x.HirePosition, m => m.Ignore())
                  .ForMember(x => x.PrimaryPhoneNumber, m => m.Ignore())
                  .ForMember(x => x.MiddleInitial, m => m.Ignore())
                  .ForMember(x => x.DateOfBirth, m => m.Ignore())
                  .ForMember(x => x.Gender, m => m.Ignore())
                  .ForMember(x => x.SocialSecurityLastFour, m => m.Ignore());
            Mapper.CreateMap<User, PersonnelRecordListViewModel>()
                  .ForMember(x => x.FileByName, m => m.MapFrom(x => x.FileByName()))
                  .ForMember(x => x.Status, m => m.MapFrom(x => PersonnelRecordListViewModel.GetStatus(x)));
        }

        private static void Setup_UserViewModel()
        {
            Mapper.CreateMap<User, UserViewModel>();
            Mapper.CreateMap<UserViewModel, User>()
                  .ForMember(x => x.Id, m => m.Ignore())
                  .ForMember(x => x.Email, m => m.Ignore())
                  .ForMember(x => x.Person, m => m.Ignore())
                  .ForMember(x => x.Roles, m => m.MapFrom(x =>
                  {
                      return new UserRoles
                      {
                          PersonnelManager = x.RolesPersonnelManager,
                          UserManager = x.RolesUserManager,
                          ProgramManager = x.RolesProgramManager,
                          FlightLogManager = x.RolesFlightLogManager,
                      };
                  }));
        }
    }
}
