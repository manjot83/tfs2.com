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

namespace TFS.Intranet.Data.Billing{
    public partial class SPs{
        
        /// <summary>
        /// Creates an object wrapper for the sp_FixPeriodBillingRates Procedure
        /// </summary>
        public static StoredProcedure SpFixPeriodBillingRates(int? PeriodID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_FixPeriodBillingRates" , DataService.GetInstance("Billing"));
        	
            sp.Command.AddParameter("@PeriodID", PeriodID,DbType.Int32);
        	    
            return sp;
        }

        
    }

    
}

