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
    /// Controller class for BillingAccounts
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class BillingAccountController
    {
        // Preload our schema..
        BillingAccount thisSchemaLoad = new BillingAccount();
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
        public BillingAccountCollection FetchAll()
        {
            BillingAccountCollection coll = new BillingAccountCollection();
            Query qry = new Query(BillingAccount.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public BillingAccountCollection FetchByID(object Id)
        {
            BillingAccountCollection coll = new BillingAccountCollection().Where("id", Id).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public BillingAccountCollection FetchByQuery(Query qry)
        {
            BillingAccountCollection coll = new BillingAccountCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (BillingAccount.Delete(Id) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (BillingAccount.Destroy(Id) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,double Defaultperdiemrate,bool IsDeleted,DateTime? CreatedOn,string CreatedBy,DateTime? ModifiedOn,string ModifiedBy,double Defaultmileagerate)
	    {
		    BillingAccount item = new BillingAccount();
		    
            item.Name = Name;
            
            item.Defaultperdiemrate = Defaultperdiemrate;
            
            item.IsDeleted = IsDeleted;
            
            item.CreatedOn = CreatedOn;
            
            item.CreatedBy = CreatedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.Defaultmileagerate = Defaultmileagerate;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Name,double Defaultperdiemrate,bool IsDeleted,DateTime? CreatedOn,string CreatedBy,DateTime? ModifiedOn,string ModifiedBy,double Defaultmileagerate)
	    {
		    BillingAccount item = new BillingAccount();
		    
				item.Id = Id;
				
				item.Name = Name;
				
				item.Defaultperdiemrate = Defaultperdiemrate;
				
				item.IsDeleted = IsDeleted;
				
				item.CreatedOn = CreatedOn;
				
				item.CreatedBy = CreatedBy;
				
				item.ModifiedOn = ModifiedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.Defaultmileagerate = Defaultmileagerate;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

