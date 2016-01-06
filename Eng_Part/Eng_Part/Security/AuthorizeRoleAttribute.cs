using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;   // Authorize attribute 
using Eng_Part.Models.Entity;
using Eng_Part.Models.Database;

namespace Eng_Part.Security
{
    public class AuthorizeRoleAttribute : AuthorizeAttribute
    {

        private readonly string[] userAssignedRoles;

        public AuthorizeRoleAttribute(params string[] roles)
        {
            this.userAssignedRoles = roles;
        }


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            using (Eng_PartEntities db = new Eng_PartEntities())
            {
                UserManager UM = new UserManager();
                foreach (var roles in userAssignedRoles)
                {
                    authorize = UM.IsUserInRole(httpContext.User.Identity.Name, roles);
                    if (authorize)
                        return authorize;
                }
            }
            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

            //if (filterContext.RequestContext.HttpContext.Request.IsAuthenticated)
            //{
            //    filterContext.Result = new RedirectResult("~/Account/Login");
            //}
            //else {
                filterContext.Result = new RedirectResult("~/Home/UnAuthorized");
           // }

           
           // filterContext.Result = new HttpUnauthorizedResult();
           
        }

    }// class end s
}