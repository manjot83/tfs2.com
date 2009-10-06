using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using TFS.CMS;

namespace TFS.CMS.Web
{

    public class StandardTemplate : System.Web.UI.Page
    {

        protected String pageTitle;

        protected static String virtualPath = ConfigurationManager.AppSettings["virtualPath"];

        protected StaticContent sc;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                String path = this.Request.Path;
                String computedPath = path.Remove(0, virtualPath.Length);
                Response.Write("Exception Thrown: " + ex.ToString().Replace("\n", "<br>") + "<br>" + "For URI: " + computedPath);
            }
        }

        protected String GenImageStrip(String imageStripSource)
        {
            String rendered = "";
            String[] imageNumbers = imageStripSource.Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (String image in imageNumbers)
                rendered += "<img src=\"images/imageview.aspx?id=" + image + "&size=2\" alt=\"\" />";
            return rendered;
        }

    }
}
