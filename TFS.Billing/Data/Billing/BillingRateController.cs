using System;
using System.Collections.Generic;
using System.Text;

namespace TFS.Intranet.Data.Billing
{
    public partial class BillingRateController
    {

        public BillingRateCollection FetchByPeriodAndGroup(Int32 PeriodAccountID, Int32 RateGroupID)
        {
            return new BillingRateCollection().Where(BillingRate.Columns.Periodaccountid, PeriodAccountID).Where(BillingRate.Columns.Groupid, RateGroupID).Load();
        }

        public void Update(Int32 id, Double rate)
        {
            BillingRate item = FetchByID(id)[0];
            item.Rate = rate;
            item.MarkOld();
            item.Save(UserName);
        }

    }
}
