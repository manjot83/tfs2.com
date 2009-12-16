namespace TFS.Web
{
    public interface IApplicationSettings
    {
        string AuthenticationService { get; }
        string ChangePasswordService { get; }
    }
}
