using System.Web.Security;
using TFS.Models;

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
            return userRepository.AuthenticateUser(cleanedUsername, password);
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
