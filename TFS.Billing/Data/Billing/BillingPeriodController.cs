using System;
using System.Collections.Generic;
using System.Text;

namespace TFS.Intranet.Data.Billing
{
    public partial class BillingPeriodController
    {

        public BillingPeriodCollection FetchOrdered()
        {
            return (new BillingPeriodCollection()).OrderByDesc(BillingPeriod.Columns.Id).Load();
        }

        public void Insert(Int32 Month, Int32 Year, DateTime OpenUntil)
        {
            if (new BillingPeriodCollection().Where(BillingPeriod.Columns.Year, Year).Where(BillingPeriod.Columns.Month, Month).Load().Count > 0)
                return;
            Insert(Month, Year, OpenUntil, false, null, null, null, null);
        }

        public void Update(Int32 Id, DateTime OpenUntil)
        {
            BillingPeriod item = new BillingPeriod(Id);

            item.Openuntil = OpenUntil;

            item.MarkOld();

            item.Save(UserName);
        }

    }
}
