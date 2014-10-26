using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TFS.OpCenter.Data;

public partial class RemoveLink : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.Params["id"], out id))
        {
            ExternallinkController externalLinkController = new ExternallinkController();
            externalLinkController.Delete(id);
        }
        Response.Redirect(".");
    }
}
