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

public partial class EditPost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        ((Button)this.EditPostForm.FindControl("DeleteButton")).Attributes.Add("onclick", "return confirm('Are you sure you want to delete?')");
        ((Button)this.EditPostForm.FindControl("UpdateButton")).Attributes.Add("onclick", "return confirm('Are you sure you want to update?')");
    }

    protected void Cancel(object sender, EventArgs e)
    {
        Response.Redirect(".");
    }


    protected void Item_Updated(object sender, EventArgs e)
    {
        Response.Redirect(".");
    }

    protected void Item_Updating(object sender, EventArgs e)
    {
        
    }

    protected void Item_Deleted(object sender, EventArgs e)
    {
        Response.Redirect(".");
    }
}
