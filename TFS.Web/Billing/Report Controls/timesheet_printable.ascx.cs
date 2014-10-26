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

public partial class billing_timesheet_printable : System.Web.UI.UserControl
{

    protected double perdiemrate;

    protected double mileagerate;

    private Int32 _timesheetid;

    public Int32 TimesheetID
    {
        get { return _timesheetid; }
        set { _timesheetid = value; timesheetid_value.Value = value.ToString(); }
    }

    private String _username = "";

    public String Username
    {
        get { return _username; }
        set { _username = value; username_value.Value = value.ToString(); }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        timesheetid_value.Value = TimesheetID.ToString();
        username_value.Value = Username.ToString();
    }

    protected override void OnPreRender(EventArgs e)
    {
        int id = TimesheetID;
        TFS.Intranet.Data.Billing.TimesheetController controller = new TFS.Intranet.Data.Billing.TimesheetController();
        perdiemrate = controller.PerDiemRateByID(id);
        mileagerate = controller.MileageRateByID(id);

        month.Value = controller.MonthByID(id).ToString();
        year.Value = controller.YearByID(id).ToString();

        base.OnPreRender(e);
    }

    protected String CalcTotalPerDiem(int count)
    {
        return (count * perdiemrate)+"";
    }

    protected String CalcTotalMileage(double mileage)
    {
        String total = ((mileage * mileagerate) + "");
        return total;
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
        foreach (RepeaterItem row in TimeEntryRepeater.Items)
        {
            TimeSpan span = TimeSpan.Parse(((Label)row.FindControl("TotalTimeLabel")).Text);
            totalTime = totalTime.Add(span);
        }
        return (totalTime.Days * 24 + totalTime.Hours).ToString("00") + " : " + totalTime.Minutes.ToString("00") + " : " + totalTime.Seconds.ToString("00");
    }

    protected String getTotalCost()
    {
        double totalCost = 0;
        foreach (RepeaterItem row in ExpenseRepeater.Items)
        {
            totalCost += Double.Parse(((Label)row.FindControl("CostLabel")).Text);
        }
        return totalCost.ToString();
    }
}
