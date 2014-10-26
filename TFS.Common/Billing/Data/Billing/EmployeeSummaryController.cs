using System;
using System.Collections.Generic;
using System.Text;

namespace TFS.Intranet.Data.Billing
{
    public partial class EmployeeSummaryController
    {

        public EmployeeSummaryCollection FetchByPeriodAndUsername(Int32 PeriodID, String Username)
        {
            return new EmployeeSummaryCollection().Where(EmployeeSummary.Columns.Periodid, PeriodID).Where(EmployeeSummary.Columns.Username, Username).Load();
        }

    }
}
