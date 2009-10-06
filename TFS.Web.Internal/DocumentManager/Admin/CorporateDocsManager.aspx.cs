using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace TFS.Intranet.Web.DocumentManager.Admin
{
    public partial class CorporateDocsManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DocViewer.InitialPath = @"D:\FTPRoot\Docs";
            DocViewer.SecurityStart += new Cridion.Web.Controls.SecurityEventHandler(Security_Start);
            DocViewer.SecurityEnd += new Cridion.Web.Controls.SecurityEventHandler(Security_End);
            DocViewer.SecurityViolation += new Cridion.Web.Controls.SecurityEventHandler(DocViewer_SecurityViolation);
            DocViewer.AllowDelete = true;
            DocViewer.ShowCreateNewDirectory = true;
            DocViewer.ShowFileUploader = true;
        }

        void DocViewer_SecurityViolation(object sender, Cridion.Web.Controls.SecurityEventArgs e)
        {
            throw e.ThrownException;
        }

        protected TFS.Security.Impersonation imp = new TFS.Security.Impersonation();

        protected void Security_Start(object sender, Cridion.Web.Controls.SecurityEventArgs e)
        {
            imp.ImpersonateWithToken((IntPtr)Session["LoginToken"]);
        }

        protected void Security_End(object sender, Cridion.Web.Controls.SecurityEventArgs e)
        {
            imp.UnImpersonate();
        }
    }
}
