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
    public partial class timecardreport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Int32.Parse(Request.Params["id"]);

            TFS.Intranet.Data.Billing.TimesheetController controller = new TFS.Intranet.Data.Billing.TimesheetController();

            month.Value = Request.Params["month"];
            year.Value = Request.Params["year"];

            if (!IsPostBack)
            {
                TFS.Intranet.Data.Billing.Timesheet timesheet = new TFS.Intranet.Data.Billing.TimesheetController().FetchByID(id)[0];
                DaysPerDiem.Text = timesheet.Perdiemcount.ToString();
                Mileage.Text = timesheet.Mileageclaimed.ToString();
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
