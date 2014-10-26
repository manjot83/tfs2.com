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
    /// Controller class for persons
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PersonController
    {
        // Preload our schema..
        Person thisSchemaLoad = new Person();
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
        public PersonCollection FetchAll()
        {
            PersonCollection coll = new PersonCollection();
            Query qry = new Query(Person.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PersonCollection FetchByID(object Id)
        {
            PersonCollection coll = new PersonCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PersonCollection FetchByQuery(Query qry)
        {
            PersonCollection coll = new PersonCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Person.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Person.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Firstname,string Lastname,string Email,string Username,string Displayname,bool? Deleted,DateTime? Createdon,DateTime? Modifiedon,string Createdby,string Modifiedby)
	    {
		    Person item = new Person();
		    
            item.Firstname = Firstname;
            
            item.Lastname = Lastname;
            
            item.Email = Email;
            
            item.Username = Username;
            
            item.Displayname = Displayname;
            
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
	    public void Update(int Id,string Firstname,string Lastname,string Email,string Username,string Displayname,bool? Deleted,DateTime? Createdon,DateTime? Modifiedon,string Createdby,string Modifiedby)
	    {
		    Person item = new Person();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Firstname = Firstname;
				
			item.Lastname = Lastname;
				
			item.Email = Email;
				
			item.Username = Username;
				
			item.Displayname = Displayname;
				
			item.Deleted = Deleted;
				
			item.Createdon = Createdon;
				
			item.Modifiedon = Modifiedon;
				
			item.Createdby = Createdby;
				
			item.Modifiedby = Modifiedby;
				
	        item.Save(UserName);
	    }
    }
}
