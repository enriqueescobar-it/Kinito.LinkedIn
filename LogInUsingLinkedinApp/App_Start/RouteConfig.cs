/**
* RouteConfig.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 09-04-2019
* OR 4/9/2019 10:55:11 AM
**/

namespace LogInUsingLinkedinApp
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Defines the <see cref="RouteConfig" />
    /// </summary>
    public class RouteConfig
    {
        #region Methods

        /// <summary>
        /// The RegisterRoutes
        /// </summary>
        /// <param name="routes">The routes<see cref="RouteCollection"/></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        #endregion
    }
}
