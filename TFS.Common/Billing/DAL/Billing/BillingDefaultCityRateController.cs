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
    /// Controller class for BillingDefaultCityRates
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class BillingDefaultCityRateController
    {
        // Preload our schema..
        BillingDefaultCityRate thisSchemaLoad = new BillingDefaultCityRate();
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
        public BillingDefaultCityRateCollection FetchAllActiveByAccountId(int accountId)
        {
            BillingDefaultCityRateCollection coll = new BillingDefaultCityRateCollection();
            Query qry = new Query(BillingDefaultCityRate.Schema);
            qry.WHERE(BillingDefaultCityRate.Columns.IsDeleted, false)
                .WHERE(BillingDefaultCityRate.Columns.AccountId, accountId);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public BillingDefaultCityRateCollection FetchAllActive()
        {
            BillingDefaultCityRateCollection coll = new BillingDefaultCityRateCollection();
            Query qry = new Query(BillingDefaultCityRate.Schema);
            qry.WHERE(BillingDefaultCityRate.Columns.IsDeleted, false);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public BillingDefaultCityRateCollection FetchAll()
        {
            BillingDefaultCityRateCollection coll = new BillingDefaultCityRateCollection();
            Query qry = new Query(BillingDefaultCityRate.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public BillingDefaultCityRateCollection FetchByID(object Id)
        {
            BillingDefaultCityRateCollection coll = new BillingDefaultCityRateCollection().Where("id", Id).Load();
            return coll;
        }


        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public BillingDefaultCityRateCollection FetchByQuery(Query qry)
        {
            BillingDefaultCityRateCollection coll = new BillingDefaultCityRateCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (BillingDefaultCityRate.Delete(Id) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (BillingDefaultCityRate.Destroy(Id) == 1);
        }


        /// <summary>
        /// Inserts a record, can be used with the Object Data Source
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void Insert(int accountId, double defaultPerDiemRate, string city)
        {
            BillingDefaultCityRate item = new BillingDefaultCityRate();

            item.AccountId = accountId;

            item.City = city;

            item.DefaultPerDiemRate = defaultPerDiemRate;

            item.Save(UserName);
        }

        public BillingDefaultCityRate InsertObjReturn(int accountId, double defaultPerDiemRate, string city)
        {
            var item = new BillingDefaultCityRate();

            item.AccountId = accountId;

            item.City = city;

            item.DefaultPerDiemRate = defaultPerDiemRate;

            item.Save(UserName);

            return item;
        }

        /// <summary>
        /// Updates a record, can be used with the Object Data Source
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void Update(int id, int accountid, string city, double defaultPerDiemRate)
        {
            BillingDefaultCityRate item = new BillingDefaultCityRate();
            item.MarkOld();

            item.Id = id;

            item.City = city;

            item.DefaultPerDiemRate = defaultPerDiemRate;

            item.AccountId = accountid;

            item.Save(UserName);
        }

    }

}

