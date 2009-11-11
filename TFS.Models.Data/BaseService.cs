using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace TFS.Models.Data
{
    public abstract class BaseService
    {
        protected readonly ISession Session;

        public BaseService(ISession session)
        {
            this.Session = session;
        }
    }
}
