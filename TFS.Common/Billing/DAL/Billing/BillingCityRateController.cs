using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using SubSonic;
using SubSonic.Utilities;

namespace TFS.Intranet.Data.Billing
{
    /// <summary>
    /// Controller class for BillingCityRates
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class BillingCityRateController
    {
        // Preload our schema..
        BillingCityRate thisSchemaLoad = new BillingCityRate();
        private string userName = string.Empty;
        protected string UserName
        {
            get
            {
                if (userName.Length == 0)
                {
                    if (System.Web.HttpContext.Current != null)
                    {
                        userName = System.Web.HttpContext.Current.User.Identity.Name;
                    }

                    else
                    {
                        userName = System.Threading.Thread.CurrentPrincipal.Identity.Name;
                    }

                }

                return userName;
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public BillingCityRateCollection FetchAllActive()
        {
            BillingCityRateCollection coll = new BillingCityRateCollection();
            Query qry = new Query(BillingCityRate.Schema);
            qry.WHERE(BillingCityRate.Columns.IsDeleted, false);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public BillingCityRateCollection FetchAll()
        {
            BillingCityRateCollection coll = new BillingCityRateCollection();
            Query qry = new Query(BillingCityRate.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public BillingCityRateCollection FetchByID(object Id)
        {
            BillingCityRateCollection coll = new BillingCityRateCollection().Where("id", Id).Load();
            return coll;
        }


        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public BillingCityRateCollection FetchByQuery(Query qry)
        {
            BillingCityRateCollection coll = new BillingCityRateCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (BillingCityRate.Delete(Id) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (BillingCityRate.Destroy(Id) == 1);
        }


        /// <summary>
        /// Inserts a record, can be used with the Object Data Source
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void Insert(int defaultCityRateId, int periodAccountId, double rerDiemRate)
        {
            BillingCityRate item = new BillingCityRate();

            item.Periodaccountid = periodAccountId;

            item.PerDiemRate = rerDiemRate;

            item.DefaultCityRateId = defaultCityRateId;

            item.Save(UserName);
        }


        /// <summary>
        /// Updates a record, can be used with the Object Data Source
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void Update(int id, int defaultCityRateId, int periodAccountId, double rerDiemRate)
        {
            BillingCityRate item = new BillingCityRate();
            item.MarkOld();

            item.Id = id;

            item.Periodaccountid = periodAccountId;

            item.PerDiemRate = rerDiemRate;

            item.DefaultCityRateId = defaultCityRateId;

            item.Save(UserName);
        }

    }

}

