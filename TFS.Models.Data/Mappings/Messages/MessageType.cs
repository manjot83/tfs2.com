using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.Models.Data.Mappings.Messages
{
    public enum MessageType : int
    {
        Unknown = 0,
        Announcement = 1,
        SystemAlert = 2,
        UserAlert = 3,
    }
}
