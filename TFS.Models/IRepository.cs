using System.Linq;

namespace TFS.Models
{
    public interface IRepository
    {
        TEntity Get<TEntity>(object id) where TEntity : BaseDomainObject;
        IQueryable<TEntity> Query<TEntity>() where TEntity : BaseDomainObject;
        TEntity Persist<TEntity>(TEntity entity) where TEntity : BaseDomainObject;
        object Persist(object entity);
        void Delete(object entity);
    }
}
