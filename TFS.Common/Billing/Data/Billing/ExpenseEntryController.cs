using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace TFS.Intranet.Data.Billing
{
    public partial class ExpenseEntryController
    {
        public ExpenseEntryCollection FetchByTimesheetID(int timesheetid)
        {
            ExpenseEntryCollection coll = new ExpenseEntryCollection().Where(ExpenseEntry.Columns.Timesheetid, timesheetid).OrderByAsc(ExpenseEntry.Columns.Expensedate).Load();
            return coll;
        }

        public Double GetTotalByBillingPeriodAccountID(Int32 BillingPeriodAccountID)
        {
            Double total = 0;
            ExpenseEntryCollection col = this.FetchAll().Where(ExpenseEntry.Columns.IsDeleted, false);
            var allTimesheets = new TimesheetController().FetchAll();
            foreach (ExpenseEntry expenseentry in col)
            {
                var timesheet = allTimesheets.FirstOrDefault(x => x.Id == expenseentry.Timesheetid);
                if (timesheet != null && timesheet.Periodaccountid == BillingPeriodAccountID &&
                    expenseentry.IsDeleted == false)
                    total += expenseentry.Cost;
            }
            return total;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void Update(int Id, int Timesheetid, DateTime Expensedate, double Cost, string Expensedesc)
        {
            ExpenseEntry item = new ExpenseEntry();
            item.MarkOld();
            item.IsLoaded = true;
            item.Id = Id;

            item.Timesheetid = Timesheetid;

            item.Expensedate = Expensedate;

            item.Cost = Cost;

            item.Expensedesc = Expensedesc;

            item.IsDeleted = false;

            item.CreatedOn = null;

            item.CreatedBy = null;

            item.ModifiedOn = null;

            item.ModifiedBy = null;

            item.Save(UserName);
        }


        public void MoveToTimesheet(Int32 ExpenseEntryID, Int32 NewBillingPeriodAccountID, Int32 OldTimesheetID)
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
                    ExpenseEntry item = this.FetchByID(ExpenseEntryID)[0];
                    this.Update(item.Id, timesheet.Id, item.Expensedate, item.Cost, item.Expensedesc);
                    return;
                }
            }


            return;
        }
    }
}
