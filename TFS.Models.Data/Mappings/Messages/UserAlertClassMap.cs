using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Messages;
using FluentNHibernate.Mapping;

namespace TFS.Models.Data.Mappings.Messages
{
    public class UserAlertClassMap : SubclassMap<UserAlert>
    {
        public UserAlertClassMap()
        {
            DiscriminatorValue((int)MessageType.UserAlert);

            References(x => x.User)
                .Column("UserAlert_UserId")
                .ForeignKey("FK_UserAlert_Messages_Users")
                .Nullable(); // Must be nullable because of table-per-hierarchy
        }
    }
}
