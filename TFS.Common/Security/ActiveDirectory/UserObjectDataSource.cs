using System;
using System.Data;
using System.Configuration;
using System.DirectoryServices;

namespace TFS.Security.ActiveDirectory
{

    public class UserObjectDataSource
    {

        
	

        public static DataTable GetLDAPResults(String query, String[] properties)
        {

            // start hack to make sure distinguished name is there
            Boolean hasDN = false;
            foreach (String property in properties) {
                if (property.Equals("distinguishedName"))
                    hasDN = true;
            }
            if (!hasDN)
            {
                String[] newProps = new String[properties.Length+1];
                properties.CopyTo(newProps, 0);
                newProps[newProps.Length-1] = "distinguishedName";
                properties = newProps;
            }


            DataTable resultsTable = new DataTable();
            foreach(String property in properties)
                resultsTable.Columns.Add(new DataColumn(property));

            String adsiRoot = System.Configuration.ConfigurationManager.AppSettings["LDAPBase"];

            DirectoryEntry baseRoot = new DirectoryEntry(adsiRoot);
            DirectorySearcher seacher = new DirectorySearcher(baseRoot, query, properties);
            SearchResultCollection results = seacher.FindAll();
            if (results.Count == 0)
                throw new Exception("Found No Records in Active Directory Matching Filter: " + query);
            foreach (SearchResult searchResult in results)
            {                
                DataRow newRow = resultsTable.NewRow();
                foreach (DataColumn col in resultsTable.Columns)
                    if (searchResult.Properties.Contains(col.ColumnName))
                        newRow[col.ColumnName] = searchResult.Properties[col.ColumnName][0].ToString();
                resultsTable.Rows.Add(newRow);
            }

            return resultsTable;
        }

        public static DataTable GetUserProperties(String distinguishedName, String[] properties)
        {
            String adsiRoot = System.Configuration.ConfigurationManager.AppSettings["LDAPBase"];
            adsiRoot = adsiRoot.Remove(adsiRoot.IndexOf("DC"));
            adsiRoot = adsiRoot.Insert(adsiRoot.Length, distinguishedName);
            
            DirectoryEntry user = new DirectoryEntry(adsiRoot);

            DataTable resultsTable = new DataTable();

            foreach (String property in properties)
                resultsTable.Columns.Add(new DataColumn(property));

            DataRow newRow = resultsTable.NewRow();

            foreach (String property in properties)
                if (user.Properties.Contains(property))
                    newRow[property] = user.Properties[property].Value.ToString();
                else
                    newRow[property] = "";

            resultsTable.Rows.Add(newRow);

            return resultsTable;

        }


        public static void UpdateUserProperties(String distinguishedName, String[] properties, String[] values)
        {
            String adsiRoot = System.Configuration.ConfigurationManager.AppSettings["LDAPBase"];
            adsiRoot = adsiRoot.Remove(adsiRoot.IndexOf("DC"));
            adsiRoot = adsiRoot.Insert(adsiRoot.Length, distinguishedName);

            DirectoryEntry user = new DirectoryEntry(adsiRoot);

            for (int i = 0; i < properties.Length; i++)
                user.Properties[properties[i]].Value = values[i];

            user.CommitChanges();

        }

        public static void UpdateUserInfo(String sn, String givenName, String title, String distinguishedName)
        {
            
            String adsiRoot = System.Configuration.ConfigurationManager.AppSettings["LDAPBase"];
            adsiRoot = adsiRoot.Remove(adsiRoot.IndexOf("DC"));
            adsiRoot = adsiRoot.Insert(adsiRoot.Length, distinguishedName);

            DirectoryEntry user = new DirectoryEntry(adsiRoot);

            if (!user.Properties.Contains("sn"))
                user.Properties["sn"].Insert(0, sn);
            else
                user.Properties["sn"].Value = sn;

            if (!user.Properties.Contains("givenName"))
                user.Properties["givenName"].Insert(0, givenName);
            else
                user.Properties["givenName"].Value = givenName;

            if (!user.Properties.Contains("title"))
                user.Properties["title"].Insert(0, title);
            else
                user.Properties["title"].Value = title;
            
            user.CommitChanges();
        }


        private static DataTable FillBlank(DataTable table, String[] cols)
        {
            for (int i = 0; i < 4; i++)
            {
                DataRow newRow = table.NewRow();
                foreach (DataColumn col in table.Columns)
                    newRow[col.ColumnName] = "blank";
                table.Rows.Add(newRow);
            }
            return table;
        }
    }

}