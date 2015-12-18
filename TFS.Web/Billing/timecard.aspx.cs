using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TFS.Intranet.Data.Billing;

namespace TFS.Intranet.Web.Billing
{
    public partial class timecard : System.Web.UI.Page
    {
        protected int PeriodAccountId = 0;
        protected int AccountId = 0;
        protected int TimesheetId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            TimesheetId = Int32.Parse(Request.Params["id"]);

            var timesheet = TFS.Intranet.Data.Billing.Timesheet.FetchByID(TimesheetId);

            PeriodAccountId = timesheet.Periodaccountid;
            var billingPeriodAccount = TFS.Intranet.Data.Billing.BillingPeriodAccount.FetchByID(PeriodAccountId);
            AccountId = billingPeriodAccount.Accountid;

            if (!IsPostBack)
            {
                var period = TFS.Intranet.Data.Billing.BillingPeriod.FetchByID(billingPeriodAccount.Periodid);
                var periodStart = new DateTime(period.Year, period.Month, 1);

                timeEntryDayCalendar.StartDate = periodStart;
                timeEntryDayCalendar.EndDate = period.Openuntil;

                PerDiemCountDropDown.SelectedValue = timesheet.Perdiemcount.ToString();
                Mileage_Textbox.Text = timesheet.Mileageclaimed.ToString();
                RateGroupDropDown.SelectedValue = timesheet.Rategroupid.ToString();

                //check and see if there are any BillingCityRates for this account
                var billingCityRateController = new BillingDefaultCityRateController();
                var billingCityRateCol = billingCityRateController.FetchAllActiveByAccountId(AccountId);

                if (billingCityRateCol.Count > 0)
                {
                    
                    //hide default per diem count UI element
                    pnlDefaultPerdiemCount.Visible = false;

                    //show city per diem UI elements
                    pnlTimesheetBillingCityRates.Visible = true;
                }
            }
        }

        protected void inserting_TimesheetBillingCityRate(object sender, EventArgs e)
        {
            var city = Convert.ToInt32(drpDwnInsertPerDiemCity.SelectedValue);
            var count = Convert.ToInt32(drpDwnInsertPerDiemCount.SelectedValue);

            var billingCityRateControl = new TFS.Intranet.Data.Billing.TimesheetBillingCityRateController();

            billingCityRateControl.Insert(TimesheetId, city, count);

            TimesheetCityRateGridView.DataBind();
        }

        protected void TimesheetCityRateDataSource_Selecting(object sender, System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs e)
        {
            if (TimesheetId <= 0) return;

            if (e.InputParameters["TimesheetId"] == null)
            {
                e.InputParameters["TimesheetId"] = TimesheetId;
            }
        }

        protected void BillingCityRateDataSource_Selecting(object sender, System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs e)
        {
            if (PeriodAccountId <= 0) return;

            if (e.InputParameters["PeriodAccountId"] == null)
            {
                e.InputParameters["PeriodAccountId"] = PeriodAccountId;
            }
        }

        protected void Change_RateGroup(object sender, EventArgs e)
        {
            int rateGroupId = Int32.Parse(RateGroupDropDown.SelectedValue);
            int id = Int32.Parse(Request.Params["id"]);
            new TimesheetController().UpdateRateGroup(id, rateGroupId);
            RateGroupChangeStatus.Text = "Changed to " + RateGroupDropDown.SelectedItem.Text;
        }

        protected void Change_TimesheetPerDiemCount(object sender, EventArgs e)
        {
            int Count = Int32.Parse(PerDiemCountDropDown.SelectedValue);
            int id = Int32.Parse(Request.Params["id"]);
            new TFS.Intranet.Data.Billing.TimesheetController().UpdatePerDiemCount(id, Count);
            PerDiemChangeStatus.Text = "Changed to " + Count;
        }

        protected void Change_Mileage(object sender, EventArgs e)
        {
            double mileage = double.Parse(Mileage_Textbox.Text);
            int id = Int32.Parse(Request.Params["id"]);
            new TFS.Intranet.Data.Billing.TimesheetController().UpdateMileage(id, mileage);
            Mileage_Status.Text = "Changed to " + mileage +" miles";
        }

        protected void inserting_timeentry(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxDay.Text))
                return;

            DateTime dayDateTime;

            if (!DateTime.TryParse(tbxDay.Text, out dayDateTime))
                return;

            int id = Int32.Parse(Request.Params["id"]);
            int __Day = dayDateTime.Day;
            String TimeIn = TimeInHours.SelectedValue + ":" + TimeInMinutes.SelectedValue + ":00";
            String TimeOut = TimeOutHours.SelectedValue + ":" + TimeOutMinutes.SelectedValue + ":00";
            String NotesText = Notes.Text;
            (new TFS.Intranet.Data.Billing.TimeEntryController()).Insert(id, __Day, TimeIn, TimeOut, NotesText, false, null, null, null, null);
            TimeEntryGridView.DataBind();
        }

        protected void inserting_expense_entry(object sender, EventArgs e)
        {
            int id = Int32.Parse(Request.Params["id"]);
            DateTime date = DateTime.Parse(ExpenseDate.Text);
            Double cost = Double.Parse(ExpenseCost.Text);
            String desc = ExpenseDesc.Text;

            (new TFS.Intranet.Data.Billing.ExpenseEntryController()).Insert(id, date, cost, desc, false, null, null, null, null);
            ExpenseGridView.DataBind();
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
