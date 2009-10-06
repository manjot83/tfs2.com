using System;
using System.Collections.Generic;
using System.Text;

namespace TFS.Intranet.Data.Billing
{
    public partial class UserController
    {

        public UserCollection SelectUser(String Username)
        {
            return new UserCollection().Where(User.Columns.Username, Username).Load();
        }

        public UserCollection FetchAll()
        {
            return new UserCollection().Load();
        }

    }
}
