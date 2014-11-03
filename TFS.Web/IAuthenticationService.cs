using TFS.Models;
using TFS.Models.Users;
namespace TFS.Web
{
    public interface IAuthenticationService
    {
        bool Authenticate(string username, string password);
        void LogOn(string username, bool persistent);
        void LogOff();

        int MinRequiredPasswordLength { get; }
    }
}
