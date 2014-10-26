using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TFS.OpCenter.Scheduling;
using System.Linq;
using TFS.OpCenter.Data;

namespace TFS.OpCenter.UI
{
    [ToolboxData("<{0}:AvailabilityReport runat=server></{0}:AvailabilityReport>")]
    public class AvailabilityReport : Table
    {
        public int Month
        {
            get;
            set;
        }

        public int Year
        {
            get;
            set;
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            this.Width = new Unit("100%");
            this.BorderColor = System.Drawing.Color.Black;
            this.BorderStyle = BorderStyle.Solid;
            this.BorderWidth = new Unit("1");

            this.CellSpacing = 0;
            this.CellPadding = 1;

            
            List<Availability> availabilities = TFS.OpCenter.Scheduling.AvailabilityController.GetAvailabilityRecords(Month, Year);

            int DaysInMonth = System.Globalization.CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(Year, Month);
            TableHeaderRow headerRow = new TableHeaderRow();
            
            TableHeaderCell usernameCell = new TableHeaderCell();
            usernameCell.Text = "User";
            headerRow.Controls.Add(usernameCell);
            for (int i = 1; i < DaysInMonth+1; i++)
            {
                TableHeaderCell dayCell = new TableHeaderCell();
                dayCell.Text = i.ToString();
                headerRow.Controls.Add(dayCell);
                dayCell.BorderColor = System.Drawing.Color.Black;
                dayCell.BorderStyle = BorderStyle.Solid;
                dayCell.BorderWidth = new Unit("1");
                dayCell.Width = new Unit("50px");
            }
            this.Controls.Add(headerRow);

            var persons = (from a in availabilities
                           select a.Person).Distinct(new Person.Comparers.EqualityComparer());

            foreach (Person person in persons)
            {
                TableRow row = new TableRow();

                TableCell name = new TableCell();
                name.Text = person.Username;
                row.Controls.Add(name);

                for (int day = 1; day < DaysInMonth+1; day++)
                {
                    var availability = (from a in availabilities
                                        where a.Day == day &&
                                              a.Person.Id == person.Id
                                        select a).DefaultIfEmpty(null).First();

                    TableCell dayCell = new TableCell();
                    dayCell.Text = "&nbsp;";
                    if (availability != null && availability.Isavailable)
                        dayCell.BackColor = System.Drawing.Color.Blue;
                    else
                        dayCell.BackColor = System.Drawing.Color.White;

                    row.Controls.Add(dayCell);
                    dayCell.BorderColor = System.Drawing.Color.Black;
                    dayCell.BorderStyle = BorderStyle.Solid;
                    dayCell.BorderWidth = new Unit("1");
                    dayCell.Width = new Unit("50px");
                }

                this.Controls.Add(row);
            }
        }

    }
}
