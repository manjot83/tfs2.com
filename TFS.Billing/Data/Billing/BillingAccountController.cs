using System;
using System.Collections.Generic;
using System.Text;

namespace TFS.Intranet.Data.Billing
{
    public partial class BillingAccountController
    {

        public void Update(Int32 id, String name)
        {
            var item = BillingAccount.FetchByID(id);
            item.Name = name;
            item.MarkOld();
            item.Save(UserName);
        }

        public void Insert(String Name)
        {
            Insert(Name, 0, false, null, null, null, null, 0);
        }


        public Double FetchDefaultPerDiemRateByID(Int32 id)
        {
            return FetchByID(id)[0].Defaultperdiemrate;
        }

        public void UpdateDefaultPerDiemRate(Int32 id, Double DefaultPerDiemRate)
        {
            var item = BillingAccount.FetchByID(id); 
            item.Defaultperdiemrate = DefaultPerDiemRate;
            item.MarkOld();
            item.Save(UserName);
        }

        public Double FetchDefaultMileageRateByID(Int32 id)
        {
            return FetchByID(id)[0].Defaultmileagerate;
        }

        public void UpdateDefaultMileageRate(Int32 id, Double DefaultMileageRate)
        {
            var item = BillingAccount.FetchByID(id);
            item.Defaultmileagerate = DefaultMileageRate;
            item.MarkOld();
            item.Save(UserName);
        }


    }
}
