using _13FilterDemo.CustomFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _13FilterDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalFilters.Filters.Add(new ActionFilter());
            GlobalFilters.Filters.Add(new AuthenticationFilter());
            GlobalFilters.Filters.Add(new AuthorizationFilter());
            GlobalFilters.Filters.Add(new ResultFilter());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
