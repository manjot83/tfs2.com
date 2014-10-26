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
            return new UserCollection().Where(User.Columns.Username, SubSonic.Comparison.Like, "%"+Username+"%").Load();
        }

        public UserCollection FetchAll()
        {
            return new UserCollection().Load();
        }

        public User ByUsername(string username)
        {
            return SelectUser(username).FirstOrDefault();
        }

    }
}
