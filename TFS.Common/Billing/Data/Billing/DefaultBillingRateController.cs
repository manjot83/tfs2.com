using System;
using System.Collections.Generic;
using System.Text;

namespace TFS.Intranet.Data.Billing
{
    public partial class DefaultBillingRateController
    {
        public DefaultBillingRateCollection FetchByAccountAndGroup(Int32 AccountID, Int32 RateGroupID)
        {
            return (new DefaultBillingRateCollection()).Where(DefaultBillingRate.Columns.Accountid, AccountID).Where(DefaultBillingRate.Columns.Groupid, RateGroupID).Load();
        }

        public Double FetchRate(Int32 AccountID, Int32 RateGroupID)
        {
            DefaultBillingRateCollection col = FetchByAccountAndGroup(AccountID, RateGroupID);
            if (col.Count == 0)
                return 0;
            return col[0].Rate;
        }

        public void UpdateRate(Int32 AccountID, Int32 RateGroupID, Double Rate)
        {
            if (FetchByAccountAndGroup(AccountID, RateGroupID).Count == 0)
                Insert(AccountID, RateGroupID, Rate, false, null, null, null, null);

            DefaultBillingRate item = new DefaultBillingRate();
            item.MarkOld();
            item.IsLoaded = true;

            item.Id = FetchByAccountAndGroup(AccountID, RateGroupID)[0].Id;

            item.Accountid = AccountID;

            item.Groupid = RateGroupID;

            item.Rate = Rate;

            item.Save(UserName);
        }

    }
}
