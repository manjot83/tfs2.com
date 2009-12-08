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
        }
    }
}
