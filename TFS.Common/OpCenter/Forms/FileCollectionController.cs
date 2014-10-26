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
