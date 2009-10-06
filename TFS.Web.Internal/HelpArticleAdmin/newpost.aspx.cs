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

public partial class help_admin_newpost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Reset();
    }

    protected void Reset()
    {
        TextBox date = (TextBox)NewPostForm.FindControl("postdate");
        date.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();

        ((TextBox)NewPostForm.FindControl("subject")).Text = "";
        ((TextBox)NewPostForm.FindControl("content")).Text = "";
    }

    protected void Reset(object sender, EventArgs e)
    {
        Reset();
    }


    protected void Item_Inserted(object sender, EventArgs e)
    {
        Response.Redirect("~");
    }

    protected void Item_Inserting(object sender, EventArgs e)
    {    
    }
}
