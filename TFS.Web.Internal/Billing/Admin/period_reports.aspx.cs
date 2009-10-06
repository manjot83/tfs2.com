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

namespace TFS.Intranet.Web.Billing.Admin
{
    public partial class period_reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Delete_Timesheet(object sender, EventArgs e)
        {
            Int32 timesheetID = Int32.Parse(((LinkButton)sender).CommandArgument);
            new TFS.Intranet.Data.Billing.TimesheetController().DeleteTimesheet(timesheetID);
            AllTimeSheets.DataBind();
        }
    }
}
