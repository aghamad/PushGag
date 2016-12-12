using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace PushGag
{
    public class Global : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // EN ORDRE: RouteName, RouteUrl et PhysicalFile
            routes.MapPageRoute("Home",
                "",
                "~/Pages/Home.aspx");

            routes.MapPageRoute("Registration",
                "register",
                "~/Pages/Registration.aspx");

            routes.MapPageRoute("Login",
                "login",
                "~/Pages/Login.aspx");

            // Admin

            routes.MapPageRoute("Admin",
                "admin",
                "~/Pages/Admin/AdminUpload.aspx");

            routes.MapPageRoute("AdminLogin",
                "admin/login",
                "~/Pages/Admin/AdminLogin.aspx");

            routes.MapPageRoute("AdminProfile",
                "admin/profile",
                "~/Pages/Admin/AdminProfile.aspx");
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}