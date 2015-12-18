using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace TFS.Intranet.Data.Billing
{
    public partial class EmployeeTimesheetInfoController
    {        

        public EmployeeTimesheetInfoCollection GetOpenTimesheets(String Username)
        {
            return (new EmployeeTimesheetInfoCollection()).Where(EmployeeTimesheetInfo.Columns.Username, Username).Where(EmployeeTimesheetInfo.Columns.Openuntil, SubSonic.Comparison.GreaterOrEquals, DateTime.Now).OrderByDesc(EmployeeTimesheetInfo.Columns.TimesheetCreatedOn).Load();
        }

        public EmployeeTimesheetInfoCollection GetTimesheets(String Username)
        {
            return (new EmployeeTimesheetInfoCollection()).Where(EmployeeTimesheetInfo.Columns.Username, Username).OrderByDesc(EmployeeTimesheetInfo.Columns.TimesheetCreatedOn).Load();
        }

        public EmployeeTimesheetInfoCollection GetTimesheets(String Username, Int32 PeriodID)
        {
            EmployeeTimesheetInfoCollection col = (new EmployeeTimesheetInfoCollection()).Where(EmployeeTimesheetInfo.Columns.Username, Username).Where(EmployeeTimesheetInfo.Columns.Billingperiodid, PeriodID).OrderByAsc(EmployeeTimesheetInfo.Columns.Accountname).Load();
            return col;
        }

        public EmployeeTimesheetInfoCollection GetTimesheets(Int32 Billingaccountid, Int32 PeriodID)
        {
            EmployeeTimesheetInfoCollection col = (new EmployeeTimesheetInfoCollection()).Where(EmployeeTimesheetInfo.Columns.Billingaccountid, Billingaccountid).Where(EmployeeTimesheetInfo.Columns.Billingperiodid, PeriodID).OrderByAsc(EmployeeTimesheetInfo.Columns.Rategroupname).Load();
            return col;
        }

        public EmployeeTimesheetInfoCollection GetTimesheets(Int32 Billingaccountid, Int32 PeriodID, Int32 RateGroupID)
        {
            EmployeeTimesheetInfoCollection col = (new EmployeeTimesheetInfoCollection()).Where(EmployeeTimesheetInfo.Columns.Billingaccountid, Billingaccountid).Where(EmployeeTimesheetInfo.Columns.Billingperiodid, PeriodID).Where(EmployeeTimesheetInfo.Columns.Rategroupid, RateGroupID).OrderByAsc(EmployeeTimesheetInfo.Columns.Username).Load();
            return col;
        }

        public DataTable GetAccountSummaryTotals(Int32 Billingaccountid, Int32 PeriodID)
        {
            BillingPeriodAccountsJoin billingperiodaccount = new BillingPeriodAccountsJoinCollection().Where(BillingPeriodAccountsJoin.Columns.Periodid, PeriodID).Where(BillingPeriodAccountsJoin.Columns.Accountid, Billingaccountid).Load()[0];
            Int32 billingperiodaccountid = billingperiodaccount.Id;
            var timeSheetController = new TimesheetController();

            DataTable summaryTotals = new DataTable();
            summaryTotals.Columns.Add("RateGroupID");
            summaryTotals.Columns.Add("RateGroupName");
            summaryTotals.Columns.Add("Rate");
            summaryTotals.Columns.Add("TotalHours");

            summaryTotals.Columns.Add("PerDiemRate");
            summaryTotals.Columns.Add("PerDiemTotal");

            summaryTotals.Columns.Add("MileageRate");
            summaryTotals.Columns.Add("MileageTotal");

            summaryTotals.Columns.Add("ExpenseTotal");

            Double perdiemrate = billingperiodaccount.Perdiemrate;
            Double cityPerdiemRateAverage =
                timeSheetController.GetPerCityDiemRateAverageByBillingPeriodAccountID(billingperiodaccountid);
            Double perdiemtotal = timeSheetController.GetPerDiemCountByBillingPeriodAccountID(billingperiodaccountid);
            Double expensetotal = new ExpenseEntryController().GetTotalByBillingPeriodAccountID(billingperiodaccountid);
            Double mileagerate = billingperiodaccount.Mileagerate;
            Double mileagetotal = timeSheetController.GetMileageCountByBillingPeriodAccountID(billingperiodaccountid);

            if (cityPerdiemRateAverage > 0)
            {
                perdiemrate = cityPerdiemRateAverage;
            }

            RateGroupCollection rategroups = new RateGroupController().FetchAll();
            foreach (RateGroup rategroup in rategroups)
            {
                DataRow newrow = summaryTotals.NewRow();
                newrow["RateGroupID"] = rategroup.Id;
                newrow["RateGroupName"] = rategroup.Name;
                BillingRateCollection billingratecollection = new BillingRateCollection().Where(BillingRate.Columns.Periodaccountid, billingperiodaccountid).Where(BillingRate.Columns.Groupid, rategroup.Id).Load();
                newrow["Rate"] = billingratecollection[0].Rate;

                Double totalHours = 0;

                EmployeeTimesheetInfoCollection col = GetTimesheets(Billingaccountid, PeriodID, rategroup.Id);
                foreach (EmployeeTimesheetInfo timesheet in col)
                {
                    totalHours += new TimeEntriesTotalController().GetTotalHoursByTimesheetID(timesheet.Timesheetid);
                }

                newrow["TotalHours"] = totalHours;

                newrow["PerDiemRate"] = perdiemrate;
                newrow["PerDiemTotal"] = perdiemtotal;
                newrow["MileageRate"] = mileagerate;
                newrow["MileageTotal"] = mileagetotal;
                newrow["ExpenseTotal"] = expensetotal;

                summaryTotals.Rows.Add(newrow);
            }
           

            return summaryTotals;
        }

        public BillingPeriodAccountsJoinCollection GetPendingTimesheets()
        {
            BillingPeriodAccountsJoinCollection col = new BillingPeriodAccountsJoinCollection().Where(BillingPeriodAccountsJoin.Columns.Openuntil, SubSonic.Comparison.GreaterOrEquals, DateTime.Now).Load();
            BillingPeriodAccountsJoinCollection returnCollection = new BillingPeriodAccountsJoinCollection();
            returnCollection.AddRange(col);
            //foreach (Timesheet timesheet in new TimesheetController().FetchByUsername(Username))
            //    foreach (BillingPeriodAccountsJoin billingperiod in col)
            //        if (billingperiod.Id == timesheet.Periodaccountid)
            //            returnCollection.Remove(billingperiod);
            returnCollection.Sort(BillingPeriodAccountsJoin.Columns.Periodid, true);
            return returnCollection;
        }

        public EmployeeTimesheetInfoCollection FetchByID(Int32 id)
        {
            return (new EmployeeTimesheetInfoCollection()).Where(EmployeeTimesheetInfo.Columns.Timesheetid, id).Load();
        }

        public EmployeeTimesheetInfoCollection FetchByBillingPeriodID(Int32 id)
        {
            return (new EmployeeTimesheetInfoCollection()).Where(EmployeeTimesheetInfo.Columns.Billingperiodid, id).OrderByAsc(EmployeeTimesheetInfo.Columns.Accountname).Load();
        }

        public DataTable GetUsernamesByBillingPeriodID(Int32 id)
        {
            EmployeeTimesheetInfoCollection col = FetchByBillingPeriodID(id);
            System.Collections.ArrayList users = new System.Collections.ArrayList();
            foreach (EmployeeTimesheetInfo employeeinfo in col)
                if (!users.Contains(employeeinfo.Username))
                    users.Add(employeeinfo.Username);
            DataTable userstable = new DataTable();
            userstable.Columns.Add("Username");
            foreach (String username in users)
            {
                DataRow newrow = userstable.NewRow();
                newrow["Username"] = username;
                userstable.Rows.Add(newrow);
            }
            return userstable;
        }

        public DataTable GetBillingAccountsByBillingPeriodID(Int32 id)
        {
            EmployeeTimesheetInfoCollection col = FetchByBillingPeriodID(id);
            System.Collections.ArrayList accounts = new System.Collections.ArrayList();

                
            DataTable accountstable = new DataTable();
            accountstable.Columns.Add("AccountName");
            accountstable.Columns.Add("AccountID");
            foreach (EmployeeTimesheetInfo timesheetinfo in col)
            {
                if (accounts.Contains(timesheetinfo.Billingaccountid))
                    continue;
                DataRow newrow = accountstable.NewRow();
                newrow["AccountName"] = timesheetinfo.Accountname;
                newrow["AccountID"] = timesheetinfo.Billingaccountid;
                accountstable.Rows.Add(newrow);
                accounts.Add(timesheetinfo.Billingaccountid);
            }
            return accountstable;
        }


    }
}
