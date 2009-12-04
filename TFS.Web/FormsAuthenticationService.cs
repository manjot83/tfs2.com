using System.Web.Security;
using TFS.Models;
using System.Net;
using System;
using System.IO;
using TFS.Models.Users;

namespace TFS.Web
{
    public class FormsAuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository userRepository;

        public FormsAuthenticationService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        private static string CleanUpUsername(string username)
        {
            string cleanedUsername = username;
            if (cleanedUsername.Contains("@"))
                cleanedUsername = cleanedUsername.Substring(0, cleanedUsername.IndexOf("@"));
            return cleanedUsername;
        }

        public bool Authenticate(string username, string password)
        {
            var cleanedUsername = CleanUpUsername(username);
            var user = userRepository.GetUser(cleanedUsername);
            if (user == null || user.Disabled)
                return false;
            var queryString = string.Format("?username={0}&password={1}", cleanedUsername, password);
            var request = WebRequest.Create(ConfigurationHelper.AuthenticationService + queryString);
            using (var response = request.GetResponse())
            {
                var responseText = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return responseText == "1";
            }
        }

        public bool ChangePassword(User user, string originalPassword, string newPassword)
        {
            var queryString = string.Format("?username={0}&originalPassword={1}&newPassword={2}", user.Username, originalPassword, newPassword);
            var request = WebRequest.Create(ConfigurationHelper.ChangePasswordService + queryString);
            using (var response = request.GetResponse())
            {
                var responseText = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return responseText == "1";
            }            
        }

        public int MinRequiredPasswordLength
        {
            get { return 8; }
        }

        public void LogOn(string username, bool persistent)
        {
            var cleanedUsername = CleanUpUsername(username);
            FormsAuthentication.SetAuthCookie(cleanedUsername, persistent);
        }

        public void LogOff()
        {
            FormsAuthentication.SignOut();
        }
    }
}
