using System;
using System.Collections.Generic;
using System.Text;

namespace TFS.Intranet.Data.Billing
{
    public partial class BillingRatesJoinController
    {
        public BillingRatesJoinCollection FetchByPeriodID(Int32 periodid)
        {
            return new BillingRatesJoinCollection().Where(BillingRatesJoin.Columns.Periodid, periodid).OrderByAsc(BillingRatesJoin.Columns.Accountname).Load();
        }
    }
}
