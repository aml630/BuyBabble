using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Routing.Constraints;


namespace AzureBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

       

           routes.MapRoute(
           name: "Home",
           url: "",
           defaults: new { controller = "Home", action = "Index" }
          );
 
            routes.MapRoute(
            name: "CatIndex",
            url: "Category/Index",
            defaults: new { controller = "Home", action = "Index" }
          );

            routes.MapRoute(
              name: "Logoff",
              url: "LogOff",
              defaults: new { controller = "Account", action = "LogOff" }
          );

            routes.MapRoute(
               name: "Login",
               url: "Login",
               defaults: new { controller = "Account", action = "Login" }
           );


            routes.MapRoute(
             name: "Register",
             url: "Register",
             defaults: new { controller = "Account", action = "Register" }
         );

            routes.MapRoute(
                name: "About",
                url: "About",
                defaults: new { controller = "Home", action = "About" }
            );

            routes.MapRoute(
              name: "Product",
              url: "{id}/{productId}",
              defaults: new { controller = "Category", action = "Product" }
              //constraints: new { id = @"([a-z]+-?)+", productId = @"([a-z]+-?)+" }
          );
            routes.MapRoute(
             name: "Post",
             url: "{articleSlug}",
             defaults: new { controller = "Article", action = "Post" }
            );
            // routes.MapRoute(
            //    name: "Category",
            //    url: "{id}",
            //    defaults: new { controller = "Category", action = "Index" }
            //    //constraints: new {id = @"([a-z]+-?)+" }
            //);


            routes.MapRoute(
            name: "newDefault",
            url: "Default/{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
       name: "Default",
       url: "{controller}/{action}/{id}",
       defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
   );



        }
    }
}
