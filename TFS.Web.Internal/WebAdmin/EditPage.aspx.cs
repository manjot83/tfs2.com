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

public partial class admin_EditStaticContent : System.Web.UI.Page
{
    
    protected StaticContent sc;

    protected void Page_Load(object sender, EventArgs e)
    {
        String uri = Request.Params["id"];
        this.uri.Text = uri;
        sc = SQLProvider.getPage(uri);
        if (!IsPostBack)
            updateControls();
    }

    private void updateControls()
    {
        active.Checked = sc.Active;
        isLink.Checked = sc.IsLink;
        linktitle.Text = sc.LinkTitle;
        title.Text = sc.Title;
        banner.Text = sc.Banner;
        markdown.Text = sc.Markdown;
        imagestrip.Text = sc.ImageStrip;
        pageHeader.Text = sc.PageHeader;
    }



    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        Hashtable attributes = new Hashtable();
        if (isLink.Checked)
            attributes.Add("linktitle", linktitle.Text);
        attributes.Add("markdown", markdown.Text);
        attributes.Add("banner", banner.Text);
        attributes.Add("linkposition", sc.Position.ToString());
        attributes.Add("imagestrip", imagestrip.Text);
        attributes.Add("pageheader", pageHeader.Text);

        SQLProvider.updatePage(sc.URI, title.Text, isLink.Checked, active.Checked, attributes);

        Response.Redirect(".");
    }

    protected void ResetButton_Click(object sender, EventArgs e)
    {
        updateControls();
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect(".");
    }
}
