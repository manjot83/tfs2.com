using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;

namespace TFS.Security
{
    public class ObjectAccount
    {
        
        public String DistinguishedName
        {
            get;
            private set;
        }


        public DirectoryEntry DirectoryEntry
        {
            get;
            private set;
        }

        public String Name
        {
            get { return this.DirectoryEntry.Name; }
        }

        public ObjectAccount(String distinguishedName)
        {
            this.DistinguishedName = distinguishedName;
            String ldapConn = TFS.Security.Properties.Settings.Default.ActiveDirectoryConnString;
            ldapConn = ldapConn.Remove(ldapConn.IndexOf("DC"));
            ldapConn = ldapConn.Insert(ldapConn.Length, this.DistinguishedName);

            this.DirectoryEntry = new DirectoryEntry(ldapConn);
        }

        public ObjectAccount(DirectoryEntry directoryEntry)
        {
            this.DirectoryEntry = directoryEntry;
            this.DistinguishedName = directoryEntry.Properties["distinguishedName"][0].ToString();
        }

        public String GetProperty(String property)
        {
            if (this.DirectoryEntry.Properties.Contains(property))
                return this.DirectoryEntry.Properties[property][0].ToString();
            else
                throw new Exception("Property Does Not Exist");
        }

        public void SetProperty(String Property, String Value)
        {
            this.DirectoryEntry.Properties[Property].Value = Value;
        }
    }
}
