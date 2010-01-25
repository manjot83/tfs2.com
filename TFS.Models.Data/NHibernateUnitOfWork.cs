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
                EnsureStarted();
                return currentSession;
            }
        }

        public void Start()
        {
            if (currentSession == null || !currentSession.Transaction.IsActive)
            {
                currentSession = sessionFactory.OpenSession();
                currentSession.FlushMode = FlushMode.Commit;
                currentSession.BeginTransaction();
            }
        }

        public void Finish()
        {
            EnsureStarted();
            currentSession.Transaction.Commit();
        }

        public void Abort()
        {
            EnsureStarted();
            currentSession.Transaction.Rollback();
        }

        private void EnsureStarted()
        {
            if (currentSession == null || !currentSession.Transaction.IsActive)
                throw new InvalidOperationException("An attempt was made to access the database session outside of a transaction. Please make sure all access is made within a unit of work.");
        }
    }
}
