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
namespace TFS.OpCenter.Data
{
    /// <summary>
    /// Controller class for availability
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AvailabilityController
    {
        // Preload our schema..
        Availability thisSchemaLoad = new Availability();
        private string userName = String.Empty;
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
        public AvailabilityCollection FetchAll()
        {
            AvailabilityCollection coll = new AvailabilityCollection();
            Query qry = new Query(Availability.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AvailabilityCollection FetchByID(object Id)
        {
            AvailabilityCollection coll = new AvailabilityCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AvailabilityCollection FetchByQuery(Query qry)
        {
            AvailabilityCollection coll = new AvailabilityCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Availability.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Availability.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Personid,int Month,int Year,int Day,bool Isavailable)
	    {
		    Availability item = new Availability();
		    
            item.Personid = Personid;
            
            item.Month = Month;
            
            item.Year = Year;
            
            item.Day = Day;
            
            item.Isavailable = Isavailable;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int Personid,int Month,int Year,int Day,bool Isavailable)
	    {
		    Availability item = new Availability();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Personid = Personid;
				
			item.Month = Month;
				
			item.Year = Year;
				
			item.Day = Day;
				
			item.Isavailable = Isavailable;
				
	        item.Save(UserName);
	    }
    }
}
