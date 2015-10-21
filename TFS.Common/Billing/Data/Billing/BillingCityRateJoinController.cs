using System;
using System.Collections.Generic;
using System.Text;

namespace TFS.Intranet.Data.Billing
{
    public partial class BillingCityRateJoinController
    {
        public BillingCityRateJoinCollection FetchByPeriodID(Int32 periodid)
        {
            return new BillingCityRateJoinCollection().Where(BillingCityRateJoin.Columns.Periodid, periodid).OrderByAsc(BillingCityRateJoin.Columns.Accountname).Load();
        }

        public BillingCityRateJoinCollection FetchByPeriodAccountId(Int32 periodAccountId)
        {
            return new BillingCityRateJoinCollection().Where(BillingCityRateJoin.Columns.Periodaccountid, periodAccountId).OrderByAsc(BillingCityRateJoin.Columns.City).Load();
        }
    }
}
