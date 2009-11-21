using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using FluentNHibernate.Cfg;
using NHibernate;
using StructureMap;
using StructureMap.Attributes;
using TFS.Models.Data.Configuration;
using TFS.Web.Controllers;
using AutoMapper;
using TFS.Models.Users;
using TFS.Web.ViewModels;
using TFS.Models.PersonnelRecords;
using TFS.Web.ViewModels.PersonnelRecords;
using System;
using TFS.Models.Geography;
using TFS.Models;

namespace TFS.Web
{
    public class MvcBootstrapper
    {
        public static void SetupApplication()
        {
            RegisterRoutes(RouteTable.Routes);
            InitializeAutoMapper();
            var fluentConfiguration = InitializeNHibernate();
            InitializeStructureMap(fluentConfiguration);
#if SQLITE
            LoadTestData(fluentConfiguration);
#endif
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.IgnoreRoute("Content/{*resource}");
            routes.IgnoreRoute("Scripts/{*resource}");

            routes.MapRoute(
                string.Empty,
                "{controller}/{action}/{id}",
                new { controller = MVC.Dashboard.Name, action = MVC.Dashboard.Actions.Index, id = "" }
            );

        }

        public static void InitializeAutoMapper()
        {
            Mapper.CreateMap<User, UserViewModel>();
            Mapper.CreateMap<UserViewModel, User>()
                  .ForMember(x => x.Id, x => x.Ignore())
                  .ForMember(x => x.Email, x => x.Ignore())
                  .ForMember(x => x.Roles, x => x.Ignore())
                  .ForMember(x => x.Person, x => x.Ignore())
                  .ForMember(x => x.Roles, x => x.MapFrom(p =>
                  {
                      return new UserRoles
                      {
                          PersonnelManager = p.RolesPersonnelManager,
                          UserManager = p.RolesUserManager,
                          ProgramManager = p.RolesProgramManager,
                          FlightLogManager = p.RolesFlightLogManager,
                      };
                  }));

            Mapper.CreateMap<Person, PersonnelRecordViewModel>()
                  .ForMember(x => x.Username, x => x.MapFrom(p => p.User.Username))
                  .ForMember(x => x.PersonalInfo, x => x.MapFrom(p => p))
                  .ForMember(x => x.ContactInfo, x => x.MapFrom(p => p))
                  .ForMember(x => x.CompanyInfo, x => x.MapFrom(p => p))
                  .ForMember(x => x.EditingMyRecord, x => x.Ignore())
                  .ForMember(x => x.HirePositions, x => x.Ignore());
            Mapper.CreateMap<Person, PersonalInfo>();
            Mapper.CreateMap<Person, ContactInfo>()
                  .ForMember(x => x.AddressState, x => x.MapFrom(p => p.Address != null ? p.Address.State.Abbreviation : null));
            Mapper.CreateMap<Person, CompanyInfo>()
                  .ForMember(x => x.HirePositionId, x => x.MapFrom(p => p.HirePosition != null ? p.HirePosition.Id : null));
            Mapper.CreateMap<PersonalInfo, Person>()
                  .ForMember(x => x.Id, x => x.Ignore())
                  .ForMember(x => x.User, x => x.Ignore())
                  .ForMember(x => x.Qualifications, x => x.Ignore())
                  .ForMember(x => x.Address, x => x.Ignore())
                  .ForMember(x => x.AlternateEmail, x => x.Ignore())
                  .ForMember(x => x.AlternatePhoneNumber, x => x.Ignore())
                  .ForMember(x => x.EmergencyContactName, x => x.Ignore())
                  .ForMember(x => x.EmergencyContactPhoneNumber, x => x.Ignore())
                  .ForMember(x => x.FlightSuitSize, x => x.Ignore())
                  .ForMember(x => x.HirePosition, x => x.Ignore())
                  .ForMember(x => x.PrimaryPhoneNumber, x => x.Ignore())
                  .ForMember(x => x.ShirtSize, x => x.Ignore())
                  .ForMember(x => x.DateOfBirth, x => x.MapFrom(p => p.DateOfBirth.HasValue ? p.DateOfBirth.Value.ToUniversalTime() : (DateTime?)null));
            Mapper.CreateMap<ContactInfo, Person>()
                  .ForMember(x => x.Id, x => x.Ignore())
                  .ForMember(x => x.User, x => x.Ignore())
                  .ForMember(x => x.Qualifications, x => x.Ignore())
                  .ForMember(x => x.FlightSuitSize, x => x.Ignore())
                  .ForMember(x => x.HirePosition, x => x.Ignore())
                  .ForMember(x => x.ShirtSize, x => x.Ignore())
                  .ForMember(x => x.FirstName, x => x.Ignore())
                  .ForMember(x => x.LastName, x => x.Ignore())
                  .ForMember(x => x.MiddleInitial, x => x.Ignore())
                  .ForMember(x => x.DateOfBirth, x => x.Ignore())
                  .ForMember(x => x.Gender, x => x.Ignore())
                  .ForMember(x => x.SocialSecurityLastFour, x => x.Ignore())
                  .ForMember(x => x.Address, x => x.MapFrom(p =>
                  {
                      return new USAddress
                      {
                          StreetAddress = p.AddressStreetAddress,
                          City = p.AddressCity,
                          State = USState.FromAbbreviation(p.AddressState.ToUpper()),
                          ZipCode = p.AddressZipCode,
                      };
                  }))
                  .ForMember(x => x.PrimaryPhoneNumber, x => x.MapFrom(p => RegExLib.ParseRegEx(p.PrimaryPhoneNumber, RegExLib.USPhoneNumber)))
                  .ForMember(x => x.AlternatePhoneNumber, x => x.MapFrom(p => RegExLib.ParseRegEx(p.AlternatePhoneNumber, RegExLib.USPhoneNumber)))
                  .ForMember(x => x.EmergencyContactPhoneNumber, x => x.MapFrom(p => RegExLib.ParseRegEx(p.EmergencyContactPhoneNumber, RegExLib.USPhoneNumber)));
            Mapper.CreateMap<CompanyInfo, Person>()
                  .ForMember(x => x.Id, x => x.Ignore())
                  .ForMember(x => x.User, x => x.Ignore())
                  .ForMember(x => x.Qualifications, x => x.Ignore())
                  .ForMember(x => x.Address, x => x.Ignore())
                  .ForMember(x => x.AlternateEmail, x => x.Ignore())
                  .ForMember(x => x.AlternatePhoneNumber, x => x.Ignore())
                  .ForMember(x => x.EmergencyContactName, x => x.Ignore())
                  .ForMember(x => x.EmergencyContactPhoneNumber, x => x.Ignore())
                  .ForMember(x => x.HirePosition, x => x.Ignore())
                  .ForMember(x => x.PrimaryPhoneNumber, x => x.Ignore())
                  .ForMember(x => x.FirstName, x => x.Ignore())
                  .ForMember(x => x.LastName, x => x.Ignore())
                  .ForMember(x => x.MiddleInitial, x => x.Ignore())
                  .ForMember(x => x.DateOfBirth, x => x.Ignore())
                  .ForMember(x => x.Gender, x => x.Ignore())
                  .ForMember(x => x.SocialSecurityLastFour, x => x.Ignore());

#if DEBUG
            Mapper.AssertConfigurationIsValid();
#endif
        }

