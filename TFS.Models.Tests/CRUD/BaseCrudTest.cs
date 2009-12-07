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
            Session.Linq<TEntity>().Take(5).ToList();
        }

        [Test]
        public virtual void AddEntity_EntityWasAdded()
        {
            var entity = BuildEntity();

            InsertEntity(entity);
            var id = Session.GetIdentifier(entity);

            Session.Evict(entity);

            var reloadedEntity = Session.Get<TEntity>(id);

            Assert.IsNotNull(reloadedEntity);
            AssertAreEqual(entity, reloadedEntity);
            AssertValidId(reloadedEntity);
        }

        [Test]
        public virtual void UpdateEntity_EntityWasUpdated()
        {
            var entity = BuildEntity();

            InsertEntity(entity);
            var id = Session.GetIdentifier(entity);

            ModifyEntity(entity);
            UpdateEntity(entity);

            Session.Evict(entity);

            var reloadedEntity = Session.Get<TEntity>(id);

            Assert.IsNotNull(reloadedEntity);
            AssertAreEqual(entity, reloadedEntity);
        }

        [Test]
        public virtual void DeleteEntity_EntityWasDeleted()
        {
            var entity = BuildEntity();

            InsertEntity(entity);
            var id = Session.GetIdentifier(entity);

            DeleteEntity(entity);

            Assert.IsNull(Session.Get<TEntity>(id));
        }

        protected virtual void InsertEntity(TEntity entity)
        {
            Session.Save(entity);
            Session.Flush();
        }

        protected virtual void UpdateEntity(TEntity entity)
        {
            Session.Update(entity);
            Session.Flush();
        }

        protected virtual void DeleteEntity(TEntity entity)
        {
            Session.Delete(entity);
            Session.Flush();
        }

        protected abstract TEntity BuildEntity();
        protected abstract void ModifyEntity(TEntity entity);
        protected abstract void AssertAreEqual(TEntity expectedEntity, TEntity actualEntity);
        protected abstract void AssertValidId(TEntity entity);
    }

}
