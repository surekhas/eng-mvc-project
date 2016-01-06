using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Eng_Part
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApiRoute",
                routeTemplate: "myapi/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
