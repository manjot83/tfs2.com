using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Messages;
using NHibernate;
using NHibernate.Linq;

namespace TFS.Models.Data.Implementations
{
    public class MessagesRepository : BaseDataAccessObject, IMessagesRepository
    {
        public MessagesRepository(ISession session)
            : base(session)
        {
        }

        public IEnumerable<Message> GetAllActiveNonUserMessages()
        {
            return Session.Linq<Message>()
                          .Where(x => x.ActiveFromDate < DateTime.UtcNow)
                          .Where(x => x.ActiveToDate > DateTime.UtcNow)
                          .ToList()
                          .Where(x => (x.MessageType == MessageType.Announcement) || (x.MessageType == MessageType.SystemAlert))
                          .ToList();
        }

        public IEnumerable<Announcement> GetAllAnnouncements()
        {
            return Session.Linq<Announcement>().ToList();
        }

        public IEnumerable<SystemAlert> GetAllSystemAlerts()
        {
            return Session.Linq<SystemAlert>().ToList();
        }
    }
}
