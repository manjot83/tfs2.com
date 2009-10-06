using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;

namespace TFS.Security
{
    public class UserAccount : ObjectAccount
    {

        public UserAccount(DirectoryEntry DirectoryEntry) 
            : base(DirectoryEntry)
        {
            
        }

        public UserAccount(String DistinguishedName)
            : base(DistinguishedName)
        {

        }

        public GroupAccount[] GetRoles()
        {
            GroupAccount[] groups = new GroupAccount[this.DirectoryEntry.Properties["memberOf"].Count];
            for (int i = 0; i < groups.Length; i++)
            {
                groups[i] = new GroupAccount(this.DirectoryEntry.Properties["memberOf"][i].ToString());
            }
            return groups;
        }
      
    }
}
