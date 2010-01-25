using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Users;
using NUnit.Framework;

namespace TFS.Models.Tests.CRUD.Users
{
    [TestFixture]
    public class UserCrudTests : BaseCrudTest<User>
    {
        protected override User BuildEntity()
        {
            return new User
            {
                FirstName = "Joseph",
                LastName = "Daigle",
                Email = "joseph@cridion.com",
                DisplayName = "Joseph Daigle",
                Username = "jdaigle",
                Disabled = false,
                Roles = new UserRoles
                {
                    FlightLogManager = true,
                    PersonnelManager = false,
                    ProgramManager = true,
                    UserManager = false,
                },
            };
        }

        protected override void ModifyEntity(User entity)
        {
            entity.Disabled = true;
            entity.Roles.FlightLogManager = false;
            entity.Roles.PersonnelManager = true;
            entity.FirstName = "Joe";
            entity.DisplayName = "Joe Daigle";
        }

        protected override void AssertAreEqual(User expectedEntity, User actualEntity)
        {
            Assert.AreEqual(expectedEntity, actualEntity);
        }

        protected override void AssertValidId(User entity)
        {
            Assert.IsNotNull(entity.Id);
            Assert.AreNotEqual(entity.Id.Value, Guid.Empty);
        }
    }
}
