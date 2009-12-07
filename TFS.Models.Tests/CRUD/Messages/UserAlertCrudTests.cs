using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Messages;
using NUnit.Framework;
using TFS.Models.Users;

namespace TFS.Models.Tests.CRUD.Messages
{
    public class UserAlertCrudTests : BaseCrudTest<UserAlert>
    {
        protected override UserAlert BuildEntity()
        {
            return new UserAlert
            {
                Title = "Annoucement 1",
                ActiveFromDate = DateTime.Today.ToUniversalTime(),
                ActiveToDate = DateTime.Today.AddDays(1).ToUniversalTime(),
                Content = "Content!",
            };
        }

        protected override void ModifyEntity(UserAlert entity)
        {
            entity.ActiveToDate = DateTime.Today.ToUniversalTime();
        }

        protected override void AssertAreEqual(UserAlert expectedEntity, UserAlert actualEntity)
        {
            Assert.AreEqual(expectedEntity, actualEntity);
        }

        protected override void AssertValidId(UserAlert entity)
        {
            Assert.IsNotNull(entity.Id);
            Assert.GreaterOrEqual(entity.Id.Value, 0);
        }
    }
}
