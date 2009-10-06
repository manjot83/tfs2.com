using System;
using System.Collections.Generic;
using System.Text;

namespace TFS.Intranet.Data.Billing
{
    public partial class TimeEntriesTotalController
    {

        public TimeEntriesTotalCollection FetchByTimesheetID(int TimesheetID)
        {
            TimeEntriesTotalCollection col = new TimeEntriesTotalCollection().Where(TimeEntriesTotal.Columns.Timesheetid, TimesheetID).Load();
            return col;
        }

        public double GetTotalHoursByTimesheetID(Int32 TimesheetID)
        {
            TimeEntriesTotalCollection col = FetchByTimesheetID(TimesheetID);
            double? total = 0;
            foreach (TimeEntriesTotal timeentriestotal in col)
            {
                total += timeentriestotal.Totalhours;
            }
            return (double)total;
        }

    }
}
