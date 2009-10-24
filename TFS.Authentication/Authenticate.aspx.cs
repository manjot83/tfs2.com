using System;
using System.Configuration;
using System.DirectoryServices.AccountManagement;

namespace TFS.Authentication
{
    public partial class Authenticate : System.Web.UI.Page
    {
        enum ReturnCodes : int
        {
            Ok = 1,
            Failed = 2,
            Error = 3,
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var username = Request.Params["username"];
                if (string.IsNullOrEmpty(username)) username = "empty";    
                var password = Request.Params["password"];
                if (string.IsNullOrEmpty(password)) password = "empty";
                var context = new PrincipalContext(ContextType.Domain,
                                                   ConfigurationManager.AppSettings["serverName"],
                                                   ConfigurationManager.AppSettings["container"]);
                var result = context.ValidateCredentials(username, password) ? (int)ReturnCodes.Ok : (int)ReturnCodes.Failed;
                Response.Write(result.ToString());
            }
            catch (Exception)
            {
                Response.Write(((int)ReturnCodes.Error).ToString());
            }
            Response.End();
        }
    }
}
