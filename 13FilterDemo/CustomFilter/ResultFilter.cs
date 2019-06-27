using _13FilterDemo.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _13FilterDemo.CustomFilter
{
    public class ResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            SessionManager.StoreInSession(filterContext, "OnResultExecuted");
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            SessionManager.StoreInSession(filterContext, "OnResultExecuting");
        }
    }
}