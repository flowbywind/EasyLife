using System;
using System.Web.Mvc;
using System.Web.Routing;
using Abp.Web;

namespace EasyLife.AppApi
{
    public class MvcApplication : AbpWebApplication
    {
        protected override void Application_Start(object sender,EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            //IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
            base.Application_Start(sender, e);

        }
    }
}
