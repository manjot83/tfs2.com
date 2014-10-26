using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;

namespace TFS.OpCenter.People
{
    public class PeopleCollection : List<SyncEnabledPerson>
    {

        /// <summary>
        /// Hard coded value for the group containing all the people we are interested in
        /// </summary>
        public const string PEOPLEGROUP = "CN=allpeople,OU=Security Groups,DC=TFS2,DC=LOCAL";

        internal PeopleCollection()
        {

        }

        /// <summary>
        /// Queries ActiveDirectory for a list of "active" people and creates a collection of SyncEnabledPerson objects.
        /// </summary>
        public static PeopleCollection GetPeopleFromActiveDirectory()
        {
            PeopleCollection people = new PeopleCollection();

            /// The root path for our search
            String adsiRoot = System.Configuration.ConfigurationManager.AppSettings["LDAPBase"];
            /// The LDAP query
            String query = "(&(objectClass=user)(memberOf=" + PEOPLEGROUP + "))";
            /// Collection of properties to load
            string[] properties = new String[] { "distinguishedName", "sAMAccountName", "mail", "userPrincipalName", "sn", "givenName", "title", "department" };

            DirectoryEntry searchRoot = new DirectoryEntry(adsiRoot);
            DirectorySearcher seacher = new DirectorySearcher(searchRoot, query, properties);
            SearchResultCollection results = seacher.FindAll();
            if (results.Count == 0)
                throw new Exception("Found No Records in Active Directory Matching Filter: " + query);
            foreach (SearchResult searchResult in results)
            {
                people.Add(new SyncEnabledPerson(searchResult.GetDirectoryEntry()));
            }

            return people;
        }

        public SyncEnabledPerson this[string username]
        {
            get
            {
                if (this.Contains(username))
                    return this.Where<SyncEnabledPerson>(person => person.Username.Equals(username)).First();
                else
                    return null;
            }
        }

        public bool Contains(string username)
        {
            return this.Where<SyncEnabledPerson>(person => person.Username.Equals(username)).Count() > 0;
        }

    }
}
