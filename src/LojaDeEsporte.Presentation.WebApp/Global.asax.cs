using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace LojaDeEsporte.Presentation.WebApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Bootstrapper.Initialise();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session != null)
            {
                CultureInfo ci = (CultureInfo)HttpContext.Current.Session["Culture"];
                if (ci == null)
                {
                    if (HttpContext.Current.Request.UserLanguages == null) return;
                    ci = new CultureInfo(HttpContext.Current.Request.UserLanguages[0]);
                }

                System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
                System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
            }
        }

        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (custom.Equals("language"))
            {
                return System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            }
            return base.GetVaryByCustomString(context, custom);
        }
    }
}