using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using RestSharp.Authenticators;
using TFS.OpCenter.Data;
using RestSharp;

namespace TFS.OpCenter
{
    /// <summary>
    /// Static utility classes
    /// </summary>
    public class Utility
    {
        public static IRestResponse EmailNewsNotification(string recipients, int newsPostId)
        {
            var url = string.Format("{0}/ViewArticle.aspx?id={1}", Utility.GetCurrentWebsiteRoot(), newsPostId);

            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
            new HttpBasicAuthenticator("api", "key-78d4c90b6e7edb2d9886ca526cf19f20");
            var request = new RestRequest();
            request.AddParameter("domain", "mg.tacticalflightservices.com", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "TFS Mailer noreply@mg.tacticalflightservices.com");
            request.AddParameter("to", "noreply@mg.tacticalflightservices.com");
            request.AddParameter("bcc", recipients);
            request.AddParameter("subject", "TFS News Notification");
            request.AddParameter("text", string.Format("A new news item has been posted to the TFS Intranet. Here is the URL: {0}", url));
            request.Method = Method.POST;
            return client.Execute(request);
        }

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

        public static string GetCurrentWebsiteRoot()
        {
            return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);

        }
    }
}
