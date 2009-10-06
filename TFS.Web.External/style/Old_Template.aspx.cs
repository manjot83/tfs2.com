using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TFS2.WebContentManager;


public partial class _Template : TFS2.WebContentManager.StandardTemplate 
{


    protected void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
        try
        {
            String path = this.Request.Path;
            String computedPath = path.Remove(0, virtualPath.Length);
            
            sc = SQLProvider.getPage(computedPath);

            //now we'll fill in the content
            PageHeader.Text = "<img src=\"style/template/"+sc.PageHeader+".jpg\" alt=\"\" />";
            this.pageTitle = sc.Title;
            ContentBanner.Text = "<img src=\"style/banners/" + sc.getAttribute(TFS2.WebContentManager.StaticContent.AttributeType.banner) + ".gif\" alt=\"Banner\" />";
            ContentBody.Text = sc.Body;
            ImageStrip.Text = GenImageStrip(sc.ImageStrip);
        }
        catch (Exception ex)
        {
            String path = this.Request.Path;
            String computedPath = path.Remove(0, virtualPath.Length);
            Response.Write("Exception Thrown: " + ex.ToString().Replace("\n", "<br>")+"<br>"+"For URI: "+computedPath);
        }
    }



}