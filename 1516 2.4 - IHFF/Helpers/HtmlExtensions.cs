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

        // Create a substring for movie descriptions
        public static HtmlString TrimStringIfLongerThan(this string value, int maxLenght)
        {
            if (value.Length > maxLenght)
            {
                return new HtmlString(value.Substring(value.Length - (maxLenght - 3)) + "... <a href=\"#\">[Lees meer...]</a>");
            }

            return new HtmlString(value + " <a href=\"#\">[Lees meer...]</a>");
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