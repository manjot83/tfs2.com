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

public partial class billing_timesheet_printable : System.Web.UI.UserControl
{
    private Int32 _timesheetid;

    private TFS.Intranet.Data.Billing.TimesheetController _controller = new TFS.Intranet.Data.Billing.TimesheetController();

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
        month.Value = _controller.MonthByID(TimesheetID).ToString();
        year.Value = _controller.YearByID(TimesheetID).ToString();

        base.OnPreRender(e);
    }

    protected String CalcTotalPerDiemCount(int count)
    {
        var timeBillingCityRateJoinController = new TimesheetBillingCityRateJoinController();
        var cityCountTotal = timeBillingCityRateJoinController.CityPerDiemCountGrandTotalByTimesheetId(TimesheetID);
        
        return cityCountTotal > 0 ? cityCountTotal.ToString() : count.ToString();

    }

    protected String CalcTotalPerDiem(int billingRatePerDiemCount)
    {
        var timeBillingCityRateJoinController = new TimesheetBillingCityRateJoinController();
        var cityPerdiemTotal = timeBillingCityRateJoinController.CityPerDiemRateGrandTotalByTimesheetId(TimesheetID);
        var perdiemIfNotCities = _controller.PerDiemRateByID(TimesheetID) * billingRatePerDiemCount;//no cities BillingRate Per Diem
        var perdiemTotalForDisplay = perdiemIfNotCities; 

        if (cityPerdiemTotal > 0)
            perdiemTotalForDisplay = cityPerdiemTotal;

        return string.Format("{0:C}", perdiemTotalForDisplay);
    }

    protected String CalcTotalMileage(double mileage)
    {
        var mileagerate = _controller.MileageRateByID(TimesheetID);
        return string.Format("{0:C}", (mileage * mileagerate));
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
