using System;
using System.Collections.Generic;
using System.Text;

namespace TFS.Intranet.Data.Billing
{
    public partial class TimesheetBillingCityRateJoinController
    {
        public TimesheetBillingCityRateJoinCollection FetchActiveByTimesheetId(Int32 timesheetId)
        {
            return new TimesheetBillingCityRateJoinCollection()
                .Where(TimesheetBillingCityRateJoin.Columns.TimesheetId, timesheetId)
                .Where(TimesheetBillingCityRateJoin.Columns.IsDeleted, false)
                .OrderByAsc(TimesheetBillingCityRateJoin.Columns.City).Load();
        }

        public TimesheetBillingCityRateJoinCollection FetchByPeriodAccountId(Int32 periodAccountId)
        {
            return new TimesheetBillingCityRateJoinCollection().Where(TimesheetBillingCityRateJoin.Columns.Periodaccountid, periodAccountId).OrderByAsc(TimesheetBillingCityRateJoin.Columns.City).Load();
        }

        public double CityPerDiemRateGrandTotalByTimesheetId(int timesheetId)
        {
            var col = this.FetchActiveByTimesheetId(timesheetId);
            var cityPerdiemTotal = 0.00;

            foreach (var cityRate in col)
            {
                cityPerdiemTotal += (cityRate.PerdiemCount * cityRate.PerDiemRate);
            }

            return cityPerdiemTotal;
        }

        public double CityPerDiemHourlyRateAverageByTimesheetId(int timesheetId)
        {
            var col = this.FetchActiveByTimesheetId(timesheetId);
            var perdiemCityRateSum = 0.00;
            var retAvg = 0.00; //display if there are no City per diems

            foreach (var cityRate in col)
            {
                perdiemCityRateSum += cityRate.PerDiemRate;
            }

            if (col.Count > 0)
                retAvg = perdiemCityRateSum / col.Count; //get the average

            return retAvg;
        }

        public int CityPerDiemCountGrandTotalByTimesheetId(int timesheetId)
        {
            var col = this.FetchActiveByTimesheetId(timesheetId);
            var perdiemCityCount = 0;

            foreach (var cityRate in col)
            {
                perdiemCityCount += cityRate.PerdiemCount;
            }

            return perdiemCityCount;
        }
    }
}
