using MVC5Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC5Test.Services
{
    public class TokenHandler : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            var value = httpContext.Request.Headers.GetValues(4)[0].Replace("Bearer","").Trim();
            if (!string.IsNullOrEmpty(value))
            {
                IAuthenticationContainerModel model = JWTContainerModel.GetJWTContainerModel("smit", "smit@smit.com");
                IAuthService authService = new JWTService(model.SecretKey);
                if (authService.IsTokenValid(value))
                    authorize = true;
                else
                    authorize = false;
            }



            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Home" },
                    { "action", "UnAuthorized" }
               });
        }

        /// <summary>
        /// retrive header detail from the request 
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        
    }
}