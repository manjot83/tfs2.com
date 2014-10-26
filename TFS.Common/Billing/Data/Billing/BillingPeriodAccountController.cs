using System;
using System.Collections.Generic;
using System.Text;

namespace TFS.Intranet.Data.Billing
{
    public partial class BillingPeriodAccountController
    {

        public BillingAccountCollection FetchAccountsNotActive(Int32 periodid)
        {
            BillingAccountCollection disabledacocunts = new BillingAccountCollection();
            BillingAccountCollection col = new BillingAccountCollection().Load();
            disabledacocunts.AddRange(col);
            foreach (BillingPeriodAccount billingperiodaccount in new BillingPeriodAccountCollection().Where(BillingPeriodAccount.Columns.Periodid, periodid).Load())
                foreach (BillingAccount account in col)
                    if (account.Id == billingperiodaccount.Accountid)
                        disabledacocunts.Remove(account);
            return disabledacocunts;

        }

        public void UpdateMileageRate(Int32 id, Double mileagerate)
        {
            BillingPeriodAccount item = FetchByID(id)[0];
            item.Mileagerate = mileagerate;
            item.MarkOld();
            item.Save(UserName);
        }

        public void UpdatePerDiemRate(Int32 id, Double perdiemrate)
        {
            BillingPeriodAccount item = FetchByID(id)[0];
            item.Perdiemrate = perdiemrate;
            item.MarkOld();
            item.Save(UserName);
        }


        public void Insert(Int32 PeriodID, Int32 AccountID)
        {

            /* step 1 is to create our row in BillingPeriodAccounts table */

            BillingAccount billingAccount = new BillingAccountController().FetchByID(AccountID)[0];

            Insert(PeriodID, AccountID, billingAccount.Defaultperdiemrate, false, null, null, null, null, billingAccount.Defaultmileagerate);

            BillingPeriodAccount current = new BillingPeriodAccountCollection().Where(BillingPeriodAccount.Columns.Periodid, PeriodID).Where(BillingPeriodAccount.Columns.Accountid, AccountID).Load()[0];

            int periodaccountid = current.Id;

            /* step 2 is for each rate group, pull out the default value from DefaultBillingRates and Insert into BillingRates for this BillingPeriodAccount*/

            BillingRateController billingRateController = new BillingRateController();
            foreach (RateGroup rategroup in new RateGroupController().FetchAll())
            {
                double defaultrate = new DefaultBillingRateController().FetchRate(AccountID, rategroup.Id);

                billingRateController.Insert(periodaccountid, rategroup.Id, defaultrate, false, null, null, null, null);
            }

        }

    }
}
