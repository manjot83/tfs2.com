﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.Models.Messages
{
    public interface IMessagesRepository : IRepository
    {
        IEnumerable<Message> GetAllActiveNonUserMessages();

        IEnumerable<Announcement> GetAllAnnouncements();
        IEnumerable<SystemAlert> GetAllSystemAlerts();
    }
}
