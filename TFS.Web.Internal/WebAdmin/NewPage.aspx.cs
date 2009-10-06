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
using TFS.CMS;

public partial class web_admin_newPage : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void CreateButton_Click(object sender, EventArgs e)
    {
        Hashtable attributes = new Hashtable();
        if (isLink.Checked)
            attributes.Add("linktitle", linktitle.Text);
        attributes.Add("markdown", markdown.Text);
        attributes.Add("banner", banner.Text);

        SQLProvider.addAPage("/"+uri.Text+".page", title.Text, true, isLink.Checked, attributes);

        Response.Redirect(".");
    }

    protected void ResetButton_Click(object sender, EventArgs e)
    {

    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect(".");
    }
}
