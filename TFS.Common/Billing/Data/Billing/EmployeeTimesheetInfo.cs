using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Intranet.Data.Billing;

namespace TFS.Intranet.Data.Billing
{
    public partial class EmployeeTimesheetInfo
    {
        public RateGroup RateGroup
        {
            get { return RateGroup.FetchByID(this.Rategroupid); }
        }
    }
}
