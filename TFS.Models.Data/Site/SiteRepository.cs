using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Site;
using Centro.Data.DomainModel;
using NHibernate;
using NHibernate.Linq;

namespace TFS.Models.Data.Site
{
    public class SiteRepository : RepositoryBase<Page>, ISiteRepository
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
