using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Extensions;

namespace TFS.Models.Users
{
    public sealed class Role : BaseDomainEntity
    {
        public static Role GetRole(string role)
        {
            if (Enum.GetNames(typeof(Roles)).Any(x => x.Matches(role)))            
                return GetRole((Roles)Enum.Parse(typeof(Roles), role, true));            
            throw new ArgumentException(string.Format("Invalid role: {0}", role), "role");            
        }

        public static Role GetRole(Roles role)
        {
            return new Role(role);
        }

        private Roles type;

        private Role(Roles roleType)
        {
            type = roleType;
        }

        [DomainEquality]
        public string Name
        {
            get
            {
                switch (type)
                {
                    case Roles.UserManager:
                        return "User Manager";
                    case Roles.PersonnelManager:
                        return "Personnel Manager";
                    case Roles.ProgramManager:
                        return "Program Manager";
                    case Roles.FlightLogManager:
                        return "Flight Log Manager";
                    default:
                        return "Unknown Role";
                }
            }
        }

        public string Description
        {
            get
            {
                switch (type)
                {
                    case Roles.UserManager:
                        return "Manage users and system permissions.";
                    case Roles.PersonnelManager:
                        return "Manage personnel records and qualification records.";
                    case Roles.ProgramManager:
                        return "Manage flight programs and all associated records and information.";
                    case Roles.FlightLogManager:
                        return "Manage access to and edit flight logs.";
                    default:
                        return "Unknown Role";
                }
            }
        }

        public bool IsInRole(User user)
        {
            switch (type)
            {
                case Roles.UserManager:
                    return user.Roles.UserManager;
                case Roles.PersonnelManager:
                    return user.Roles.PersonnelManager;
                case Roles.ProgramManager:
                    return user.Roles.ProgramManager;
                case Roles.FlightLogManager:
                    return user.Roles.FlightLogManager;
                default:
                    return false;
            }
        }
    }
}
