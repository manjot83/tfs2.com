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
    
    public partial class ArticlecategoryController
    {

        public ArticlecategoryCollection FetchAllNotDeleted()
        {
            ArticlecategoryCollection coll = new ArticlecategoryCollection();
            Query qry = new Query(Articlecategory.Schema).WHERE(Articlecategory.Columns.Deleted, false);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,string Description)
	    {
            this.Insert(Name, Description, false, DateTime.Now, null, null, null);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Name,string Description)
        {
            Articlecategory item = new Articlecategory();
            item.MarkOld();
            item.IsLoaded = true;

            item.Id = Id;
            item.Name = Name;
            item.Description = Description;

            item.Save(UserName);
	    }
    }
}
