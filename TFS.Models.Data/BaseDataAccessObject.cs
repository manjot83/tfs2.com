using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace TFS.Models.Data
{
    public abstract class BaseDataAccessObject
    {
        protected readonly ISession Session;

        public BaseDataAccessObject(ISession session)
        {
            this.Session = session;
        }
    }
}
