using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace TFS.Intranet.Data.Billing
{
    public partial class TimeEntryController
    {

        public TimeEntryCollection FetchByTimesheetID(int timesheetid)
        {
            TimeEntryCollection coll = new TimeEntryCollection().Where(TimeEntry.Columns.Timesheetid, timesheetid).OrderByAsc(TimeEntry.Columns.Day).Load();
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void Update(int Id, int Timesheetid, int Day, string Timein, string Timeout, string Notes)
        {
            TimeEntry item = new TimeEntry();
            item.MarkOld();
            item.IsLoaded = true;

            item.Id = Id;
            item.Timesheetid = Timesheetid;
            item.Day = Day;
            item.Timein = Timein;
            item.Timeout = Timeout;
            item.Notes = Notes;
            item.IsDeleted = false;
            item.CreatedOn = null;
            item.CreatedBy = null;
            item.ModifiedOn = null;
            item.ModifiedBy = null;
            
            item.Save(UserName);
        }

        public void MoveToTimesheet(Int32 TimeEntryID, Int32 NewBillingPeriodAccountID, Int32 OldTimesheetID)
        {
            TimesheetController timesheetcontroller = new TimesheetController();
            Timesheet oldtimesheet = timesheetcontroller.FetchByID(OldTimesheetID)[0];
            String username = oldtimesheet.Username;

            if (!timesheetcontroller.TimesheetExists(username, NewBillingPeriodAccountID))
            {
                timesheetcontroller.Insert(username, NewBillingPeriodAccountID, oldtimesheet.Rategroupid);
            }

            TimesheetCollection col = new BillingPeriodAccountController().FetchByID(NewBillingPeriodAccountID)[0].Timesheets();
            foreach (Timesheet timesheet in col)
            {
                if (timesheet.Username.Equals(username))
                {
                    TimeEntry item = this.FetchByID(TimeEntryID)[0];
                    this.Update(item.Id, timesheet.Id, item.Day, item.Timein, item.Timeout, item.Notes);
                    return;
                }
            }            
            

            return;
        }
    }
}
