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
    public partial class ExternallinkController
    {
        public ExternallinkCollection FetchAllNotDeleted()
        {
            ExternallinkCollection coll = new ExternallinkCollection();
            Query qry = new Query(Externallink.Schema).WHERE(Externallink.Columns.Deleted, false);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,string Navurl)
	    {
            this.Insert(Name, Navurl, false, DateTime.Now, null, null, null);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Name,string Navurl)
	    {
            Externallink item = new Externallink();
            item.MarkOld();
            item.IsLoaded = true;

            item.Id = Id;
            item.Name = Name;
            item.Navurl = Navurl;

            item.Save(UserName);
	    }
    }
}
