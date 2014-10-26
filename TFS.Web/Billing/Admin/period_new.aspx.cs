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
    public partial class period_new : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((DropDownList)InsertBillingPeriodForm.FindControl("Month")).SelectedValue = DateTime.Now.Month.ToString();
                ((DropDownList)InsertBillingPeriodForm.FindControl("Year")).SelectedValue = DateTime.Now.Year.ToString();
            }
        }

        protected void BillingPeriod_Inserted(object sender, EventArgs e)
        {   
            Response.Redirect("default.aspx");
        }
    }
}
