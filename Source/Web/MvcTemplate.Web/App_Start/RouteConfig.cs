namespace ChillZone.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "Category",
               url: "Category/{name}",
               defaults: new { controller = "Posts", action = "Category" });
            routes.MapRoute(
                name: "Post",
                url: "Post/{id}",
                defaults: new { controller = "Posts", action = "ById" });
            routes.MapRoute(
               name: "PostCreate",
               url: "Posts/Create",
               defaults: new { controller = "Posts", action = "Create" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
