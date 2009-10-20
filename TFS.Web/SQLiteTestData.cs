#if SQLITE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using NHibernate;
using TFS.Models;
using Centro.Extensions;
using TFS.Models.Programs;

namespace TFS.Web
{
    public static class SQLiteTestData
    {
        public static void Execute()
        {
            var session = ObjectFactory.GetInstance<ISession>();

            // Users
            session.Save(new User
            {
                FirstName = "Joseph",
                LastName = "Daigle",
                DisplayName = "Joseph Daigle",
                Username = "j.daigle",
                Email = "j.daigle@tfs2.com",
                Disabled = false,
                PasswordHash = "j.daigle".Hash(Crypto.HashAlgorithm.SHA1),
            });
            session.Save(new User
            {
                FirstName = "Bill",
                LastName = "Petit",
                DisplayName = "Bill Petit",
                Username = "w.petit",
                Email = "w.petit@tfs2.com",
                Disabled = false,
                PasswordHash = "w.petit".Hash(Crypto.HashAlgorithm.SHA1),
            });
            session.Save(new User
            {
                FirstName = "Mark",
                LastName = "Ott",
                DisplayName = "Mark Ott",
                Username = "m.ott",
                Email = "m.ott@tfs2.com",
                Disabled = true,
                PasswordHash = null,
            });

            // Program Data
            session.Save(new Position()
            {
                Title = "Pilot",
            });
            session.Save(new Position()
            {
                Title = "Flight Engineer",
            });
            session.Save(new Position()
            {
                Title = "Loadmaster",
            });
        }
    }
}
#endif