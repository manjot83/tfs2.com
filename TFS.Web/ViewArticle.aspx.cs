using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using anrControls;

public partial class view_article : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        postnumber.Value = Request.Params["post"];
    }

    protected String Process_Markdown(String markdown)
    {
        anrControls.Markdown markdownProcess = new anrControls.Markdown();
        return markdownProcess.Transform(markdown);
    }
}
