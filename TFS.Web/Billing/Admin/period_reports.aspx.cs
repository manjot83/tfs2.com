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
using TFS.Intranet.Data.Billing;

namespace TFS.Intranet.Web.Billing.Admin
{
    public partial class period_reports : System.Web.UI.Page
    {
        protected bool IsActivePeriod;
        protected int PeriodId;

        protected void Page_Load(object sender, EventArgs e)
        {
            var periodIdStr = Request.QueryString["id"];

            if (int.TryParse(periodIdStr, out PeriodId))
            {
                var period = TFS.Intranet.Data.Billing.BillingPeriod.FetchByID(PeriodId);
                
                if (period.Openuntil.Date > DateTime.Now.Date)
                {
                    IsActivePeriod = true;
                }
            }
        }

        protected void Delete_Timesheet(object sender, EventArgs e)
        {
            Int32 timesheetID = Int32.Parse(((LinkButton)sender).CommandArgument);
            new TFS.Intranet.Data.Billing.TimesheetController().DeleteTimesheet(timesheetID);
            AllTimeSheets.DataBind();
        }

        protected void lnkBtnStartUserTimesheet_OnClick(object sender, EventArgs e)
        {
            if (PeriodId <= 0)
                return;

            var accountId = int.Parse(drpDwnAccounts.SelectedValue);

            var billingPeriodController = new TFS.Intranet.Data.Billing.BillingPeriodAccountController();

            var periodaccountid = billingPeriodController.GetIdByPeriodIdAndAccountId(PeriodId, accountId);

            var username = drpDwnActiveUsers.SelectedValue;
            var user = new UserController().ByUsername(username);
            var timesheetId = new TFS.Intranet.Data.Billing.TimesheetController().Insert(username, periodaccountid, user.Rategroup);
            var period = TFS.Intranet.Data.Billing.BillingPeriod.FetchByID(PeriodId);

            var url = "/Billing/timecard.aspx?username={0}&id={1}&month={2}&year={3}";
            url = string.Format(url, username, timesheetId, period.Month, period.Year);

            Response.Redirect(url);
        }
    }
}
