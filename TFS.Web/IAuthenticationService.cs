using TFS.Models;
namespace TFS.Web
{
    public interface IAuthenticationService
    {
        bool Authenticate(string username, string password);
        void LogOn(string username, bool persistent);
        void LogOff();
        IUserRepository UserRepository { get; }

        bool ChangePassword(User user, string originalPassword, string newPassword);
        int MinRequiredPasswordLength { get; }
    }
}
