using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace TFS.Models.Data
{
    public class NHibernateRepository : IRepository
    {
        public ISession Session { get; private set; }

        public NHibernateRepository(ISession session)
        {
            this.Session = session;
        }

        public TEntity Get<TEntity>(object id) where TEntity : BaseDomainObject
        {
            return Session.Get<TEntity>(id);
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : BaseDomainObject
        {
            return Session.Linq<TEntity>();
        }

        public TEntity Persist<TEntity>(TEntity entity) where TEntity : BaseDomainObject
        {
            return Session.Save<TEntity>(entity);
        }

        public object Persist(object entity)
        {
            return Session.Save(entity);
        }

        public void Delete(object entity)
        {
            Session.Delete(entity);
        }
    }
}
