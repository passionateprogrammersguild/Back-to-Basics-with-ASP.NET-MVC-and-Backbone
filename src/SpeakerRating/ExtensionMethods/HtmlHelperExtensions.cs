using System.Linq;
using System.Reflection;

namespace System.Web.Mvc.Html
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Anchor(this HtmlHelper htmlHelper, string linkText, object htmlAttributes)
        {
            Action<TagBuilder, PropertyInfo> addAttribute = (tb, p) => tb.MergeAttribute(p.Name,  p.GetValue(htmlAttributes, null).ToString());
            Func<MvcHtmlString> returnEmpty = () => htmlHelper.Label(linkText);
            Func<MvcHtmlString> returnAnchor = () =>
                                                   {
                                                       var tb = new TagBuilder("a");
                                                       var props = htmlAttributes.GetType().GetProperties();
                                                       foreach (var prop in props)
                                                       {
                                                           addAttribute(tb, prop);
                                                       }

                                                       tb.SetInnerText(linkText);
                                                       return MvcHtmlString.Create(tb.ToString());
                                                   };
            Func<object, bool> hrefIsEmpty = (o) => o.GetType().GetProperties().Where(p => p.Name == "href")
                                                        .Select(x => x.GetValue(o, null))
                                                        .Where(v => v == null)
                                                        .Count() == 1;
           

            return hrefIsEmpty(htmlAttributes)
                       ? returnEmpty()
                       : returnAnchor();
        }

        public static MvcHtmlString Image(this HtmlHelper htmlHelper, string defaultImagePath, object htmlAttributes)
        {
            Action<TagBuilder, PropertyInfo> addAttribute = (tb, p) =>
                                                                {
                                                                    try
                                                                    {
                                                                        tb.MergeAttribute(p.Name, p.GetValue(htmlAttributes, null).ToString());
                                                                    }
                                                                    catch //Do nothing because value is null
                                                                    {                                                                        
                                                                        
                                                                    }
                                                                };
            var props = htmlAttributes.GetType().GetProperties();
            var srcProp = props.Where(p => p.Name == "src").FirstOrDefault();            
            Func<string, MvcHtmlString> returnAnchor = (imgPath) =>
            {
                var tb = new TagBuilder("img");
                foreach (var prop in props)
                {
                    addAttribute(tb, prop);
                }

                tb.MergeAttribute("src", imgPath, true);
                
                return MvcHtmlString.Create(tb.ToString());
            };
            Func<object, bool> srcIsEmpty = (o) => o.GetType().GetProperties().Where(p => p.Name == "src")
                                                        .Select(x => x.GetValue(o, null))
                                                        .Where(v => v == null)
                                                        .Count() == 1;


            return srcIsEmpty(htmlAttributes)
                       ? returnAnchor(defaultImagePath)
                       : returnAnchor(srcProp.GetValue(htmlAttributes, null).ToString());
        }
    }
}