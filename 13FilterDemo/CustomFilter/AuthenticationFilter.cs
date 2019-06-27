using _13FilterDemo.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Filters;

namespace _13FilterDemo.CustomFilter
{
    public class AuthenticationFilter : IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            SessionManager.StoreInSession(filterContext, "OnAuthentication");
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            SessionManager.StoreInSession(filterContext, "OnAuthenticationChallenge");
        }
    }
}