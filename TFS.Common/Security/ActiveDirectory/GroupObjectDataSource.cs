using System;
using System.Data;
using System.Configuration;
using System.DirectoryServices;

namespace TFS.Security.ActiveDirectory
{

    public class GroupObjectDataSource
    {

        private static String FindUserDNFromSAMAccount(String sAMAccountName)
        {

            sAMAccountName = sAMAccountName.Remove(0, sAMAccountName.IndexOf("\\") + 1);

            DirectoryEntry adsiRoot = new DirectoryEntry(System.Configuration.ConfigurationManager.AppSettings["LDAPBase"]);
            String searchFilter = "(&(ObjectClass=User)(sAMAccountName=" + sAMAccountName + "))";
            String[] props = new String[] { "distinguishedName" };
            DirectorySearcher searcher = new DirectorySearcher(adsiRoot, searchFilter, props);
            SearchResult result = searcher.FindOne();
            return result.Properties["distinguishedName"][0].ToString();
             
        }

        public static String[] GetUserRoles(String username)
        {
            String userDN = FindUserDNFromSAMAccount(username);
            DataTable groupTable = GetUserGroups(userDN);
            String[] groups = new String[groupTable.Rows.Count];
            for (int i = 0; i < groups.Length; i++)
            {
                groups[i] = groupTable.Rows[i]["name"].ToString();
            }
            return groups;
        }

        public static DataTable GetUserGroups(String dnKey)
        {

            String adsiRoot = System.Configuration.ConfigurationManager.AppSettings["LDAPBase"];
            String userAdsiRoot = adsiRoot.Remove(adsiRoot.IndexOf("DC"));
            userAdsiRoot = userAdsiRoot.Insert(userAdsiRoot.Length, dnKey);

            DirectoryEntry user = new DirectoryEntry(userAdsiRoot);

            if (user == null)
                throw new Exception("Could not find Entry: " + userAdsiRoot);

            DataTable resultsTable = new DataTable();
            resultsTable.Columns.Add(new DataColumn("distinguishedName"));
            resultsTable.Columns.Add(new DataColumn("name"));

            //throw new Exception(userAdsiRoot);

            foreach (String groupDN in user.Properties["memberOf"])
            {
                String groupADSIRoot = adsiRoot.Remove(adsiRoot.IndexOf("DC"));
                groupADSIRoot = groupADSIRoot.Insert(groupADSIRoot.Length, groupDN);

                DirectoryEntry group = new DirectoryEntry(groupADSIRoot);

                DataRow newRow = resultsTable.NewRow();
                newRow["distinguishedName"] = group.Properties["distinguishedName"].Value.ToString();
                newRow["name"] = group.Properties["name"].Value.ToString();
                resultsTable.Rows.Add(newRow);

                group.Close();

            }

            resultsTable.PrimaryKey = new DataColumn[] { resultsTable.Columns["name"] };
            

            return resultsTable;


        }

        public static void AddUserToGroup(String groupDN, String userDN)
        {
            String adsiRoot = System.Configuration.ConfigurationManager.AppSettings["LDAPBase"];
            String userRoot = adsiRoot.Remove(adsiRoot.IndexOf("DC"));
            userRoot = userRoot.Insert(userRoot.Length, userDN);
            String groupRoot = adsiRoot.Remove(adsiRoot.IndexOf("DC"));
            groupRoot = groupRoot.Insert(groupRoot.Length, groupDN);

            DirectoryEntry group = new DirectoryEntry(groupRoot);
            group.Invoke("Add", new object[] { userRoot });
            group.CommitChanges();
        }

        public static void RemoveUserFromGroup(String groupDN, String userDN)
        {
            String adsiRoot = System.Configuration.ConfigurationManager.AppSettings["LDAPBase"];
            String userRoot = adsiRoot.Remove(adsiRoot.IndexOf("DC"));
            userRoot = userRoot.Insert(userRoot.Length, userDN);
            String groupRoot = adsiRoot.Remove(adsiRoot.IndexOf("DC"));
            groupRoot = groupRoot.Insert(groupRoot.Length, groupDN);

            DirectoryEntry group = new DirectoryEntry(groupRoot);
            group.Invoke("Remove", new object[] { userRoot });
            group.CommitChanges();
        }

    }

}