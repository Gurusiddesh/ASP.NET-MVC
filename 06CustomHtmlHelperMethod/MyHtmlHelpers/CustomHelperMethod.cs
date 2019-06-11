using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _06CustomHtmlHelperMethod.MyHtmlHelpers
{
    public class CustomHelperMethod
    {
        public static IHtmlString File(string id)
        {
            TagBuilder tagbuilder = new TagBuilder("input");
            tagbuilder.Attributes.Add("type", "file");
            tagbuilder.Attributes.Add("id", id);

            return new MvcHtmlString(tagbuilder.ToString());
                
        }
    }
}