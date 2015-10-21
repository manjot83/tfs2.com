using System;
using System.Collections.Generic;
using System.Text;

namespace TFS.Intranet.Data.Billing
{
    public partial class BillingCityRateController
    {

        public void Update(Int32 id, Double perDiemRate)
        {
            BillingCityRate item = FetchByID(id)[0];
            item.PerDiemRate = perDiemRate;
            item.MarkOld();
            item.Save(UserName);
        }
    }
}
