﻿using _13FilterDemo.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _13FilterDemo.CustomFilter
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            SessionManager.StoreInSession(filterContext, "OnAuthorization");
        }
    }
}