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
        private int nestedTransactions;

        public UnitOfWork(ISession session)
        {
            this.session = session;
        }

        public void Begin()
        {
            if (!session.Transaction.IsActive)
            {
                session.FlushMode = FlushMode.Commit;
                session.Transaction.Begin();
                // Always start with 1
                nestedTransactions = 1;
            }
            else
            {
                // Increment this each call.
                nestedTransactions++;
            }
        }

        public void Finish()
        {
            // Each time Begin() is called, we need to call Finish() at least as many times. The last time it is called, the transaction will be closed.
            nestedTransactions--;
            if (nestedTransactions <= 0)
                nestedTransactions = 0;
            if (session.Transaction.IsActive && nestedTransactions == 0)
            {
                session.Transaction.Commit();
            }
        }

        public void Abort()
        {
            // Aborting will always close the transaction.
            // Nested transaction are ignored from then on.
            if (session.Transaction.IsActive)
            {
                session.Transaction.Rollback();
                nestedTransactions = 0;
            }
        }
    }
}
