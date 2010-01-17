using NHibernate;

namespace TFS.Models.Data
{
    public interface INHibernateUnitOfWork : IUnitOfWork
    {
        ISession Session { get; }
    }
}
