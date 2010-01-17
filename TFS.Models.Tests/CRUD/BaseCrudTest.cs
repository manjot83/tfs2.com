using System.Linq;
using NHibernate.Linq;
using NUnit.Framework;

namespace TFS.Models.Tests.CRUD
{
    public abstract class BaseCrudTest<TEntity> : BaseNHibernateTest
       where TEntity : BaseDomainObject
    {
        [Test]
        public virtual void SelectQueryWorks()
        {
            Repository.Query<TEntity>().Take(5).ToList();
        }

        [Test]
        public virtual void AddEntity_EntityWasAdded()
        {
            var entity = BuildEntity();

            InsertEntity(entity);
            var id = Repository.Session.GetIdentifier(entity);

            Repository.Session.Evict(entity);

            var reloadedEntity = Repository.Session.Get<TEntity>(id);

            Assert.IsNotNull(reloadedEntity);
            AssertAreEqual(entity, reloadedEntity);
            AssertValidId(reloadedEntity);
        }

        [Test]
        public virtual void UpdateEntity_EntityWasUpdated()
        {
            var entity = BuildEntity();

            InsertEntity(entity);
            var id = Repository.Session.GetIdentifier(entity);

            ModifyEntity(entity);
            UpdateEntity(entity);

            Repository.Session.Evict(entity);

            var reloadedEntity = Repository.Get<TEntity>(id);

            Assert.IsNotNull(reloadedEntity);
            AssertAreEqual(entity, reloadedEntity);
        }

        [Test]
        public virtual void DeleteEntity_EntityWasDeleted()
        {
            var entity = BuildEntity();

            InsertEntity(entity);
            var id = Repository.Session.GetIdentifier(entity);

            DeleteEntity(entity);

            Assert.IsNull(Repository.Get<TEntity>(id));
        }

        protected virtual void InsertEntity(TEntity entity)
        {
            Repository.Persist(entity);
            Repository.Session.Flush();
        }

        protected virtual void UpdateEntity(TEntity entity)
        {
            Repository.Persist(entity);
            Repository.Session.Flush();
        }

        protected virtual void DeleteEntity(TEntity entity)
        {
            Repository.Delete(entity);
            Repository.Session.Flush();
        }

        protected abstract TEntity BuildEntity();
        protected abstract void ModifyEntity(TEntity entity);
        protected abstract void AssertAreEqual(TEntity expectedEntity, TEntity actualEntity);
        protected abstract void AssertValidId(TEntity entity);
    }

}
