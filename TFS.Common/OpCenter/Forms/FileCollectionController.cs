using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace TFS.OpCenter.Forms
{
    /// <summary>
    /// Provides an web based object data source for the FileCollection
    /// </summary>
    [System.ComponentModel.DataObject]
    public class FileCollectionController
    {

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public DataTable FetchAll(int formId)
        {
            return new ViewableFileCollection(formId).LoadAll().ToDataTable();
        }


        //does not change initial display in SRFListing.aspx or FCIFListing.aspx
        //not sure why, done trying for now - Brian Ogden 10-15-2015
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public DataTable FetchAllOrderedByCreatedOn(int formId)
        {
            var dt = new ViewableFileCollection(formId).LoadAll().ToDataTable();
            dt.DefaultView.Sort = "createdon desc";
            return dt.DefaultView.ToTable();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DataTable FetchAll(int formId, string orderfield, bool orderdesc)
        {
            ViewableFileCollection orderedFiles = new ViewableFileCollection(formId);
            orderedFiles.LoadAll();
           // if (!orderdesc)
           //     orderedFiles.AddRange(FileCollection.LoadAll(formId).OrderBy(file => file.GetStoredValue(orderfield)));
           // else
           //     orderedFiles.AddRange(FileCollection.LoadAll(formId).OrderByDescending(file => file.GetStoredValue(orderfield)));
            return orderedFiles.ToDataTable();
        }
        
    }
}
