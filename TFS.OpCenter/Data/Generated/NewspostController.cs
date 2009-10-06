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
    /// Controller class for newsposts
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class NewspostController
    {
        // Preload our schema..
        Newspost thisSchemaLoad = new Newspost();
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
        public NewspostCollection FetchAll()
        {
            NewspostCollection coll = new NewspostCollection();
            Query qry = new Query(Newspost.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public NewspostCollection FetchByID(object Id)
        {
            NewspostCollection coll = new NewspostCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public NewspostCollection FetchByQuery(Query qry)
        {
            NewspostCollection coll = new NewspostCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Newspost.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Newspost.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Personid,int Categoryid,string Subject,string Content,bool Isurgent,bool? Deleted,DateTime Createdon,DateTime? Modifiedon,string Createdby,string Modifiedby)
	    {
		    Newspost item = new Newspost();
		    
            item.Personid = Personid;
            
            item.Categoryid = Categoryid;
            
            item.Subject = Subject;
            
            item.Content = Content;
            
            item.Isurgent = Isurgent;
            
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
	    public void Update(int Id,int Personid,int Categoryid,string Subject,string Content,bool Isurgent,bool? Deleted,DateTime Createdon,DateTime? Modifiedon,string Createdby,string Modifiedby)
	    {
		    Newspost item = new Newspost();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Personid = Personid;
				
			item.Categoryid = Categoryid;
				
			item.Subject = Subject;
				
			item.Content = Content;
				
			item.Isurgent = Isurgent;
				
			item.Deleted = Deleted;
				
			item.Createdon = Createdon;
				
			item.Modifiedon = Modifiedon;
				
			item.Createdby = Createdby;
				
			item.Modifiedby = Modifiedby;
				
	        item.Save(UserName);
	    }
    }
}
