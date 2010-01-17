using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Pithy;
using Pithy.CacheBuster;

namespace TFS.Web.Html
{
    public static class StaticResourceExtensions
    {
        public static string JavaScriptsFor(this HtmlHelper htmlHelper, params string[] tags)
        {
            var files = AssetCache.GetJavaScriptFor(tags);
            var sb = new StringBuilder();
            foreach (var file in files)
                sb.AppendLine(StaticResourceExtensions.JavaScript(htmlHelper, file));
            return sb.ToString();
        }

        public static string JavaScript(this HtmlHelper htmlHelper, string file)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            TagBuilder link = new TagBuilder("script");
            link.MergeAttribute("type", "text/javascript");
            link.MergeAttribute("src", urlHelper.Content(file) + "?r=" + CachedResourceId.Key);
            return link.ToString(TagRenderMode.Normal);
        }

        public static string StylesheetsFor(this HtmlHelper htmlHelper, params string[] tags)
        {
            var files = AssetCache.GetCssFor(tags);
            var sb = new StringBuilder();
            foreach (var file in files)
                sb.AppendLine(StaticResourceExtensions.Stylesheet(htmlHelper, file));
            return sb.ToString();
        }

        public static string Stylesheet(this HtmlHelper htmlHelper, string file)
        {
            return StaticResourceExtensions.Stylesheet(htmlHelper, file, null);
        }

        public static string Stylesheet(this HtmlHelper htmlHelper, string file, string media)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            TagBuilder link = new TagBuilder("link");
            link.MergeAttribute("rel", "stylesheet");
            link.MergeAttribute("type", "text/css");
            if (!string.IsNullOrEmpty(media))
                link.MergeAttribute("media", media);
            link.MergeAttribute("href", urlHelper.Content(file) + "?r=" + CachedResourceId.Key);
            return link.ToString(TagRenderMode.SelfClosing);
        }

        public static string ImgFor(this HtmlHelper htmlHelper, string tag)
        {
            return ImgFor(htmlHelper, tag, null);
        }

        public static string ImgFor(this HtmlHelper htmlHelper, string tag, string alt)
        {
            return ImgFor(htmlHelper, tag, null, null);
        }

        public static string ImgFor(this HtmlHelper htmlHelper, string tag, string alt, object htmlAttributes)
        {
            var file = AssetCache.GetFileFor(tag).FirstOrDefault();
            if (string.IsNullOrEmpty(file))
                return null;
            return StaticResourceExtensions.Img(htmlHelper, file, alt, htmlAttributes);
        }

        public static string Img(this HtmlHelper htmlHelper, string file)
        {
            return StaticResourceExtensions.Img(htmlHelper, file, null);
        }

        public static string Img(this HtmlHelper htmlHelper, string file, string alt)
        {
            return StaticResourceExtensions.Img(htmlHelper, file, null, null);
        }

        public static string Img(this HtmlHelper htmlHelper, string file, string alt, object htmlAttributes)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            TagBuilder img = new TagBuilder("img");
            img.MergeAttribute("src", urlHelper.Content(file) + "?r=" + CachedResourceId.Key);
            img.MergeAttribute("alt", alt);
            img.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);
            return img.ToString(TagRenderMode.SelfClosing);
        }
    }
}
