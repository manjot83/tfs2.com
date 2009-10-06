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
using System.Data;
using System.Data.SqlClient;

public class SQLProvider
{
    static SqlDataAdapter sql = new SqlDataAdapter();

    static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["WebsiteConnString"].ConnectionString);

    public SQLProvider()
	{

		
	}

    public static TFS2.WebContentManager.StaticContent getPage(String uri)
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
        TFS2.WebContentManager.StaticContent sc = new TFS2.WebContentManager.StaticContent();

        DataRow pageRow = page.Rows[0];

        //required attributes
        sc.URI = pageRow["uri"].ToString();
        sc.Title = pageRow["title"].ToString();

        //optional attributes
        foreach (DataRow row in attributes.Rows)
            sc.setAttribute(row["AttributeType"].ToString(), row["AttributeValue"].ToString());

        return sc;
    }


    public static ArrayList getNavLinks()
    {

        DataTable pages = new DataTable();
        SqlCommand pageCommand = new SqlCommand("SELECT pages.uri, pages.title, pages.isLink, pages.active, pages.LinkPosition, StaticContentAttributes_1.AttributeValue AS LinkTitle FROM (SELECT TOP (100) PERCENT StaticContent.uri, StaticContent.title, StaticContent.isLink, StaticContent.active, StaticContentAttributes.AttributeValue AS LinkPosition FROM StaticContent INNER JOIN StaticContentAttributes ON StaticContent.uri = StaticContentAttributes.uri WHERE (StaticContent.isLink = 1) AND (StaticContent.active = 1) AND (StaticContentAttributes.AttributeType = 'linkposition')) AS pages INNER JOIN StaticContentAttributes AS StaticContentAttributes_1 ON pages.uri = StaticContentAttributes_1.uri WHERE (StaticContentAttributes_1.AttributeType = 'linktitle') ORDER BY CONVERT(char, LinkPosition)", connection);

        SqlDataAdapter pageDataAdapeter = new SqlDataAdapter(pageCommand);
        pageDataAdapeter.Fill(pages);
        
        ArrayList navLinks = new ArrayList();

        foreach (DataRow row in pages.Rows)
        {
            navLinks.Add(new NavLink(row["uri"].ToString(), row["LinkTitle"].ToString(), Int32.Parse(row["LinkPosition"].ToString())));
        }

        return navLinks;
    }
}
