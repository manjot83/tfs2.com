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
    /// Controller class for helparticles
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class HelparticleController
    {
        // Preload our schema..
        Helparticle thisSchemaLoad = new Helparticle();
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
        public HelparticleCollection FetchAll()
        {
            HelparticleCollection coll = new HelparticleCollection();
            Query qry = new Query(Helparticle.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public HelparticleCollection FetchByID(object Id)
        {
            HelparticleCollection coll = new HelparticleCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public HelparticleCollection FetchByQuery(Query qry)
        {
            HelparticleCollection coll = new HelparticleCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Helparticle.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Helparticle.Destroy(Id) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void Insert(string Subject, string Content, DateTime Createdon)
        {
            Insert(Subject, Content, false, Createdon, DateTime.Now, "", "");
        }
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Subject,string Content,bool? Deleted,DateTime Createdon,DateTime? Modifiedon,string Createdby,string Modifiedby)
	    {
		    Helparticle item = new Helparticle();
		    
            item.Subject = Subject;
            
            item.Content = Content;
            
            item.Deleted = Deleted;
            
            item.Createdon = Createdon;
            
            item.Modifiedon = Modifiedon;
            
            item.Createdby = Createdby;
            
            item.Modifiedby = Modifiedby;
            
	    
		    item.Save(UserName);
	    }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Update(int Id, string Subject, string Content, DateTime Createdon)
        {
            var original = FetchByID(Id)[0];
            Update(Id, Subject, Content, original.Deleted, Createdon, null, original.Createdby, null);
        }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Subject,string Content,bool? Deleted,DateTime Createdon,DateTime? Modifiedon,string Createdby,string Modifiedby)
	    {
		    Helparticle item = new Helparticle();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Subject = Subject;
				
			item.Content = Content;
				
			item.Deleted = Deleted;
				
			item.Createdon = Createdon;
				
			item.Modifiedon = Modifiedon;
				
			item.Createdby = Createdby;
				
			item.Modifiedby = Modifiedby;
				
	        item.Save(UserName);
	    }
    }
}
