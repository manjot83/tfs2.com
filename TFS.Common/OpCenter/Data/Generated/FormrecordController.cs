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
    /// Controller class for formrecords
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class FormrecordController
    {
        // Preload our schema..
        Formrecord thisSchemaLoad = new Formrecord();
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
        public FormrecordCollection FetchAll()
        {
            FormrecordCollection coll = new FormrecordCollection();
            Query qry = new Query(Formrecord.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public FormrecordCollection FetchByID(object Id)
        {
            FormrecordCollection coll = new FormrecordCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public FormrecordCollection FetchByQuery(Query qry)
        {
            FormrecordCollection coll = new FormrecordCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Formrecord.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Formrecord.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Fileid,int Fieldid,int? Codeid,string Storedvalue,bool? Deleted,DateTime? Createdon,DateTime? Modifiedon,string Createdby,string Modifiedby)
	    {
		    Formrecord item = new Formrecord();
		    
            item.Fileid = Fileid;
            
            item.Fieldid = Fieldid;
            
            item.Codeid = Codeid;
            
            item.Storedvalue = Storedvalue;
            
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
	    public void Update(int Id,int Fileid,int Fieldid,int? Codeid,string Storedvalue,bool? Deleted,DateTime? Createdon,DateTime? Modifiedon,string Createdby,string Modifiedby)
	    {
		    Formrecord item = new Formrecord();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Fileid = Fileid;
				
			item.Fieldid = Fieldid;
				
			item.Codeid = Codeid;
				
			item.Storedvalue = Storedvalue;
				
			item.Deleted = Deleted;
				
			item.Createdon = Createdon;
				
			item.Modifiedon = Modifiedon;
				
			item.Createdby = Createdby;
				
			item.Modifiedby = Modifiedby;
				
	        item.Save(UserName);
	    }
    }
}
