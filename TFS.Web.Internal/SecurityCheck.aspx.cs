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
using System.Security.Principal;
using System.Runtime.InteropServices;

public partial class SecurityCheck : System.Web.UI.Page
{
    [DllImport("advapi32.dll", EntryPoint = "LogonUser")]
    private static extern bool LogonUser(
               string lpszUsername,
               string lpszDomain,
               string lpszPassword,
               int dwLogonType,
               int dwLogonProvider,
               ref IntPtr phToken);


    public const int LOGON32_LOGON_INTERACTIVE = 2;
    public const long LOGON32_LOGON_NETWORK = 3;

    public const int LOGON32_PROVIDER_DEFAULT = 0;


    protected void Page_Load(object sender, EventArgs e)
    {

        /*IntPtr token = new IntPtr(0);
        token = IntPtr.Zero;


        // Call LogonUser to obtain a handle to an access token.
        bool returnValue = LogonUser("j.daigle", "TFS2", "no peeking",
                                       (int)LOGON32_LOGON_NETWORK,
                                       (int)LOGON32_PROVIDER_DEFAULT,
                                       ref token);

        WindowsIdentity newId = new WindowsIdentity(token);
        WindowsImpersonationContext impersonatedUser = newId.Impersonate();*/

        label1.Text = "HTTP Context: " + HttpContext.Current.User.Identity.Name;
        label2.Text = "THREAD: " + System.Threading.Thread.CurrentPrincipal.Identity.Name;
        label3.Text = "Windows ID:  " + System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        TFS.Security.Impersonation imp = new TFS.Security.Impersonation();
        imp.ImpersonateWithProtocolTransition(HttpContext.Current.User.Identity.Name);        

        label4.Text = "Windows ID Now Impersonating " + System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        imp.UnImpersonate();

        imp = new TFS.Security.Impersonation();
        imp.ImpersonateWithProtocolTransition(HttpContext.Current.User.Identity.Name);

        label5.Text = "Windows ID Now Impersonating " + System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        imp.UnImpersonate();

        imp = new TFS.Security.Impersonation();
        imp.ImpersonateWithProtocolTransition(HttpContext.Current.User.Identity.Name);

        label5.Text = "Windows ID Now Impersonating " + System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        imp.UnImpersonate();

    }
}
