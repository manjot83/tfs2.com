using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using TFS.OpCenter;
using TFS.Web.ViewModels;

namespace TFS.Web.Mvc
{
    public static class WebRequestHelper
    {
        public static void UserControllerSendNewsPostNotificationRequest(int newsPostId)
        {
            var viewModel = new NewsPostNotificationViewModel()
            {
                NewsPostId = newsPostId
            };

            var controllerName = MVC.Users.Name;
            const string actionName = "SendNewsPostNotification"; //MVC.Users.ActionNames.SendNewsPostNotification
            var controllerUrl = string.Format("{0}/{1}/{2}", Utility.GetCurrentWebsiteRoot(), controllerName, actionName);

            try
            {
                using (var client = new WebClient())
                {
                    var values = new NameValueCollection
                    {
                        {"newsPostId", Convert.ToString(newsPostId)}
                    };

                    var result = client.UploadValues(controllerUrl, values);
                }
            }
            catch (Exception ex)
            {
                //ignore any email notifications errors and continue
            }
        }
    }
}