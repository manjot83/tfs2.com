using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Centro.Web.Mvc.Html;

namespace TFS.Web.Html
{
    public static class ImageLinkExtensions
    {
        public static string NavImageLink(this HtmlHelper helper, string linkText, string imageContentPath, string url)
        {
            var tagBuilder = new TagBuilder("a");
            tagBuilder.MergeAttribute("href", url);
            tagBuilder.InnerHtml = helper.ImageContent(imageContentPath, "") + linkText;
            return tagBuilder.ToString(TagRenderMode.Normal);
        }

        public static string NavImageLink(this HtmlHelper helper, string linkText, string imageContentPath, ActionResult action)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var tagBuilder = new TagBuilder("a");
            tagBuilder.MergeAttribute("href", urlHelper.RouteUrl(action.GetRouteValueDictionary()));
            tagBuilder.InnerHtml = helper.ImageContent(imageContentPath, "") + linkText;
            return tagBuilder.ToString(TagRenderMode.Normal);
        }
    }
}
