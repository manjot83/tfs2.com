using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.Models.Users
{
    public enum Roles
    {
        UserManager,
        PersonnelManager,
        ProgramManager,
        FlightLogManager,
    }

    public static class RoleNames
    {
        public const string UserManager = "UserManager";
        public const string PersonnelManager = "PersonnelManager";
        public const string ProgramManager = "ProgramManager";
        public const string FlightLogManager = "FlightLogManager";
    }

}
