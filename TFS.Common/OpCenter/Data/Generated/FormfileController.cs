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
    /// Controller class for formfiles
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class FormfileController
    {
        // Preload our schema..
        Formfile thisSchemaLoad = new Formfile();
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
        public FormfileCollection FetchAll()
        {
            FormfileCollection coll = new FormfileCollection();
            Query qry = new Query(Formfile.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public FormfileCollection FetchByID(object Id)
        {
            FormfileCollection coll = new FormfileCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public FormfileCollection FetchByQuery(Query qry)
        {
            FormfileCollection coll = new FormfileCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Formfile.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Formfile.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Formid,int? Personid,bool? Deleted,DateTime? Createdon,DateTime? Modifiedon,string Createdby,string Modifiedby)
	    {
		    Formfile item = new Formfile();
		    
            item.Formid = Formid;
            
            item.Personid = Personid;
            
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
	    public void Update(int Id,int Formid,int? Personid,bool? Deleted,DateTime? Createdon,DateTime? Modifiedon,string Createdby,string Modifiedby)
	    {
		    Formfile item = new Formfile();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Formid = Formid;
				
			item.Personid = Personid;
				
			item.Deleted = Deleted;
				
			item.Createdon = Createdon;
				
			item.Modifiedon = Modifiedon;
				
			item.Createdby = Createdby;
				
			item.Modifiedby = Modifiedby;
				
	        item.Save(UserName);
	    }
    }
}
