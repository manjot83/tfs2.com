using System;
using System.Collections.Generic;
using System.Text;
using SubSonic;

namespace TFS.Intranet.Data.Billing
{
    public partial class TimesheetController
    {

        public TimesheetCollection FetchByUsername(String Username)
        {
            return new TimesheetCollection().Where(Timesheet.Columns.Username, Username).Load();
        }

        public Boolean TimesheetExists(String Username, Int32 PeriodAccountID)
        {
            return (FetchByUsernamePeriodID(Username, PeriodAccountID).Count > 0);
        }

        public TimesheetCollection FetchByUsernamePeriodID(String Username, Int32 PeriodAccountID)
        {
            return new TimesheetCollection().Where(Timesheet.Columns.Username, Username).Where(Timesheet.Columns.Periodaccountid, PeriodAccountID).Load();
        }

        public TimesheetCollection FetchORCreateByUsernamePeriodID(String Username, Int32 PeriodAccountID)
        {
            TimesheetCollection col = FetchByUsernamePeriodID(Username, PeriodAccountID);
            var user = new UserController().ByUsername(Username);
            if (col.Count == 0 && user != null)
                Insert(Username, PeriodAccountID, user.Rategroup);
            return FetchByUsernamePeriodID(Username, PeriodAccountID);
        }

        public void UpdateRateGroup(int id, int rateGroupId)
        {
            Timesheet item = FetchByID(id)[0];

            item.Rategroupid = rateGroupId;

            item.MarkOld();
            item.Save(UserName);
        }

        public void UpdatePerDiemCount(int Id, int Perdiemcount)
        {
            Timesheet item = FetchByID(Id)[0];

            item.Perdiemcount = Perdiemcount;

            item.MarkOld();
            item.Save(UserName);
        }

        public void UpdateMileage(int Id, double MileageClaimed)
        {
            Timesheet item = FetchByID(Id)[0];

            item.Mileageclaimed = MileageClaimed;

            item.MarkOld();
            item.Save(UserName);
        }


        public int Insert(String Username, Int32 PeriodAccountID, int rategroupid)
        {
            return Insert(Username, PeriodAccountID, 0, false, null, null, null, null, 0, rategroupid);
        }



        public int MonthByID(int id)
        {
            return FetchByID(id)[0].BillingPeriodAccount.BillingPeriod.Month;
        }

        public int YearByID(int id)
        {
            return FetchByID(id)[0].BillingPeriodAccount.BillingPeriod.Year;
        }

        public double PerDiemRateByID(int id)
        {
            return FetchByID(id)[0].BillingPeriodAccount.Perdiemrate;
        }

        public double MileageRateByID(int id)
        {
            return FetchByID(id)[0].BillingPeriodAccount.Mileagerate;
        }


        public void DeleteTimesheet(int TimesheetID)
        {
            //first delete expense entries
            ExpenseEntry.Delete(ExpenseEntry.Columns.Timesheetid, TimesheetID, this.UserName);

            //second delete time entries
            TimeEntry.Delete(TimeEntry.Columns.Timesheetid, TimesheetID, this.UserName);

            //finally delete the time sheet
            this.Delete(TimesheetID);
        }

        public Double GetPerCityDiemRateAverageByBillingPeriodAccountID(Int32 BillingPeriodAccountID)
        {
            var timesheetBillingRateCityJoin = new TimesheetBillingCityRateJoinController();
            var cityPerdiemRateAverageTotal = 0.00;

            Double total = 0;
            TimesheetCollection col = this.FetchAllByPeriodAccountId(BillingPeriodAccountID);
            foreach (Timesheet timesheet in col)
            {
                cityPerdiemRateAverageTotal += timesheetBillingRateCityJoin.CityPerDiemHourlyRateAverageByTimesheetId(timesheet.Id);
            }

            if (col.Count > 0)
                cityPerdiemRateAverageTotal = cityPerdiemRateAverageTotal / col.Count;

            return cityPerdiemRateAverageTotal;
        }

        public Double GetPerDiemCountByBillingPeriodAccountID(Int32 BillingPeriodAccountID)
        {
            var timesheetBillingRateCityJoin = new TimesheetBillingCityRateJoinController();
            var cityPerdiemCountTotal = 0;

            Double total = 0;
            TimesheetCollection col = this.FetchAllByPeriodAccountId(BillingPeriodAccountID);
            foreach (Timesheet timesheet in col)
            {
                cityPerdiemCountTotal += timesheetBillingRateCityJoin.CityPerDiemCountGrandTotalByTimesheetId(timesheet.Id);
                total += timesheet.Perdiemcount;
            }

            return cityPerdiemCountTotal > 0 ? cityPerdiemCountTotal : total;
        }

        public Double GetMileageCountByBillingPeriodAccountID(Int32 BillingPeriodAccountID)
        {
            Double total = 0;
            TimesheetCollection col = this.FetchAll();
            foreach (Timesheet timesheet in col)
            {
                if (timesheet.Periodaccountid == BillingPeriodAccountID)
                    total += timesheet.Mileageclaimed;
            }
            return total;
        }


    }
}
