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

namespace TFS.Intranet.Web.Scheduling
{
    public partial class AvailabilityReport : System.Web.UI.Page
    {
        private DateTime visibleDate;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (ViewState["VisibleDate"] == null)
                visibleDate = DateTime.Now;
            else
                visibleDate = (DateTime)ViewState["VisibleDate"];

            AvailCalendar.Month = visibleDate.Month;
            AvailCalendar.Year = visibleDate.Year;

            SelectMonthButton.Click += new EventHandler(SelectMonthButton_Click);
            String MonthName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(visibleDate.Month);
            MonthLabel.Text = MonthName + "," + visibleDate.Year.ToString();
        }

        void SelectMonthButton_Click(object sender, EventArgs e)
        {
            int Month = Int32.Parse(MonthDropDown.SelectedValue);
            int Year = Int32.Parse(YearDropDown.SelectedValue);
            visibleDate = new DateTime(Year, Month, 1);

            AvailCalendar.Month = visibleDate.Month;
            AvailCalendar.Year = visibleDate.Year;
            ViewState["VisibleDate"] = visibleDate;

            String MonthName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Month);
            MonthLabel.Text = MonthName + "," + Year;

            AvailCalendar.DataBind();
        }
    }
}
