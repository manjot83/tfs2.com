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
    /// Controller class for BillingPeriodAccounts
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class BillingPeriodAccountController
    {
        // Preload our schema..
        BillingPeriodAccount thisSchemaLoad = new BillingPeriodAccount();
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
        public BillingPeriodAccountCollection FetchAll()
        {
            BillingPeriodAccountCollection coll = new BillingPeriodAccountCollection();
            Query qry = new Query(BillingPeriodAccount.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public BillingPeriodAccountCollection FetchByID(object Id)
        {
            BillingPeriodAccountCollection coll = new BillingPeriodAccountCollection().Where("id", Id).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public BillingPeriodAccountCollection FetchByQuery(Query qry)
        {
            BillingPeriodAccountCollection coll = new BillingPeriodAccountCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (BillingPeriodAccount.Delete(Id) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (BillingPeriodAccount.Destroy(Id) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Periodid,int Accountid,double Perdiemrate,bool IsDeleted,DateTime? CreatedOn,string CreatedBy,DateTime? ModifiedOn,string ModifiedBy,double Mileagerate)
	    {
		    BillingPeriodAccount item = new BillingPeriodAccount();
		    
            item.Periodid = Periodid;
            
            item.Accountid = Accountid;
            
            item.Perdiemrate = Perdiemrate;
            
            item.IsDeleted = IsDeleted;
            
            item.CreatedOn = CreatedOn;
            
            item.CreatedBy = CreatedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.Mileagerate = Mileagerate;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int Periodid,int Accountid,double Perdiemrate,bool IsDeleted,DateTime? CreatedOn,string CreatedBy,DateTime? ModifiedOn,string ModifiedBy,double Mileagerate)
	    {
		    BillingPeriodAccount item = new BillingPeriodAccount();
		    
				item.Id = Id;
				
				item.Periodid = Periodid;
				
				item.Accountid = Accountid;
				
				item.Perdiemrate = Perdiemrate;
				
				item.IsDeleted = IsDeleted;
				
				item.CreatedOn = CreatedOn;
				
				item.CreatedBy = CreatedBy;
				
				item.ModifiedOn = ModifiedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.Mileagerate = Mileagerate;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

