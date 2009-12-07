using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Messages;
using NUnit.Framework;
using TFS.Extensions;

namespace TFS.Models.Tests.CRUD.Messages
{
    public class MessageCurdTests : BaseCrudTest<Message>
    {
        protected override Message BuildEntity()
        {
            return new Announcement
            {
                Title = "Annoucement 1",
                ActiveFromDate = DateTime.Today.ToUniversalTime(),
                ActiveToDate = DateTime.Today.AddDays(1).ToUniversalTime(),
            };
        }

        protected override void ModifyEntity(Message entity)
        {
            entity.ActiveToDate = DateTime.UtcNow.WithoutMilliseconds();
        }

        protected override void AssertAreEqual(Message expectedEntity, Message actualEntity)
        {
            Assert.AreEqual(expectedEntity, actualEntity);
        }

        protected override void AssertValidId(Message entity)
        {
            Assert.IsNotNull(entity.Id);
            Assert.GreaterOrEqual(entity.Id.Value, 0);
        }
    }
}
