using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace TFS.Intranet.Web.DocumentManager
{
    public partial class Schedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DocViewer.InitialPath = @"D:\FTPRoot\Docs\Schedule";
            DocViewer.AllowDelete = false;
            DocViewer.ShowFileUploader = false;
            DocViewer.ShowCreateNewDirectory = false;
        }
    }
}
