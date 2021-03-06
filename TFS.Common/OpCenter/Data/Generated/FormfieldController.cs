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
    /// Controller class for formfields
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class FormfieldController
    {
        // Preload our schema..
        Formfield thisSchemaLoad = new Formfield();
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
        public FormfieldCollection FetchAll()
        {
            FormfieldCollection coll = new FormfieldCollection();
            Query qry = new Query(Formfield.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public FormfieldCollection FetchByID(object Id)
        {
            FormfieldCollection coll = new FormfieldCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public FormfieldCollection FetchByQuery(Query qry)
        {
            FormfieldCollection coll = new FormfieldCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Formfield.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Formfield.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Formid,string Name,string Metadata,bool? Deleted,DateTime? Createdon,DateTime? Modifiedon,string Createdby,string Modifiedby)
	    {
		    Formfield item = new Formfield();
		    
            item.Formid = Formid;
            
            item.Name = Name;
            
            item.Metadata = Metadata;
            
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
	    public void Update(int Id,int Formid,string Name,string Metadata,bool? Deleted,DateTime? Createdon,DateTime? Modifiedon,string Createdby,string Modifiedby)
	    {
		    Formfield item = new Formfield();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Formid = Formid;
				
			item.Name = Name;
				
			item.Metadata = Metadata;
				
			item.Deleted = Deleted;
				
			item.Createdon = Createdon;
				
			item.Modifiedon = Modifiedon;
				
			item.Createdby = Createdby;
				
			item.Modifiedby = Modifiedby;
				
	        item.Save(UserName);
	    }
    }
}