        public static FluentConfiguration InitializeNHibernate()
        {
#if DEBUG
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
#endif
            var mappingAssemblies = new List<Assembly> { typeof(TFS.Models.Data.Mappings.Users.UserMapping).Assembly };
#if SQLITE
            return SQLiteBuilder.CreateConfiguration("TFS_Web", mappingAssemblies);
#else
            return MSSqlBuilder.CreateConfiguration("TFS_Web", mappingAssemblies);
#endif
        }

        public static void InitializeStructureMap(FluentConfiguration fluentConfiguration)
        {
            ObjectFactory.Initialize(i =>
            {
                i.AddRegistry(new DomainModelRegistry(fluentConfiguration));

                i.Scan(s =>
                {
                    s.IncludeNamespaceContainingType<DashboardController>();
                    s.AddAllTypesOf<IController>();
                });

                i.ForRequestedType<IAuthenticationService>()
                    .CacheBy(InstanceScope.Hybrid)
                    .TheDefaultIsConcreteType<FormsAuthenticationService>();
            });
#if DEBUG
            ObjectFactory.AssertConfigurationIsValid();
#endif
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }

#if SQLITE
        public static void LoadTestData(FluentConfiguration fluentConfiguration)
        {
            var session = ObjectFactory.GetInstance<ISession>();
            SqlSchemaUtil.GenerateSchema(fluentConfiguration.BuildConfiguration(), session);
            TestData.Execute(session);
            session.Clear();
        }
#endif
    }
}
