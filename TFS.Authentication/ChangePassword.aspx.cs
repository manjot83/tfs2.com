using System;
using System.Configuration;
using System.DirectoryServices.AccountManagement;

namespace TFS.Authentication
{
    public partial class ChangePassword : System.Web.UI.Page
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
                var originalPassword = Request.Params["originalPassword"];
                if (string.IsNullOrEmpty(originalPassword)) originalPassword = "empty";
                var newPassword = Request.Params["newPassword"];
                if (string.IsNullOrEmpty(originalPassword)) newPassword = "empty";
                var context = new PrincipalContext(ContextType.Domain,
                                                   ConfigurationManager.AppSettings["serverName"],
                                                   ConfigurationManager.AppSettings["container"]);
                var user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username);
                if (user != null)
                {
                    user.ChangePassword(originalPassword, newPassword);
                    user.Save();
                    Response.Write(((int)ReturnCodes.Ok).ToString());
                }
                else
                {
                    Response.Write(((int)ReturnCodes.Failed).ToString());
                }
            }
            catch (PrincipalOperationException)
            {
                Response.Write(((int)ReturnCodes.Failed).ToString());
            }
            catch (PasswordException)
            {
                Response.Write(((int)ReturnCodes.Failed).ToString());
            }
            catch (Exception)
            {
                Response.Write(((int)ReturnCodes.Error).ToString());
            }
            Response.End();            
        }
    }
}
