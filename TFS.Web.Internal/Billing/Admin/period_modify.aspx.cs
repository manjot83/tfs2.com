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
    public partial class period_modify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateStatus.Text = "";
        }

        protected void Period_Updated(object sender, EventArgs e)
        {
            UpdateStatus.Text = "Period Info Updated";
        }



        protected void Enable_BillingAccount(object sender, EventArgs e)
        {
            int accountid = Int32.Parse(((LinkButton)sender).CommandArgument);
            int periodid = Int32.Parse(Request.Params["id"]);
            new TFS.Intranet.Data.Billing.BillingPeriodAccountController().Insert(periodid, accountid);

            DisabledAccountsRepeater.DataBind();
            AccountsBillingRatesRepeater.DataBind();
            AccountsPerDiemRepeater.DataBind();

        }



        protected void BillingRate_Command(Object Sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("SetRate", StringComparison.CurrentCultureIgnoreCase))
            {
                int id = Int32.Parse(e.CommandArgument.ToString());
                double rate = double.Parse(((TextBox)e.Item.FindControl("rate")).Text);
                new TFS.Intranet.Data.Billing.BillingRateController().Update(id, rate);
                ((Label)e.Item.FindControl("status")).Text = "Rate Set To " + rate;
            }
        }

        protected void PerDiemRate_Command(Object Sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("SetRate", StringComparison.CurrentCultureIgnoreCase))
            {
                int id = Int32.Parse(e.CommandArgument.ToString());
                double rate = double.Parse(((TextBox)e.Item.FindControl("rate")).Text);
                new TFS.Intranet.Data.Billing.BillingPeriodAccountController().UpdatePerDiemRate(id, rate);
                ((Label)e.Item.FindControl("status")).Text = "Rate Set To " + rate;
            }
        }

        protected void MileageRate_Command(Object Sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("SetRate", StringComparison.CurrentCultureIgnoreCase))
            {
                int id = Int32.Parse(e.CommandArgument.ToString());
                double rate = double.Parse(((TextBox)e.Item.FindControl("rate")).Text);
                new TFS.Intranet.Data.Billing.BillingPeriodAccountController().UpdateMileageRate(id, rate);
                ((Label)e.Item.FindControl("status")).Text = "Rate Set To " + rate;
            }
        }

        protected void Fix_BillingRates(object sender, EventArgs e)
        {
            int periodid = Int32.Parse(Request.Params["id"]);
            TFS.Intranet.Data.Billing.SPs.SpFixPeriodBillingRates(periodid).Execute();
            DisabledAccountsRepeater.DataBind();
            AccountsBillingRatesRepeater.DataBind();
            AccountsPerDiemRepeater.DataBind();
        }
    }
}
