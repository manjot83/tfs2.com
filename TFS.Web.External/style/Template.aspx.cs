using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Template : System.Web.UI.Page 
{
    protected String pageTitle;

    private static String virtualPath = ConfigurationManager.AppSettings["virtualPath"];

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Response.Write(this.Request.RawUrl);
            //first, we'll grab the page we want out of the database

            String path = this.Request.Path;
            String computedPath = path.Remove(0, virtualPath.Length);

            TFS2.WebContentManager.StaticContent sc = SQLProvider.getPage(computedPath);

            //now we'll fill in the content
            this.pageTitle = sc.Title;
            ContentBanner.Text = sc.getAttribute(TFS2.WebContentManager.StaticContent.AttributeType.banner);
            ContentBody.Text = sc.Body;
            ImageStrip.Text = sc.ImageStrip;

            //next we need to generate the navmenu
            foreach (NavLink navLink in SQLProvider.getNavLinks())
                NavigationMenu.Text += genLink(navLink.URL, navLink.Name, navLink.CssClass);
        }
        catch (Exception ex)
        {
            String path = this.Request.Path;
            String computedPath = path.Remove(0, virtualPath.Length);
            Response.Write("Exception Thrown: " + ex.ToString().Replace("\n", "<br>")+"<br>"+"For URI: "+computedPath);
        }
    }

    protected String genLink(String url, String name, String cssclass)
    {
          //<a href="index.html" class="rollover_1"></a>
        return "<a href=\"" + virtualPath + url + "\" class=\"" + cssclass + "\">" + name + "</a>";
    }



}