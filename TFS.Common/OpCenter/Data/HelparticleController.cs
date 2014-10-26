using System;
using System.ComponentModel;
using SubSonic;
using System.Linq;
using System.Collections.Generic;

namespace TFS.OpCenter.Data
{
    public partial class HelparticleController
    {

        public HelparticleCollection FetchAllNotDeleted()
        {
            HelparticleCollection coll = new HelparticleCollection();
            Query qry = new Query(Helparticle.Schema).WHERE(Helparticle.Columns.Deleted, false);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

     
    }
}
