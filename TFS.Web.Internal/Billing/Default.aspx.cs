using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class billing_default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        field_username.Value = getUsername();        
    }

    protected String getUsername()
    {
        String name = Request.Params["name"];
        if (name == null || name.Equals(""))
            name = Page.User.Identity.Name;
        //String name = Page.User.Identity.Name;
        return name.Substring(name.IndexOf('\\')+1);
    }


    protected void Start_Period(object sender, EventArgs e)
    {
        int periodaccountid = Int32.Parse(((LinkButton)sender).CommandArgument);
        String username = getUsername();
        new TFS.Intranet.Data.Billing.TimesheetController().Insert(username, periodaccountid);
        OpenTimesheets.DataBind();
        PendingTimesheets.DataBind();
        ReportableTimesheets.DataBind();
    }
}
