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
    public partial class Availability : System.Web.UI.Page
    {

        private DateTime visibleDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            EnableViewState = true;
            AvailCalendar.Username = GetUsername();


            if (ViewState["VisibleDate"] == null)
                visibleDate = DateTime.Now;
            else
                visibleDate = (DateTime)ViewState["VisibleDate"];

            AvailCalendar.VisibleDate = visibleDate;

            SelectMonthButton.Click += new EventHandler(SelectMonthButton_Click);
            String MonthName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(visibleDate.Month);
            MonthLabel.Text = MonthName + "," + visibleDate.Year.ToString();            
        }

        protected String GetUsername()
        {
            String name = Request.Params["username"];
            if (String.IsNullOrEmpty(name))
                name = Page.User.Identity.Name;
            return name.Substring(name.IndexOf('\\') + 1);
        }

        void SelectMonthButton_Click(object sender, EventArgs e)
        {
            int Month = Int32.Parse(MonthDropDown.SelectedValue);
            int Year = Int32.Parse(YearDropDown.SelectedValue);
            visibleDate = new DateTime(Year, Month, 1);

            AvailCalendar.VisibleDate = visibleDate;
            ViewState["VisibleDate"] = visibleDate;

            String MonthName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Month);
            MonthLabel.Text = MonthName + "," + Year;
        }
    }
}
