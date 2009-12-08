using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Messages;
using FluentNHibernate.Mapping;

namespace TFS.Models.Data.Mappings.Messages
{
    public class AnnouncementClassMap : SubclassMap<Announcement>
    {
        public AnnouncementClassMap()
        {
            DiscriminatorValue((int)MessageType.Announcement);

            Map(x => x.Urgent)
                .Column("Urgent")
                .Nullable(); // Must be nullable because of table-per-hierarchy

            References(x => x.CreatedBy)
                .Column("Announcement_CreatedBy")
                .ForeignKey("FK_Announcement_Messages_Users")
                .Nullable(); // Must be nullable because of table-per-hierarchy
        }
    }
}
