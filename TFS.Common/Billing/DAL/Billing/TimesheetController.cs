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
    /// Controller class for Timesheets
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TimesheetController
    {
        // Preload our schema..
        Timesheet thisSchemaLoad = new Timesheet();
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

        public TimesheetCollection FetchAllByPeriodAccountId(int periodAccountId)
        {
            TimesheetCollection coll = new TimesheetCollection();
            Query qry = new Query(Timesheet.Schema);
            qry.WHERE(Timesheet.Columns.Periodaccountid, periodAccountId);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public TimesheetCollection FetchAll()
        {
            TimesheetCollection coll = new TimesheetCollection();
            Query qry = new Query(Timesheet.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TimesheetCollection FetchByID(object Id)
        {
            TimesheetCollection coll = new TimesheetCollection().Where("id", Id).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TimesheetCollection FetchByQuery(Query qry)
        {
            TimesheetCollection coll = new TimesheetCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Timesheet.Delete(Id) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Timesheet.Destroy(Id) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Username,int Periodaccountid,int Perdiemcount,bool IsDeleted,DateTime? CreatedOn,string CreatedBy,DateTime? ModifiedOn,string ModifiedBy,double Mileageclaimed,int Rategroupid)
	    {
		    Timesheet item = new Timesheet();
		    
            item.Username = Username;
            
            item.Periodaccountid = Periodaccountid;
            
            item.Perdiemcount = Perdiemcount;
            
            item.IsDeleted = IsDeleted;
            
            item.CreatedOn = CreatedOn;
            
            item.CreatedBy = CreatedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.Mileageclaimed = Mileageclaimed;

            item.Rategroupid = Rategroupid;
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void Update(int Id, string Username, int Periodaccountid, int Perdiemcount, bool IsDeleted, DateTime? CreatedOn, string CreatedBy, DateTime? ModifiedOn, string ModifiedBy, double Mileageclaimed, int Rategroupid)
	    {
		    Timesheet item = new Timesheet();
		    
				item.Id = Id;
				
				item.Username = Username;
				
				item.Periodaccountid = Periodaccountid;
				
				item.Perdiemcount = Perdiemcount;
				
				item.IsDeleted = IsDeleted;
				
				item.CreatedOn = CreatedOn;
				
				item.CreatedBy = CreatedBy;
				
				item.ModifiedOn = ModifiedOn;
				
				item.ModifiedBy = ModifiedBy;
				
				item.Mileageclaimed = Mileageclaimed;

                item.Rategroupid = Rategroupid;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }


        
    }

}

