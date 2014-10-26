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

namespace TFS.Intranet.Web.Billing.Reports
{
    public partial class timecardreport_print : System.Web.UI.Page
    {
        protected override void OnPreLoad(EventArgs e)
        {
            TimeSheet.TimesheetID = Int32.Parse(Request.Params["id"]);
            TimeSheet.Username = Request.Params["username"];
            base.OnPreLoad(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}
