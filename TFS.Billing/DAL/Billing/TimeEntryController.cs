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
    /// Controller class for TimeEntries
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TimeEntryController
    {
        // Preload our schema..
        TimeEntry thisSchemaLoad = new TimeEntry();
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
        public TimeEntryCollection FetchAll()
        {
            TimeEntryCollection coll = new TimeEntryCollection();
            Query qry = new Query(TimeEntry.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TimeEntryCollection FetchByID(object Id)
        {
            TimeEntryCollection coll = new TimeEntryCollection().Where("id", Id).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TimeEntryCollection FetchByQuery(Query qry)
        {
            TimeEntryCollection coll = new TimeEntryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (TimeEntry.Delete(Id) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (TimeEntry.Destroy(Id) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Timesheetid,int Day,string Timein,string Timeout,string Notes,bool IsDeleted,DateTime? CreatedOn,string CreatedBy,DateTime? ModifiedOn,string ModifiedBy)
	    {
		    TimeEntry item = new TimeEntry();
		    
            item.Timesheetid = Timesheetid;
            
            item.Day = Day;
            
            item.Timein = Timein;
            
            item.Timeout = Timeout;
            
            item.Notes = Notes;
            
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
	    public void Update(int Id,int Timesheetid,int Day,string Timein,string Timeout,string Notes,bool IsDeleted,DateTime? CreatedOn,string CreatedBy,DateTime? ModifiedOn,string ModifiedBy)
	    {
		    TimeEntry item = new TimeEntry();
		    
				item.Id = Id;
				
				item.Timesheetid = Timesheetid;
				
				item.Day = Day;
				
				item.Timein = Timein;
				
				item.Timeout = Timeout;
				
				item.Notes = Notes;
				
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

