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
    /// Controller class for BillingRates
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class BillingRateController
    {
        // Preload our schema..
        BillingRate thisSchemaLoad = new BillingRate();
        private string userName = string.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}

					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}

				}

				return userName;
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public BillingRateCollection FetchAll()
        {
            BillingRateCollection coll = new BillingRateCollection();
            Query qry = new Query(BillingRate.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public BillingRateCollection FetchByID(object Id)
        {
            BillingRateCollection coll = new BillingRateCollection().Where("id", Id).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public BillingRateCollection FetchByQuery(Query qry)
        {
            BillingRateCollection coll = new BillingRateCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (BillingRate.Delete(Id) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (BillingRate.Destroy(Id) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Periodaccountid,int Groupid,double Rate,bool IsDeleted,DateTime? CreatedOn,string CreatedBy,DateTime? ModifiedOn,string ModifiedBy)
	    {
		    BillingRate item = new BillingRate();
		    
            item.Periodaccountid = Periodaccountid;
            
            item.Groupid = Groupid;
            
            item.Rate = Rate;
            
            item.IsDeleted = IsDeleted;
            
            item.CreatedOn = CreatedOn;
            
            item.CreatedBy = CreatedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.ModifiedBy = ModifiedBy;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int Periodaccountid,int Groupid,double Rate,bool IsDeleted,DateTime? CreatedOn,string CreatedBy,DateTime? ModifiedOn,string ModifiedBy)
	    {
		    BillingRate item = new BillingRate();
		    
				item.Id = Id;
				
				item.Periodaccountid = Periodaccountid;
				
				item.Groupid = Groupid;
				
				item.Rate = Rate;
				
				item.IsDeleted = IsDeleted;
				
				item.CreatedOn = CreatedOn;
				
				item.CreatedBy = CreatedBy;
				
				item.ModifiedOn = ModifiedOn;
				
				item.ModifiedBy = ModifiedBy;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

