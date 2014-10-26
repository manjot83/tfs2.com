using System;
using System.ComponentModel;
using SubSonic;
using System.Linq;
using System.Collections.Generic;

namespace TFS.OpCenter.Data
{
    public partial class NewspostController
    {

        public NewspostCollection FetchAllNotDeleted()
        {
            NewspostCollection coll = new NewspostCollection();
            Query qry = new Query(Newspost.Schema).WHERE(Newspost.Columns.Deleted, false);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public IEnumerable<Newspost> FetchUrgent()
        {
            return this.FetchAllNotDeleted().Where<Newspost>(post => post.Isurgent);
        }

	    public void Update(int Id,DateTime Createdon,int Categoryid,string Subject,string Content,bool Isurgent)
	    {
		    Newspost item = new Newspost();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;				
			item.Createdon = Createdon;
			item.Categoryid = Categoryid;				
			item.Subject = Subject;				
			item.Content = Content;				
			item.Isurgent = Isurgent;
				
	        item.Save(UserName);
	    }

        public void Insert(DateTime Createdon, string personName, int Categoryid, string Subject, string Content, bool Isurgent)
        {
            Newspost item = new Newspost();

            item.Createdon = Createdon;

            item.Personid = Person.FetchByUsername(personName).Id;

            item.Categoryid = Categoryid;

            item.Subject = Subject;

            item.Content = Content;

            item.Isurgent = Isurgent;

            item.Deleted = false;

            item.Save(UserName);
        }
    }
}
