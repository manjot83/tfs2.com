using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Site;
using NHibernate;
using NHibernate.Linq;
using StructureMap;

namespace TFS.Models.Data.Implementations
{
    public class SiteRepository : NHibernateRepository, ISiteRepository
    {
        public SiteRepository(INHibernateUnitOfWork nhibernateUnitOfWork, IContainer container)
            : base(nhibernateUnitOfWork, container)
        {
        }

        public Page GetPage(string uri)
        {
            return Query<Page>().Where(x => x.URI.Contains(uri)).FirstOrDefault();
        }
    }
}
