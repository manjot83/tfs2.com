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
    /// Controller class for ExpenseEntries
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ExpenseEntryController
    {
        // Preload our schema..
        ExpenseEntry thisSchemaLoad = new ExpenseEntry();
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
        public ExpenseEntryCollection FetchAll()
        {
            ExpenseEntryCollection coll = new ExpenseEntryCollection();
            Query qry = new Query(ExpenseEntry.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ExpenseEntryCollection FetchByID(object Id)
        {
            ExpenseEntryCollection coll = new ExpenseEntryCollection().Where("id", Id).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ExpenseEntryCollection FetchByQuery(Query qry)
        {
            ExpenseEntryCollection coll = new ExpenseEntryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (ExpenseEntry.Delete(Id) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (ExpenseEntry.Destroy(Id) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Timesheetid,DateTime Expensedate,double Cost,string Expensedesc,bool IsDeleted,DateTime? CreatedOn,string CreatedBy,DateTime? ModifiedOn,string ModifiedBy)
	    {
		    ExpenseEntry item = new ExpenseEntry();
		    
            item.Timesheetid = Timesheetid;
            
            item.Expensedate = Expensedate;
            
            item.Cost = Cost;
            
            item.Expensedesc = Expensedesc;
            
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
        [DataObjectMethod(DataObjectMethodType.Update, false)]
	    public void Update(int Id,int Timesheetid,DateTime Expensedate,double Cost,string Expensedesc,bool IsDeleted,DateTime? CreatedOn,string CreatedBy,DateTime? ModifiedOn,string ModifiedBy)
	    {
		    ExpenseEntry item = new ExpenseEntry();
		    
				item.Id = Id;
				
				item.Timesheetid = Timesheetid;
				
				item.Expensedate = Expensedate;
				
				item.Cost = Cost;
				
				item.Expensedesc = Expensedesc;
				
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

