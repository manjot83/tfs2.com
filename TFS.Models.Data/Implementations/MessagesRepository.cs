using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Messages;
using NHibernate;
using NHibernate.Linq;
using StructureMap;

namespace TFS.Models.Data.Implementations
{
    public class MessagesRepository : NHibernateRepository, IMessagesRepository
    {
        public MessagesRepository(INHibernateUnitOfWork nhibernateUnitOfWork, IContainer container)
            : base(nhibernateUnitOfWork, container)
        {
        }

        public IEnumerable<Message> GetAllActiveNonUserMessages()
        {
            return Query<Message>()
                          .Where(x => x.ActiveFromDate < DateTime.UtcNow)
                          .Where(x => x.ActiveToDate > DateTime.UtcNow)
                          .ToList()
                          .Where(x => (x.MessageType == MessageType.Announcement) || (x.MessageType == MessageType.SystemAlert))
                          .ToList();
        }

        public IEnumerable<Announcement> GetAllAnnouncements()
        {
            return Query<Announcement>().ToList();
        }

        public IEnumerable<SystemAlert> GetAllSystemAlerts()
        {
            return Query<SystemAlert>().ToList();
        }
    }
}
