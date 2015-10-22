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

namespace TFS.Intranet.Web.Billing.Reports
{
    public partial class timecardreport : System.Web.UI.Page
    {
        protected int TimesheetId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            TimesheetId = Int32.Parse(Request.Params["id"]);

            var controller = new TimesheetController();
            month.Value = Request.Params["month"];
            year.Value = Request.Params["year"];

            if (!IsPostBack)
            {
                TFS.Intranet.Data.Billing.Timesheet timesheet = new TFS.Intranet.Data.Billing.TimesheetController().FetchByID(TimesheetId)[0];

                //check and see if there are any BillingCityRates for this account
                //var billingCityRateController = new BillingDefaultCityRateController();
                //var billingCityRateCol = billingCityRateController.FetchAllActiveByAccountId(timesheet.BillingPeriodAccount.Accountid);

                //if (billingCityRateCol.Count > 0)
                //{

                   

                 
                //}

                var timeBillingCityRateJoinController = new TimesheetBillingCityRateJoinController();
                var cityCountPerDiem = timeBillingCityRateJoinController.CityPerDiemCountGrandTotalByTimesheetId(TimesheetId);

                if (cityCountPerDiem > 0)
                {
                    //hide default per diem count UI element
                    pnlDefaultPerdiemCount.Visible = false;
                    //show city per diem UI elements
                    pnlTimesheetBillingCityRates.Visible = true;
                    DaysPerDiem.Text = cityCountPerDiem.ToString();
                }
                else
                {
                    DaysPerDiem.Text = timesheet.Perdiemcount.ToString();
                }
               
                Mileage.Text = timesheet.Mileageclaimed.ToString();
                PayRateGroup.Text = timesheet.RateGroup.Name;
            }
        }

        protected void TimesheetCityRateDataSource_Selecting(object sender, System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs e)
        {
            if (TimesheetId <= 0) return;

            if (e.InputParameters["TimesheetId"] == null)
            {
                e.InputParameters["TimesheetId"] = TimesheetId;
            }
        }

        protected String getTimeDifference(String time1, String time2)
        {
            TimeSpan timespan1 = TimeSpan.Parse(time1);
            TimeSpan timespan2 = TimeSpan.Parse(time2);
            TimeSpan timespan3 = timespan2.Subtract(timespan1);
            return timespan3.ToString();
        }

        protected String getTotalTime()
        {
            TimeSpan totalTime = new TimeSpan(0);
            foreach (GridViewRow row in TimeEntryGridView.Rows)
            {
                TimeSpan span = TimeSpan.Parse(((ITextControl)row.FindControl("TotalTimeLabel")).Text);
                totalTime = totalTime.Add(span);
            }
            return (totalTime.Days * 24 + totalTime.Hours) + " hours " + totalTime.Minutes + " minutes " + totalTime.Seconds + " seconds";
        }


        protected String getTotalCost()
        {
            double totalCost = 0;
            foreach (GridViewRow row in ExpenseGridView.Rows)
            {
                totalCost += Double.Parse(((ITextControl)row.FindControl("Cost")).Text);
            }
            return totalCost.ToString();
        }
    }
}
