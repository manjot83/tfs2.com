using System;
using System.Collections.Generic;
using System.Text;

namespace TFS.Intranet.Data.Billing
{
    public partial class RateGroup
    {

        public TFS.Intranet.Data.Billing.BillingRateCollection BillingRates(int billingperiodaccountid)
        {
            return new TFS.Intranet.Data.Billing.BillingRateCollection().Where(BillingRate.Columns.Groupid, Id).Where(BillingRate.Columns.Periodaccountid, billingperiodaccountid).Load();
        }

    }
}
