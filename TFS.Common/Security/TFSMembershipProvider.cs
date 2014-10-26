using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using TFS.OpCenter.Data;
using System.Web;

namespace TFS.Security
{
    public class TFSMembershipProvider : MembershipProvider
    {
        /// <summary>
        /// The name of the application using the custom membership provider.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The name of the application using the custom membership provider.
        /// </returns>
        public override string ApplicationName
        {
            get;
            set;
        }

        #region Not Implemented

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        #endregion


        // <summary>
        /// Returns a MembershipUser object - in this case TFSMembershipUser
        /// </summary>
        /// <param name="username">Username to lookup (can be username or e-mail)</param>
        /// <param name="userIsOnline">This user is currently online</param>
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            if (username.Contains("@"))
                username = username.Substring(0, username.IndexOf("@"));
            Person person = Person.FetchByUsername(username);
            if (person == null || person.IsNew || !person.IsLoaded)
                return null;
            return new TFSMembershipUser(this.Name, person);
        }

        public override bool ValidateUser(string username, string password)
        {
            /// Shortcut to authenticate the super admin
            if (username.Equals("superadmin") && password.Equals("superadmin"))
                return true;

            //we first need to check if ther username (and we'll parse it to extract the username, but the e-mail is the key)
            //first clean up the account name
            if (username.Contains("@"))
                username = username.Substring(0, username.IndexOf("@"));
            if (GetUser(username, false) == null)
                return false;
            /// TODO move these to be global or app settings
            String path = "LDAP://DC=TFS2,DC=LOCAL";
            String domain = "TFS2";
            LdapAuthentication auth = new LdapAuthentication(path);
            bool authenticated = auth.IsAuthenticated(domain, username, password);
            return authenticated;
        }

        public IntPtr GetLoginToken(string username, string password)
        {
            String domain = "TFS2";
            return LdapAuthentication.GenerateLoginToken(username, password, domain);
        }

        /// <summary>
        /// Processes all the roles for the current principal
        /// </summary>
        public void ProcessRoles(System.Security.Principal.IPrincipal principal)
        {
            if (principal == null)
                return;
            if (principal.Identity.IsAuthenticated)
            {
                if (principal.IsInRole("DebugRole") || principal.Identity.Name.Equals("superadmin"))
                    return; /// The user has already gone through this code, no need to go through it again
                if (principal.Identity is FormsIdentity)
                {
                    FormsIdentity formsIdentity = (FormsIdentity)principal.Identity;
                    FormsAuthenticationTicket ticket = formsIdentity.Ticket;

                    // Get our roles
                    String username = ticket.Name;
                    string[] roles = new string[0];
                    try
                    {
                        roles = TFS.Security.ActiveDirectory.GroupObjectDataSource.GetUserRoles(username);
                    }
                    catch (Exception exception)
                    {
                        /// We don't want to fail if we can't get the roles
#if DEBUG
                        roles = new string[] { "DebugRole" };
                        /// Fill in default debugging roles?
#else
                        /// Unless we're in release mode
                        throw new Exception("Could not obtain user roles", exception);
#endif
                    }                    
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(formsIdentity, roles);
                }
            }            
        }
    }
}
