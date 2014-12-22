using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Security;
using AutoMapper;
using Newtonsoft.Json;
using TFS.Extensions;
using TFS.Models;
using TFS.Models.Users;
using TFS.Web.ViewModels;

namespace TFS.Web.Controllers
{
    public partial class SecurityController : BaseController
    {
        public SecurityController(IApplicationSettings applicationSettings, IRepository repository)
            : base(applicationSettings, repository)
        {
        }

        public virtual ActionResult Index()
        {
            return Redirect(string.Format("https://accounts.google.com/o/oauth2/auth?scope=email%20profile&state=foobar&redirect_uri={0}&response_type=code&client_id={1}&prompt=select_account&access_type=online", HttpUtility.UrlEncode(Google_RedirectUri), google_clientid));
        }

        public virtual ViewResult LogOn(Uri returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            ViewData["google_url"] = string.Format("https://accounts.google.com/o/oauth2/auth?scope=email%20profile&state=foobar&redirect_uri={0}&response_type=code&client_id={1}&prompt=select_account&access_type=online", HttpUtility.UrlEncode(Google_RedirectUri), google_clientid);
            return View();
        }

        public virtual ActionResult Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ViewData.Add("ErrorMessage", "Invalid Username or Password");
                return View("LogOn");
            }
            username = CleanUpUsername(username);
            string passwordHash = null;
            try
            {
                passwordHash = Crypto.Hash(password, Crypto.HashAlgorithm.SHA256);
            }
            catch (Exception)
            {
                ViewData.Add("ErrorMessage", "Invalid Username or Password");
                return View("LogOn");
            }

            var user = this.Repository.GetUserByUsername(username);
            if (user == null || user.Disabled)
            {
                ViewData.Add("ErrorMessage", "Invalid Username or Password");
                return View("LogOn");
            }
            if (user.PasswordHash != passwordHash)
            {
                ViewData.Add("ErrorMessage", "Invalid Username or Password");
                return View("LogOn");
            }

            FormsAuthentication.SetAuthCookie(user.Username, false);
            return Redirect("~");
        }

        private string Google_RedirectUri
        {
            get
            {
#if DEBUG
                return "http://localhost:60488/oauth2callback";
#else
                return "http://tacticalflightservices.azurewebsites.net/oauth2callback";
#endif
            }
        }
        
        private const string google_clientid = "830934135780-pt5a3b3n8fi36koambitrrhhr6f8o1vv.apps.googleusercontent.com";
        private const string google_clientsecret = "MF13fiwoYvligiqFKdu1tSw7";

        public virtual ActionResult OAuth2callback(string state, string code)
        {
            if (state != "foobar")
            {
                return RedirectToAction(Actions.LogOn());
            }
            string responseContent = "";
            try
            {
                var post = string.Format("code={0}&client_id={1}&client_secret={2}&redirect_uri={3}&grant_type={4}"
                    , HttpUtility.UrlEncode(code)
                    , HttpUtility.UrlEncode(google_clientid)
                    , HttpUtility.UrlEncode(google_clientsecret)
                    , HttpUtility.UrlEncode(Google_RedirectUri)
                    , HttpUtility.UrlEncode("authorization_code"));

                var request = (HttpWebRequest)HttpWebRequest.Create("https://accounts.google.com/o/oauth2/token");
                request.Method = "POST";
                request.AllowAutoRedirect = false;
                request.ContentType = "application/x-www-form-urlencoded";
                using (var stOut = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII))
                {
                    stOut.Write(post);
                    stOut.Close();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var resStream = new StreamReader(httpResponse.GetResponseStream(), Encoding.ASCII))
                {
                    responseContent = resStream.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                return Content("There was a problem with your request (" + e.Message + "). Please go back and try again.");
            }

            var reply = JsonConvert.DeserializeObject<dynamic>(responseContent);
            var id_token = reply["id_token"];
            var token = new System.IdentityModel.Tokens.JwtSecurityToken(id_token.Value);
            var emailAddress =  token.Claims.FirstOrDefault(x => x.Type == "email").Value;

            var username = CleanUpUsername(emailAddress);

            var user = this.Repository.GetUserByUsername(username);
            if (user == null || user.Disabled)
            {
                ViewBag.EmailAddress = emailAddress;
                return View("NotAUser");
            }

            FormsAuthentication.SetAuthCookie(user.Username, false);

            return Redirect("~");
        }

        public virtual RedirectToRouteResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(MVC.Site.Index());
        }

        public static string CleanUpUsername(string username)
        {
            string cleanedUsername = username;
            if (cleanedUsername.Contains("@"))
                cleanedUsername = cleanedUsername.Substring(0, cleanedUsername.IndexOf("@"));
            return cleanedUsername;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [Authorize]
        public virtual ViewResult ChangePassword()
        {
            var user = this.CurrentUser;
            var viewModel = Mapper.Map<User, UserViewModel>(user);
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize]
        public virtual ActionResult ChangePassword(string password, string confirmPassword)
        {
            var user = this.CurrentUser;
            if (string.IsNullOrWhiteSpace(password) || password != confirmPassword)
            {
                ViewData["ErrorMessage"] = "Invalid Password";
                return View();
            }
            user.PasswordHash = Crypto.Hash(password, Crypto.HashAlgorithm.SHA256);
            return Redirect("~");
        }
    }
}
