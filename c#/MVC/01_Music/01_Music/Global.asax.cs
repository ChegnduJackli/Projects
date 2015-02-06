using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _01_Music
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }


        public static void RegisterRoutes(RouteCollection routes)
        {

            //IgnoreRoute 和MapRoute 使代码更加简洁，利于理解
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");  //忽略匹配.axd 文件

            //只有2个位置，必须是AlbumControlleer, 还有一个可选的参数占位符
            //      routes.MapRoute(
            //    "Blog",                                           // Route name
            //    "Album/{entryDate}",                            // URL with parameters
            //    new { controller = "Album", action = "Entry" }  // Parameter defaults
            //);
            //跟上面一样，忽略匹配.axd文件
            routes.Add(new Route
            (
               "{resource}.axd/{*pathInfo}",
                new StopRoutingHandler()
            ));

            //配置自定义约束
            routes.MapRoute("Article", "blog/{year}/{month}/{day}",
                new
                {
                    controller = "blog",
                    action = "Index",
               
                    year = "",
                    month = "",
                    day = ""
                },
                new
                {
                    year = new YearRouteConstraint(),
                    month = new MonthRouteConstraint(),
                    day = new DayRouteConstraint()
                });

            //routes.MapRoute(
            //    "blog", // Route name
            //    "{controller}/{year}/{month}/{day}", // URL with parameters
            //    new { controller = "blog", action = "Index" } // Parameter defaults
            //    , new { year = @"\d{4}", month = @"\d{2}", day = @"\d{2}" }   //使用正则表达式路由约束
            //);



            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
           "SalesRoute", // Route name
           "SalesReport/{locale}/{year}");


            /* Catch -All 参数
             * Match belows 
             * /query/select/a/b/c    extrastuff="a/b/c"
             * /query/select/a/b/c/   extrastuff="a/b/c"
             * /query/select          extrastuff=""(路由仍然匹配，"Catch- all"只捕获示例中的空字符串 )
             */ 
            routes.MapRoute("catchallroute","query/{query-name}/{*extrastuff}");



 


        }
        protected void Route()
        {
            RouteValueDictionary parameters = new RouteValueDictionary { 
                                            { "year", "2007" },
                                            { "locale", "en-CA" },
                                            { "category", "recreation" } 
                                            };
            /*
             URL生成的高层次概述
             * 我们使用多种方法来生产URL，但是这些方法都以调用RouteCollection.GetVirtualPath方法的一个重载版本。该方法有2个重载版本。
             *public VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values);
             *public VirtualPathData GetVirtualPath(RequestContext requestContext, string name, RouteValueDictionary values);
             
             */
            VirtualPathData vpd = RouteTable.Routes.GetVirtualPath(null, "SalesRoute", parameters);
            string url = vpd.VirtualPath;
        }

        protected void Application_Start()
        {

            //add yourself view engine
            //ViewEngines.Engines.Clear();
            //ViewEngines.Engines.Add(new MyViewEngine());
            System.Data.Entity.Database.SetInitializer(new _01_Music.Models.SampleData());

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            Route();
        }
    }
    //自定义路由约束
    //日期路由约束
    public class YearRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (routeDirection == RouteDirection.IncomingRequest &&
                parameterName.ToLower() == "year")
            {
                var year = 0;
                if (int.TryParse(values["year"].ToString(), out year))
                {
                    return year >= 2000 && year <= 2012;
                }
                return false;
            }
            return false;
        }
    }

    public class MonthRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (routeDirection == RouteDirection.IncomingRequest &&
                parameterName.ToLower() == "month")
            {
                var month = 0;
                if (int.TryParse(values["month"].ToString(), out month))
                {
                    return month >= 1 && month <= 12;
                }
                return false;
            }
            return false;
        }
       
    }
    
    public class DayRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (routeDirection == RouteDirection.IncomingRequest &&
                parameterName.ToLower() == "day")
            {
                var month = 0;
                if (!int.TryParse(values["month"].ToString(), out month)) return false;
                if (month <= 0 || month > 12) return false;

                var day = 0;
                if (!int.TryParse(values["day"].ToString(), out day)) return false;

                switch (month)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        return day <= 31;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        return day <= 31;
                    case 2:
                        return day <= 28;//不计闰年
                }
            }
            return false;
        }
    }



}