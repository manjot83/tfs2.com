using System.Collections.Generic;
using System.Linq;
using TFS.Models.PersonnelRecords;
using TFS.Models.Users;

namespace TFS.Models
{
    public interface IRepository
    {
        TEntity Create<TEntity>() where TEntity : BaseDomainObject;
        TEntity Get<TEntity>(object id) where TEntity : BaseDomainObject;
        IQueryable<TEntity> Query<TEntity>() where TEntity : BaseDomainObject;
        TEntity Persist<TEntity>(TEntity entity) where TEntity : BaseDomainObject;
        object Persist(object entity);
        void Delete(object entity);

        User GetUserByUsername(string username);
        IList<Person> GetAllActivePersons();
        IEnumerable<User> GetAllActiveUsers();
    }
}
