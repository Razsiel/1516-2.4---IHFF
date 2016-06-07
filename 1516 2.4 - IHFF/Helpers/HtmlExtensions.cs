using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Helpers
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper html, string image, ImageExtensions extension = ImageExtensions.jpg)
        {
            //DIRTY SOLUTION!!!!!! image should come in as byte[], then converted to base64

            //string base64 = Convert.ToBase64String(image);
            var img = String.Format("data:image/{1};base64,{0}", image, extension.ToString());
            string htmlString = string.Format("<img src='{0}' />", img);
            return new MvcHtmlString(htmlString);
        }

        // Creates an ActionLink with an image
        public static MvcHtmlString ActionImage(this HtmlHelper html, string action, string imagePath, string controllerName = null,
            string anchorClass = null, string imgClass = null, object routeValues = null, string alt = null)
        {
            var url = new UrlHelper(html.ViewContext.RequestContext);

            // Build the <img> tag
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", url.Content(imagePath));
            imgBuilder.MergeAttribute("alt", alt);
            imgBuilder.MergeAttribute("class", imgClass);
            string imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);

            // Build the <a> tag
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("href", url.Action(action, controllerName, routeValues));
            anchorBuilder.MergeAttribute("class", anchorClass);
            anchorBuilder.InnerHtml = imgHtml; // include the <img> tag inside
            string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(anchorHtml);

        }
    }

    public enum ImageExtensions
    {
        jpg,
        gif,
        png,
        bmp,
        jpeg
    }
}