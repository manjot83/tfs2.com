using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;

namespace TFS.Security
{
    public class GroupAccount : ObjectAccount
    {
        
        public GroupAccount(DirectoryEntry directoryEntry) 
            : base(directoryEntry)
        {
            
        }

        public GroupAccount(String distinguishedName)
            : base(distinguishedName)
        {

        }


        public UserAccount[] GetMembers()
        {
            String query = "(&(objectClass=user)(memberOf=" + this.DistinguishedName + "))";
            DirectoryEntry ADRoot = new DirectoryEntry(TFS.Properties.Settings.Default.ActiveDirectoryConnString);
            DirectorySearcher seacher = new DirectorySearcher(ADRoot, query, new String[] { "distinguishedName" });
            SearchResultCollection results = seacher.FindAll();
            if (results.Count == 0)
                throw new Exception("Found No Records in Active Directory Matching Filter: " + query);
            UserAccount[] userAccounts = new UserAccount[results.Count];
            for (int i = 0; i < userAccounts.Length; i++)
            {
                userAccounts[i] = new UserAccount(results[i].GetDirectoryEntry());
            }
            return userAccounts;
        }

        public void AddUser(UserAccount userAccount)
        {
            this.DirectoryEntry.Invoke("Add", new object[] { userAccount.DirectoryEntry.Path });
            this.DirectoryEntry.CommitChanges();
        }

        public void RemoveUser(UserAccount userAccount)
        {
            this.DirectoryEntry.Invoke("Remove", new object[] { userAccount.DirectoryEntry.Path });
            this.DirectoryEntry.CommitChanges();
        }

    }
}
