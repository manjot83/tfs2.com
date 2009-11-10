using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TFS.Models.Reports
{
    public interface ICsvReport
    {
        DataTable ConvertToTable();
    }
}
