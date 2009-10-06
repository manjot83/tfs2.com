using System;
using System.Data;
using System.Configuration;
using System.DirectoryServices;
using System.Runtime.InteropServices;
using System.Security.Principal;


namespace TFS.Security
{

    /// <summary>
    /// Summary description for FormsAuth
    /// </summary>
    public class LdapAuthentication
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

        private String path;

        public LdapAuthentication(String path)
        {
            this.path = path;
        }

        public Boolean IsAuthenticated(String domain, String user, String pwd)
        {

            String domainAndUser = domain + "\\" + user;
            DirectoryEntry entry = new DirectoryEntry(path, domainAndUser, pwd);
            try
            {
                Object obj = entry.NativeObject;
                DirectorySearcher searcher = new DirectorySearcher(entry);
                searcher.Filter = "(SAMAccountName=" + user + ")";
                searcher.PropertiesToLoad.Add("cn");
                SearchResult result = searcher.FindOne();
                if (result == null)
                    return false;
                path = result.Path;

            }
            catch (Exception)
            {
                //throw new Exception("Error Authenticating: " + domainAndUser + " because: " + e);
                return false;
            }

            return true;
        }

        public static IntPtr GenerateLoginToken(string username,
                                             string password,
                                             string domain)
        {
            IntPtr token = new IntPtr(0);
            token = IntPtr.Zero;


            // Call LogonUser to obtain a handle to an access token.
            bool returnValue = LogonUser(username, domain, password,
                                           (int)LOGON32_LOGON_NETWORK,
                                           (int)LOGON32_PROVIDER_DEFAULT,
                                           ref token);
            if (false == returnValue)
            {
                int ret = Marshal.GetLastWin32Error();
                string strErr = String.Format("LogonUser failed with error code : {0}", ret);
                throw new ApplicationException(strErr, null);
            }

            return token;
        }


    }
}