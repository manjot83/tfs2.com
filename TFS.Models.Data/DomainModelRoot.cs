using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace TFS.Models.Data
{
    public class DomainModelRoot : BaseDataAccessObject, IDomainModelRoot
    {
        public DomainModelRoot(ISession session)
            : base(session)
        {
        }

        public TModel GetDomainObject<TModel>(object id) where TModel : BaseDomainObject
        {
            return Session.Get<TModel>(id);
        }
    }
}
