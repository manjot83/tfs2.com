using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TFS.Web.Html
{
    public static class ImageLinkExtensions
    {
        public static string NavImageLink(this HtmlHelper helper, string linkText, string imageTag, string url)
        {
            var tagBuilder = new TagBuilder("a");
            tagBuilder.MergeAttribute("href", url);
            tagBuilder.InnerHtml = helper.ImgFor(imageTag) + linkText;
            return tagBuilder.ToString(TagRenderMode.Normal);
        }

        public static string NavImageLink(this HtmlHelper helper, string linkText, string imageTag, ActionResult action)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var tagBuilder = new TagBuilder("a");
            tagBuilder.MergeAttribute("href", urlHelper.RouteUrl(action.GetRouteValueDictionary()));
            tagBuilder.InnerHtml = helper.ImgFor(imageTag) + linkText;
            return tagBuilder.ToString(TagRenderMode.Normal);
        }
    }
}
