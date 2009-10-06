using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using TFS.OpCenter.Data;

namespace TFS.OpCenter
{
    /// <summary>
    /// Static utility classes
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// Gets the username of the active user in an HTTP context
        /// </summary>
        /// <returns></returns>
        public static string GetActiveUsername()
        {
            String name = string.Empty;
            if (HttpContext.Current != null)
            {
                name = HttpContext.Current.Request.Params["name"];
                if (name == null || name.Equals(""))
                    name = HttpContext.Current.Request.Params["person"];
                if (name == null || name.Equals(""))
                    name = HttpContext.Current.User.Identity.Name;            
            }
            else
                name = System.Threading.Thread.CurrentPrincipal.Identity.Name;
            return name.Substring(name.IndexOf('\\') + 1);
        }

        /// <summary>
        /// Gets the person object for the active user. Empty person if not found.
        /// </summary>
        public static Person GetActivePerson()
        {
            return Person.FetchByUsername(Utility.GetActiveUsername());
        }

        /// <summary>
        /// This will attempt to resolve the display name of a person given their username. If the user doesn't exist, then it simply returns the username.
        /// </summary>
        public static string ResolveDisplayName(string username)
        {
            Person person = Person.FetchByUsername(username);
            if (person == null || !person.IsLoaded || person.IsNew)
            {
                return username;
            }
            else
            {
                return person.Displayname;
            }
        }

        /// <summary>
        /// Gets the formatted string version of the build number for the op center.
        /// </summary>
        public static string GetBuildNumber()
        {
            return typeof(Utility).Assembly.GetName().Version.ToString(3);
        }


    }
}
