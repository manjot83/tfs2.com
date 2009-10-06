using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace TFS.Intranet.Web
{
    public class Calendar
    {
        public Calendar()
        {
        }

        public DataTable getTimeOfDay(String TimeType)
        {
            DataTable timeTable = new DataTable("TimeOfDay");
            timeTable.Columns.Add(new DataColumn("TimeType"));
            timeTable.Columns.Add(new DataColumn("Time"));

            if (TimeType.Equals("Hour"))
            {
                for (int i = 0; i < 24; i++)
                {

                    DataRow row = timeTable.NewRow();
                    row["TimeType"] = TimeType;
                    row["Time"] = i.ToString("d2");
                    timeTable.Rows.Add(row);
                }
            }

            if (TimeType.Equals("Minute"))
            {
                for (int i = 0; i < 60; i += 15)
                {
                    DataRow row = timeTable.NewRow();
                    row["TimeType"] = TimeType;
                    row["Time"] = i.ToString("d2");
                    timeTable.Rows.Add(row);
                }
            }

            if (TimeType.Equals("Second"))
            {
                for (int i = 0; i < 60; i += 15)
                {
                    DataRow row = timeTable.NewRow();
                    row["TimeType"] = TimeType;
                    row["Time"] = i.ToString("d2");
                    timeTable.Rows.Add(row);
                }
            }

            if (TimeType.Equals("All"))
            {
                for (int i = 0; i < 24; i++)
                {
                    for (int j = 0; j < 60; j += 15)
                    {
                        DataRow row = timeTable.NewRow();
                        row["TimeType"] = TimeType;
                        row["Time"] = i.ToString("d2") + ":" + j.ToString("d2") + ":00";
                        timeTable.Rows.Add(row);
                    }
                }
            }

            return timeTable;
        }

        public DataTable getDaysOfMonth(int Month, int Year)
        {
            int daysInMonth = DateTime.DaysInMonth(Year, Month);
            DataTable daysTable = new DataTable("DaysOfMonth");
            daysTable.Columns.Add(new DataColumn("Day"));
            for (int i = 1; i <= daysInMonth; i++)
            {
                DataRow row = daysTable.NewRow();
                row["Day"] = i;
                daysTable.Rows.Add(row);
            }
            return daysTable;
        }

    }
}