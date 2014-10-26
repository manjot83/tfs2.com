using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.OpCenter.Data
{
    public partial class Formrecord
    {
        /// <summary>
        /// Creates a new Formrecord with the required values and appropriate defaults
        /// </summary>
        /// <returns></returns>
        public static Formrecord CreateNew(int fileid, int fieldid)
        {
            Formrecord record = new Formrecord();
            record.Fieldid = fieldid;
            record.Fileid = fileid;
            record.Deleted = false;
            record.Save(Utility.GetActiveUsername());
            return record;
        }

    }
}
