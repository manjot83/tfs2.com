using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TFS.Intranet.Data.Billing
{
    public partial class BillingPeriodAccountsJoinController
    {
        public BillingPeriodAccountsJoinCollection FetchAll()
        {
            return new BillingPeriodAccountsJoinCollection().Load();
        }

        public BillingPeriodAccountsJoinCollection FetchByPeriodID(Int32 periodid)
        {
            return new BillingPeriodAccountsJoinCollection().Where(BillingPeriodAccountsJoin.Columns.Periodid, periodid).OrderByAsc(BillingPeriodAccountsJoin.Columns.Accountname).Load();
        }

        public BillingPeriodAccountsJoinCollection FetchByPeriodIDWithoutCityPerdiem(Int32 periodid)
        {
            var billingCityRateController = new BillingCityRateController();
                var billingCityCol = billingCityRateController.FetchAllActive();
            var billingPeriodsCol =  new BillingPeriodAccountsJoinCollection().Where(BillingPeriodAccountsJoin.Columns.Periodid, periodid).OrderByAsc(BillingPeriodAccountsJoin.Columns.Accountname).Load();
            var billingCityPeriodAccountIds = new List<int>();
        
            var retBillingPeriodAccountCol = new BillingPeriodAccountsJoinCollection();

            billingCityPeriodAccountIds.AddRange(billingCityCol.Select(billingCity => billingCity.Periodaccountid));

            foreach (var billingPeriod in billingPeriodsCol)
            {
                if(!billingCityPeriodAccountIds.Contains(billingPeriod.Id))
                    retBillingPeriodAccountCol.Add(billingPeriod);
            }

            return retBillingPeriodAccountCol;
        }

        public BillingPeriodAccountsJoinCollection FetchOpenPeriodByAccountId(int accountId)
        {
            return (new BillingPeriodAccountsJoinCollection())
                .Where(BillingPeriodAccountsJoin.Columns.Openuntil, SubSonic.Comparison.GreaterOrEquals, DateTime.Now)
                .Where(BillingPeriodAccountsJoin.Columns.Accountid, accountId)
                .Load();
        }
    }
}
