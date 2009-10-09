using System.Linq;

namespace TFS.Models
{
    public interface IRepository
    {
    }

    public interface IRepository<TEntityType> : IRepository
    {
        void Save(ref TEntityType entity);
        IQueryable<TEntityType> Linq();
    }
}
