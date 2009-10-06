using System;
using System.Collections.Generic;
using System.Text;

namespace TFS.Intranet.Data.Billing
{
    public partial class BillingAccountController
    {

        public void Update(Int32 id, String name)
        {
            BillingAccount item = new BillingAccount();

            item.Id = id;

            item.Name = name;

            item.Defaultperdiemrate = FetchByID(id)[0].Defaultperdiemrate;

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
            BillingAccount item = new BillingAccount();

            item.Id = id;

            item.Name = FetchByID(id)[0].Name;

            item.Defaultperdiemrate = DefaultPerDiemRate;
            item.Defaultmileagerate = FetchByID(id)[0].Defaultmileagerate;

            item.MarkOld();
            item.Save(UserName);
        }

        public Double FetchDefaultMileageRateByID(Int32 id)
        {
            return FetchByID(id)[0].Defaultmileagerate;
        }
        
        public void UpdateDefaultMileageRate(Int32 id, Double DefaultMileageRate)
        {
            BillingAccount item = new BillingAccount();

            item.Id = id;

            item.Name = FetchByID(id)[0].Name;

            item.Defaultmileagerate = DefaultMileageRate;
            item.Defaultperdiemrate = FetchByID(id)[0].Defaultperdiemrate;

            item.MarkOld();
            item.Save(UserName);
        }


    }
}
