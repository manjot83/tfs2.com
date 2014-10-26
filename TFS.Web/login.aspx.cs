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
using TFS.Security;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        String userP = Request.Params["username"];
        String passP = Request.Params["password"];

        if (userP != null && passP != null && !userP.Equals("") && !passP.Equals(""))
            ProcessLogin(userP, passP);
    }

    private void ProcessLogin(String username, String password)
    {             
        try
        {
            if (Membership.ValidateUser(username, password))
            {
                Session["LoginToken"] = (Membership.Provider as TFSMembershipProvider).GetLoginToken(username, password);                
                FormsAuthentication.RedirectFromLoginPage(username, false);                
            }
            else
            {
                lblResults.Text = "Invalid Credentials: Please try again";
            }
        }
        catch (Exception exception)
        {
            lblResults.Text = "Login Failed: " + exception + " | Please try again";
        }
    }

    protected void HandleLoginClicked(object sender, EventArgs e)
    {
        ProcessLogin(UserName.Text, UserPass.Text);
    }
}
