using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _13FilterDemo.utilities
{
    public class SessionManager
    {
        public static void StoreInSession(ControllerContext context, string methodName)
        {
            var sessionValue = context.HttpContext.Session["filter"];
            sessionValue = sessionValue + string.Format("<br /><h1>{0} : {1}</h1>", methodName, DateTime.Now.ToString());
            context.HttpContext.Session["filter"] = sessionValue;
        }
    }
}