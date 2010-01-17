using System;
using NHibernate;

namespace TFS.Models.Data
{
    public class NHibernateUnitOfWork : INHibernateUnitOfWork
    {
        private readonly ISessionFactory sessionFactory;
        private ISession currentSession;

        public NHibernateUnitOfWork(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        public ISession Session
        {
            get
            {
                if (currentSession == null)
                    currentSession = sessionFactory.OpenSession();
                return currentSession;
            }
        }

        public void Start()
        {
            if (!Session.Transaction.IsActive)
            {
                Session.FlushMode = FlushMode.Commit;
                Session.BeginTransaction();
            }
        }

        public void Finish()
        {
            EnsureStarted();
            Session.Transaction.Commit();
        }

        public void Abort()
        {
            EnsureStarted();
            Session.Transaction.Rollback();
        }

        private void EnsureStarted()
        {
            if (!Session.Transaction.IsActive)
                throw new InvalidOperationException("An attempt was made to access the database session outside of a transaction. Please make sure all data access is made within a unit of work.");
        }
    }
}
