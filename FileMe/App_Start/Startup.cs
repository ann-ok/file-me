using FileMe.App_Start;
using Microsoft.Owin;
using Owin;
using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: OwinStartup(typeof(Startup))]
namespace FileMe.App_Start
{
    public partial class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            //требуется для Owin, переносим из Global.asax
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //строка подключения указывается в Web.config
            var connectionString = ConfigurationManager.ConnectionStrings["MSSQL"];
            if (connectionString == null)
                throw new Exception("Не найдена строка подключения");

        }
    }
}