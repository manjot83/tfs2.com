using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Site;
using NHibernate;
using NHibernate.Linq;

namespace TFS.Models.Data.Implementations
{
    public class SiteRepository : NHibernateRepository, ISiteRepository
    {
        public SiteRepository(ISession session)
            : base(session)
        {
        }

        public Page GetPage(string uri)
        {
            return Session.Linq<Page>().Where(x => x.URI.Contains(uri)).FirstOrDefault();
        }
    }
}
