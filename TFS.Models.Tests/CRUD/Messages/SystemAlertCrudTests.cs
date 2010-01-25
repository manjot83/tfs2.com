using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Messages;
using NUnit.Framework;
using TFS.Models.Users;

namespace TFS.Models.Tests.CRUD.Messages
{
    public class SystemAlertCrudTests : BaseCrudTest<SystemAlert>
    {
        protected override SystemAlert BuildEntity()
        {
            return new SystemAlert
            {
                Title = "Annoucement 1",
                ActiveFromDate = DateTime.Today.ToUniversalTime(),
                ActiveToDate = DateTime.Today.AddDays(1).ToUniversalTime(),
                Content = "Content!",
            };
        }

        protected override void ModifyEntity(SystemAlert entity)
        {
            entity.ActiveToDate = DateTime.Today.ToUniversalTime();
        }

        protected override void AssertAreEqual(SystemAlert expectedEntity, SystemAlert actualEntity)
        {
            Assert.AreEqual(expectedEntity, actualEntity);
        }

        protected override void AssertValidId(SystemAlert entity)
        {
            Assert.IsNotNull(entity.Id);
            Assert.AreNotEqual(entity.Id.Value, Guid.Empty);
        }
    }
}
