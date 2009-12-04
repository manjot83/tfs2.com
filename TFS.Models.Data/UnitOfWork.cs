using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace TFS.Models.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISession session;
        public UnitOfWork(ISession session)
        {
            this.session = session;
        }

        public void Begin()
        {
            if (!session.Transaction.IsActive)
                session.Transaction.Begin();
        }

        public void Finish()
        {
            if (session.Transaction.IsActive)
                session.Transaction.Commit();
        }

        public void Abort()
        {
            if (session.Transaction.IsActive)
                session.Transaction.Rollback();
        }
    }
}
