using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TFS.Intranet.Data.Billing
{
    public partial class UserController
    {

        public UserCollection SelectUser(String Username)
        {
            return new UserCollection().Where(User.Columns.Username, SubSonic.Comparison.Like, "%" + Username + "%").Load();
        }

        public UserCollection FetchAll()
        {
            return new UserCollection().Load();
        }

        public UserCollection FetchAllActive()
        {
            return new UserCollection()
            .Where(User.Columns.Disabled, false)
            .Load();
        }

        public UserCollection FetchAllActiveOrderedByLastName()
        {
            return new UserCollection()
           .Where(User.Columns.Disabled, false)
           .OrderByAsc(User.Columns.Lastname)
           .Load();

        }

        public User ByUsername(string username)
        {
            return SelectUser(username).FirstOrDefault();
        }

    }
}
