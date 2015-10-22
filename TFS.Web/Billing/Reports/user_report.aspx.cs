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
using NHibernate.Hql.Ast.ANTLR;
using TFS.Intranet.Data.Billing;
using TFS.OpCenter;

namespace TFS.Intranet.Web.Billing.Reports
{
    public partial class user_report : System.Web.UI.Page
    {
        protected override void OnPreLoad(EventArgs e)
        {

            base.OnPreLoad(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ReportableTimesheets.DataBind();
        }

        protected TimeSpan GetTimeDifference(String time1, String time2)
        {
            TimeSpan timespan1 = TimeSpan.Parse(time1);
            TimeSpan timespan2 = TimeSpan.Parse(time2);
            TimeSpan timespan3 = timespan2.Subtract(timespan1);
            return timespan3;
        }

        protected TimeSpan GetTotalTimespan(Int32 TimesheetID)
        {
            int PeriodID = Int32.Parse(Request.Params["id"]);
            String Username = Request.Params["username"];

            TFS.Intranet.Data.Billing.TimeEntryCollection col = new TFS.Intranet.Data.Billing.TimeEntryController().FetchByTimesheetID(TimesheetID);

            TimeSpan totalTime = new TimeSpan(0);
            foreach (TFS.Intranet.Data.Billing.TimeEntry timeentry in col)
            {
                totalTime = totalTime.Add(GetTimeDifference(timeentry.Timein, timeentry.Timeout));
            }
            return totalTime;
        }

        protected String GetTotalTime(Int32 TimesheetID)
        {
            TimeSpan totalTime = GetTotalTimespan(TimesheetID);

            return (totalTime.Days * 24 + totalTime.Hours).ToString("00") + ":" + totalTime.Minutes.ToString("00") + ":" + totalTime.Seconds.ToString("00");
        }

        protected String GetTotalHoursCost(Double Rate, Int32 TimesheetID)
        {
            TimeSpan totaltime = GetTotalTimespan(TimesheetID);
            Double total = totaltime.TotalHours * Rate;
            return total.ToString();
        }

        protected String GetTotalExpenses(Int32 TimesheetID)
        {
            int PeriodID = Int32.Parse(Request.Params["id"]);
            String Username = Request.Params["username"];

            TFS.Intranet.Data.Billing.ExpenseEntryCollection col = new TFS.Intranet.Data.Billing.ExpenseEntryController().FetchByTimesheetID(TimesheetID);

            Double total = 0;
            foreach (TFS.Intranet.Data.Billing.ExpenseEntry expenseentry in col)
            {
                total += expenseentry.Cost;
            }

            return total.ToString();
        }

        protected String GetPerDiemCount(int count, int timesheetId)
        {
            var timeBillingCityRateJoinController = new TimesheetBillingCityRateJoinController();
            var perdiemCityCount = timeBillingCityRateJoinController.CityPerDiemCountGrandTotalByTimesheetId(timesheetId);


            return perdiemCityCount > 0 ? perdiemCityCount.ToString() : count.ToString();
        }

        protected String GetPerDiemRate(Double rate, int timesheetId)
        {
            var timeBillingCityRateJoinController = new TimesheetBillingCityRateJoinController();
            var cityPerdiemAvg = timeBillingCityRateJoinController.CityPerDiemHourlyRateAverageByTimesheetId(timesheetId);

            return cityPerdiemAvg > 0 ? cityPerdiemAvg.ToString() : rate.ToString();
        }

        protected String GetPerDiemGrandTotal(int count, Double rate, int timesheetId)
        {
            var timeBillingCityRateJoinController = new TimesheetBillingCityRateJoinController();
            var cityPerdiemTotal = timeBillingCityRateJoinController.CityPerDiemRateGrandTotalByTimesheetId(timesheetId);
            var perdiemIfNoCities = count * rate; ;//no cities BillingRate Per Diem

            return cityPerdiemTotal > 0 ? cityPerdiemTotal.ToString() : perdiemIfNoCities.ToString();
        }

        protected String GetRateTotal(Double count, Double rate)
        {
            Double total = count * rate;
            return total.ToString();
        }

        protected String SumTotalHours()
        {
            TimeSpan totalTime = new TimeSpan(0,0,0);

            foreach (RepeaterItem row in SummaryRepeater.Items)
            {
                String totalHoursString = ((Label)row.FindControl("TotalHours")).Text;
                String[] parsedTime = totalHoursString.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                totalTime = totalTime.Add(new TimeSpan(Int32.Parse(parsedTime[0]), Int32.Parse(parsedTime[1]), Int32.Parse(parsedTime[2])));
            }

            return (totalTime.Days * 24 + totalTime.Hours).ToString("00") + ":" + totalTime.Minutes.ToString("00") + ":" + totalTime.Seconds.ToString("00");

        }

        protected String SumTotalBillingHours()
        {
            Double totalhours = 0;

            foreach (RepeaterItem row in SummaryRepeater.Items)
            {
                totalhours += Double.Parse(((Label)row.FindControl("TotalBillingHours")).Text);
            }

            return totalhours.ToString();
        }

        protected String SumTotalExpenses()
        {
            Double totalexpenses = 0;

            foreach (RepeaterItem row in SummaryRepeater.Items)
            {
                totalexpenses += Double.Parse(((Label)row.FindControl("TotalExpenses")).Text);
            }

            return totalexpenses.ToString();
        }

        protected String SumTotalPerDiemCount()
        {
            Double total = 0;

            foreach (RepeaterItem row in SummaryRepeater.Items)
            {
                total += Double.Parse(((Label)row.FindControl("PerDiemCount")).Text);
            }

            return total.ToString();
        }

        protected String SumTotalPerDiemTotal()
        {
            Double total = 0;

            foreach (RepeaterItem row in SummaryRepeater.Items)
            {
                total += Double.Parse(((Label)row.FindControl("PerDiemTotal")).Text);
            }

            return total.ToString();
        }

        protected String SumTotalMileageCount()
        {
            Double total = 0;

            foreach (RepeaterItem row in SummaryRepeater.Items)
            {
                total += Double.Parse(((Label)row.FindControl("MileageCount")).Text);
            }

            return total.ToString();
        }

        protected String SumTotalMileageTotal()
        {
            Double total = 0;

            foreach (RepeaterItem row in SummaryRepeater.Items)
            {
                total += Double.Parse(((Label)row.FindControl("MileageTotal")).Text);
            }

            return total.ToString();
        }
    }
}
