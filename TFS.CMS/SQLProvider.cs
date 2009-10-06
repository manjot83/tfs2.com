using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace TFS.CMS
{

    public class SQLProvider
    {
        static SqlDataAdapter sql = new SqlDataAdapter();

        static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["WebsiteConnString"].ConnectionString);

        public SQLProvider()
        {

        }

        public static StaticContent getPage(String uri)
        {
            DataTable page = new DataTable();
            DataTable attributes = new DataTable();

            SqlCommand pageCommand = new SqlCommand("SELECT * FROM StaticContent WHERE uri=@uri", connection);
            SqlCommand attributeCommand = new SqlCommand("SELECT * FROM StaticContentAttributes WHERE uri=@uri", connection);

            SqlParameter param0 = new SqlParameter("@uri", SqlDbType.VarChar);
            param0.Value = uri;
            pageCommand.Parameters.Add(param0);

            SqlParameter param1 = new SqlParameter("@uri", SqlDbType.VarChar);
            param1.Value = uri;
            attributeCommand.Parameters.Add(param1);

            SqlDataAdapter pageDataAdapeter = new SqlDataAdapter(pageCommand);
            SqlDataAdapter attribDataAdapeter = new SqlDataAdapter(attributeCommand);
            pageDataAdapeter.Fill(page);
            attribDataAdapeter.Fill(attributes);

            //now we'll build the page
            StaticContent sc = new StaticContent();

            DataRow pageRow = page.Rows[0];

            //required attributes
            sc.URI = pageRow["uri"].ToString();
            sc.Title = pageRow["title"].ToString();
            sc.IsLink = (Boolean)pageRow["isLink"];
            sc.Active = (Boolean)pageRow["active"];

            //optional attributes
            foreach (DataRow row in attributes.Rows)
                sc.setAttribute(row["AttributeType"].ToString(), row["AttributeValue"].ToString());

            return sc;
        }

        public static void addAPage(String uri, String title, Boolean active, Boolean isLink, Hashtable attributes)
        {
            connection.Open();

            String position = getAllPages().Count.ToString();

            SqlCommand pageInsertCommand = new SqlCommand("INSERT INTO [StaticContent] ([uri], [title] ,[isLink] ,[active]) VALUES (@uri, @title, @isLink, @active)", connection);
            pageInsertCommand.Parameters.AddWithValue("@uri", uri);
            pageInsertCommand.Parameters.AddWithValue("@title", title);
            pageInsertCommand.Parameters.AddWithValue("@isLink", isLink);
            pageInsertCommand.Parameters.AddWithValue("@active", active);

            pageInsertCommand.ExecuteNonQuery();

            foreach (String attributeType in attributes.Keys)
            {
                String attributeValue = attributes[attributeType].ToString();
                SqlCommand attribInsertCommand = new SqlCommand("INSERT INTO [StaticContentAttributes] ([uri], [AttributeType] ,[AttributeValue]) VALUES (@uri, @AttributeType, @AttributeValue)", connection);
                attribInsertCommand.Parameters.AddWithValue("@uri", uri);
                attribInsertCommand.Parameters.AddWithValue("@AttributeType", attributeType);
                attribInsertCommand.Parameters.AddWithValue("@AttributeValue", attributeValue);
                attribInsertCommand.ExecuteNonQuery();
            }

            SqlCommand attributePositionInsertCommand = new SqlCommand("INSERT INTO [StaticContentAttributes] ([uri], [AttributeType] ,[AttributeValue]) VALUES (@uri, @AttributeType, @AttributeValue)", connection);
            attributePositionInsertCommand.Parameters.AddWithValue("@uri", uri);
            attributePositionInsertCommand.Parameters.AddWithValue("@AttributeType", "linkposition");
            attributePositionInsertCommand.Parameters.AddWithValue("@AttributeValue", position);
            attributePositionInsertCommand.ExecuteNonQuery();


            connection.Close();


            //reorder to fix position numbers;
            reorderLinkPositions();
        }

        public static ArrayList getAllPages()
        {
            DataTable allPagesTable = new DataTable();
            SqlCommand pageCommand = new SqlCommand("SELECT * FROM StaticContent", connection);
            SqlDataAdapter allPagesDataAdapter = new SqlDataAdapter(pageCommand);
            allPagesDataAdapter.Fill(allPagesTable);

            ArrayList allPages = new ArrayList();

            foreach (DataRow row in allPagesTable.Rows)
            {
                StaticContent sc = new StaticContent();
                sc.URI = row["uri"].ToString();
                sc.Title = row["title"].ToString();
                allPages.Add(sc);
            }

            return allPages;
        }

        public static void deletePage(String uri)
        {
            connection.Open();
            SqlCommand deleteCommand0 = new SqlCommand("DELETE FROM StaticContent WHERE uri=@uri", connection);
            SqlCommand deleteCommand1 = new SqlCommand("DELETE FROM StaticContentAttributes WHERE uri=@uri", connection);

            deleteCommand0.Parameters.AddWithValue("@uri", uri);
            deleteCommand1.Parameters.AddWithValue("@uri", uri);

            deleteCommand0.ExecuteNonQuery();
            deleteCommand1.ExecuteNonQuery();
            connection.Close();

            //reorder to fix position numbers;
            reorderLinkPositions();
        }

        public static void updatePage(String uri, String title, Boolean isLink, Boolean active, Hashtable attributes)
        {
            connection.Open();

            //first we'll update the SC table with the new required values from the edit page.
            SqlCommand scUpdateCommand = new SqlCommand("UPDATE StaticContent SET uri=@uri, title=@title, isLink=@isLink, active=@active WHERE uri=@id", connection);
            scUpdateCommand.Parameters.AddWithValue("@id", uri);
            scUpdateCommand.Parameters.AddWithValue("@uri", uri);
            scUpdateCommand.Parameters.AddWithValue("@title", title);
            scUpdateCommand.Parameters.AddWithValue("@isLink", isLink);
            scUpdateCommand.Parameters.AddWithValue("@active", active);
            scUpdateCommand.ExecuteNonQuery();


            //next we'll remove all attribute entries for the URI
            SqlCommand attributeRemovalCommand = new SqlCommand("DELETE FROM StaticContentAttributes WHERE uri=@uri", connection);
            attributeRemovalCommand.Parameters.AddWithValue("@uri", uri);
            attributeRemovalCommand.ExecuteNonQuery();


            //finally we'll add all the attributes back and hopefully the linkposition will remain the same
            foreach (String attributeType in attributes.Keys)
            {
                String attributeValue = attributes[attributeType].ToString();
                SqlCommand attribInsertCommand = new SqlCommand("INSERT INTO [StaticContentAttributes] ([uri], [AttributeType] ,[AttributeValue]) VALUES (@uri, @AttributeType, @AttributeValue)", connection);
                attribInsertCommand.Parameters.AddWithValue("@uri", uri);
                attribInsertCommand.Parameters.AddWithValue("@AttributeType", attributeType);
                attribInsertCommand.Parameters.AddWithValue("@AttributeValue", attributeValue);
                attribInsertCommand.ExecuteNonQuery();
            }



            connection.Close();

        }

        public static void swapLinkPosition(String uriToMove, int oldPosition, int newPosition)
        {
            DataTable allPagesTable = new DataTable();
            SqlCommand pageCommand = new SqlCommand("SELECT * FROM StaticContentAttributes WHERE AttributeType='linkposition'", connection);
            SqlDataAdapter allPagesDataAdapter = new SqlDataAdapter(pageCommand);
            allPagesDataAdapter.Fill(allPagesTable);


            foreach (DataRow row in allPagesTable.Rows)
            {
                int currentRowPosition = Int32.Parse(row["AttributeValue"].ToString());
                if (currentRowPosition == oldPosition)
                {
                    row["AttributeValue"] = newPosition;
                }
                else if (currentRowPosition == newPosition)
                {
                    row["AttributeValue"] = oldPosition;
                }
            }

            //update
            SqlCommand updateCommand = new SqlCommand("UPDATE StaticContentAttributes SET AttributeValue=@AttributeValue WHERE AttributeType=@AttributeType AND uri=@uri", connection);
            SqlParameter valueParam = new SqlParameter("@AttributeValue", SqlDbType.VarChar, 50, "AttributeValue");
            SqlParameter uriParam = new SqlParameter("@uri", SqlDbType.VarChar, 50, "uri");
            SqlParameter typeParam = new SqlParameter("@AttributeType", SqlDbType.VarChar, 50, "AttributeType");
            updateCommand.Parameters.Add(valueParam);
            updateCommand.Parameters.Add(uriParam);
            updateCommand.Parameters.Add(typeParam);

            allPagesDataAdapter.UpdateCommand = updateCommand;
            allPagesDataAdapter.Update(allPagesTable);

            //reorder to fix position numbers;
            reorderLinkPositions();
        }

        public static void reorderLinkPositions()
        {
            DataTable allPages = new DataTable();
            SqlCommand query = new SqlCommand("SELECT StaticContent.uri, StaticContentAttributes.AttributeValue AS LinkPosition FROM StaticContent INNER JOIN StaticContentAttributes ON StaticContent.uri = StaticContentAttributes.uri WHERE (StaticContentAttributes.AttributeType = 'linkposition') ORDER BY CONVERT(char, StaticContentAttributes.AttributeValue)", connection);
            SqlDataAdapter queryDataAdapter = new SqlDataAdapter(query);
            queryDataAdapter.Fill(allPages);

            int position = 0;
            foreach (DataRow row in allPages.Rows)
            {
                row["LinkPosition"] = position.ToString();
                position++;
            }

            SqlCommand updateCommand = new SqlCommand("UPDATE StaticContentAttributes SET AttributeValue=@AttributeValue WHERE AttributeType='linkposition' AND uri=@uri", connection);
            SqlParameter uriParam = new SqlParameter("@uri", SqlDbType.VarChar, 50, "uri");
            SqlParameter valueParam = new SqlParameter("@AttributeValue", SqlDbType.VarChar, 50, "LinkPosition");
            updateCommand.Parameters.Add(uriParam);
            updateCommand.Parameters.Add(valueParam);
            queryDataAdapter.UpdateCommand = updateCommand;
            queryDataAdapter.Update(allPages);
        }

        public static void setActive(String uri, Boolean active)
        {
            connection.Open();
            SqlCommand activeCommand = new SqlCommand("UPDATE StaticContent SET active=@active WHERE uri=@uri", connection);
            activeCommand.Parameters.AddWithValue("@uri", uri);
            activeCommand.Parameters.AddWithValue("@active", active);
            activeCommand.ExecuteNonQuery();
            connection.Close();
        }


    }
}