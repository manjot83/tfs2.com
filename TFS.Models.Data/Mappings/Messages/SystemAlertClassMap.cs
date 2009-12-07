using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Messages;
using FluentNHibernate.Mapping;

namespace TFS.Models.Data.Mappings.Messages
{
    public class SystemAlertClassMap : SubclassMap<SystemAlert>
    {
        public SystemAlertClassMap()
        {
            DiscriminatorValue((int)MessageType.SystemAlert);

            Map(x => x.Content)
                .Column("Content")
                .WithMaxLength()
                .Nullable(); // Must be nullable because of table-per-hierarchy
        }
    }
}
