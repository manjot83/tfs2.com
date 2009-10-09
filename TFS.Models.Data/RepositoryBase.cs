using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Linq;

namespace TFS.Models
{
    public abstract class RepositoryBase
    {
        protected readonly ISession Session;

        protected RepositoryBase(ISession session)
        {
            Session = session;
        }
    }

    public abstract class RepositoryBase<TEntityType> : RepositoryBase, IRepository<TEntityType>
    {
        public RepositoryBase(ISession session)
            :base(session)
        {
        }

        public void Save(ref TEntityType entity)
        {
            entity = (TEntityType)Session.SaveOrUpdateCopy(entity);
        }

        public IQueryable<TEntityType> Linq()
        {
            return Session.Linq<TEntityType>();
        }
    }
}
