using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace System.Web.Mvc.Html
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Anchor(this HtmlHelper htmlHelper, string linkText, object htmlAttributes)
        {
            Action<TagBuilder, PropertyInfo> addAttribute = (tb, p) => tb.MergeAttribute(p.Name,  p.GetValue(htmlAttributes, null).ToString());
            Func<MvcHtmlString> returnEmpty = () =>
                                                  {
                                                      var tb = new TagBuilder("span");
                                                      tb.SetInnerText(linkText);
                                                      return MvcHtmlString.Create(tb.ToString());
                                                  };

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

        public static MvcHtmlString Stars(this HtmlHelper htmlHelper, int ranking, object htmlAttributes)
        {

            var haveAttributes = htmlAttributes != null;
            var tags = new List<TagBuilder>();
            var htmlAttributeType = haveAttributes ? htmlAttributes.GetType() : null;
            const int numberOfStars = 5;
            var attributes = new Dictionary<string, object>()
                                 {
                                     {"type", "radio"}                                     
                                 };

            if (haveAttributes)
            {
                var kvp = htmlAttributeType.GetProperties()
                                           .Select(x=> new {Key= x.Name, Value = x.GetValue(htmlAttributes, null)})
                                           .ToList();
                foreach(var item in kvp)
                {
                    if (!attributes.ContainsKey(item.Key))
                    {
                        attributes.Add(item.Key, item.Value);   
                    }
                }
            }

            //TODO: if do not have a name property passed in then add it to the attributes
            var nameProp = haveAttributes
                               ? htmlAttributeType.GetProperties().Where(x => x.Name == "name").FirstOrDefault()
                               : null;
            if (nameProp == null)
            {
                attributes.Add("name", "stars_ranking");
            }

            var classProp = haveAttributes
                               ? htmlAttributeType.GetProperties().Where(x => x.Name == "class").FirstOrDefault()
                               : null;

            if (classProp == null) {
                attributes.Add("class", "star");
            }

            for (var i = 0; i < numberOfStars; i++)
            {
                tags.Add(new TagBuilder("input"));
                var thisTag = tags.Last();
                thisTag.MergeAttributes(attributes);
                if (i == ranking - 1)
                {
                    thisTag.MergeAttribute("checked", "checked");
                }
            }

            var sb = new StringBuilder();
            tags.ForEach(x => sb.Append(x.ToString()));
            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString Stars(this HtmlHelper htmlHelper, int ranking)
        {
            return Stars(htmlHelper, ranking, null);
        }
    }
}