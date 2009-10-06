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

public partial class NewLink : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Reset();
    }

    protected void Reset()
    {
        ((TextBox)NewCatForm.FindControl("name")).Text = "";
        ((TextBox)NewCatForm.FindControl("navurl")).Text = "";
    }

    protected void Reset(object sender, EventArgs e)
    {
        Reset();
    }


    protected void Item_Inserted(object sender, EventArgs e)
    {
        Response.Redirect(".");
    }
}
