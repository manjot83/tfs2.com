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
    /// Controller class for externallinks
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ExternallinkController
    {
        // Preload our schema..
        Externallink thisSchemaLoad = new Externallink();
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
        public ExternallinkCollection FetchAll()
        {
            ExternallinkCollection coll = new ExternallinkCollection();
            Query qry = new Query(Externallink.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ExternallinkCollection FetchByID(object Id)
        {
            ExternallinkCollection coll = new ExternallinkCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ExternallinkCollection FetchByQuery(Query qry)
        {
            ExternallinkCollection coll = new ExternallinkCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Externallink.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Externallink.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,string Navurl,bool? Deleted,DateTime? Createdon,DateTime? Modifiedon,string Createdby,string Modifiedby)
	    {
		    Externallink item = new Externallink();
		    
            item.Name = Name;
            
            item.Navurl = Navurl;
            
            item.Deleted = Deleted;
            
            item.Createdon = Createdon;
            
            item.Modifiedon = Modifiedon;
            
            item.Createdby = Createdby;
            
            item.Modifiedby = Modifiedby;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Name,string Navurl,bool? Deleted,DateTime? Createdon,DateTime? Modifiedon,string Createdby,string Modifiedby)
	    {
		    Externallink item = new Externallink();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Name = Name;
				
			item.Navurl = Navurl;
				
			item.Deleted = Deleted;
				
			item.Createdon = Createdon;
				
			item.Modifiedon = Modifiedon;
				
			item.Createdby = Createdby;
				
			item.Modifiedby = Modifiedby;
				
	        item.Save(UserName);
	    }
    }
}
