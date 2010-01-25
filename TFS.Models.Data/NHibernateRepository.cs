using System.Linq;
using NHibernate;
using NHibernate.Linq;
using StructureMap;
using TFS.Models.Users;
using System.Collections.Generic;
using TFS.Models.PersonnelRecords;

namespace TFS.Models.Data
{
    public class NHibernateRepository : IRepository {
        private readonly IContainer container;

        public NHibernateRepository(INHibernateUnitOfWork nhibernateUnitOfWork, IContainer container) {
            UnitOfWork = nhibernateUnitOfWork;
            this.container = container;
        }

        public INHibernateUnitOfWork UnitOfWork { get; private set; }

        public TEntity Create<TEntity>() where TEntity : BaseDomainObject {
            return container.GetInstance<TEntity>();
        }

        public TEntity Get<TEntity>(object id) where TEntity : BaseDomainObject {
            return UnitOfWork.Session.Get<TEntity>(id);
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : BaseDomainObject {
            return UnitOfWork.Session.Linq<TEntity>();
        }

        public TEntity Persist<TEntity>(TEntity entity) where TEntity : BaseDomainObject {
            return UnitOfWork.Session.SaveOrUpdateCopy<TEntity>(entity);
        }

        public object Persist(object entity) {
            return UnitOfWork.Session.SaveOrUpdateCopy(entity);
        }

        public void Delete(object entity) {
            UnitOfWork.Session.Delete(entity);
        }


        public User GetUserByUsername(string username) {
            return Query<User>().Where(x => x.Username == username).FirstOrDefault();
        }

        public IEnumerable<User> GetAllActiveUsers() {
            return Query<User>().Where(x => !x.Disabled);
        }

        public IList<Person> GetAllActivePersons() {
            return GetAllActiveUsers()
                .ToList()
                .Where(x => x.Person != null)
                .Select(x => x.Person).ToList();
        }
    }
}
