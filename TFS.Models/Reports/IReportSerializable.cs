using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.Models.Reports
{
    public interface IReportSerializable
    {
        string StylesheetResourceName { get; }
    }
}
