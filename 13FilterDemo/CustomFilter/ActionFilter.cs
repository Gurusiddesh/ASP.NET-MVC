using _13FilterDemo.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _13FilterDemo.CustomFilter
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            SessionManager.StoreInSession(filterContext, "OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SessionManager.StoreInSession(filterContext, "OnActionExecuting");
        }
    }
}