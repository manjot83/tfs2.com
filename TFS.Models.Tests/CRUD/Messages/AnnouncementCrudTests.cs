using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Messages;
using NUnit.Framework;
using TFS.Models.Users;

namespace TFS.Models.Tests.CRUD.Messages
{
    public class AnnouncementCrudTests : BaseCrudTest<Announcement>
    {
        protected override Announcement BuildEntity()
        {
            return new Announcement
            {
                Title = "Annoucement 1",
                ActiveFromDate = DateTime.Today.ToUniversalTime(),
                ActiveToDate = DateTime.Today.AddDays(1).ToUniversalTime(),
                Urgent = true,
                Content = "Content!",
            };
        }

        protected override void ModifyEntity(Announcement entity)
        {
            entity.Urgent = false;
            entity.ActiveToDate = DateTime.Today.ToUniversalTime();
        }

        protected override void AssertAreEqual(Announcement expectedEntity, Announcement actualEntity)
        {
            Assert.AreEqual(expectedEntity, actualEntity);
        }

        protected override void AssertValidId(Announcement entity)
        {
            Assert.IsNotNull(entity.Id);
            Assert.AreNotEqual(entity.Id.Value, Guid.Empty);
        }
    }
}
