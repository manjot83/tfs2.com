using System;
using System.Collections.Generic;
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
    }
}
