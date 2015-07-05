using System;
using System.Web.Http;
using Abp.Dependency;
using Abp.Web;
using Castle.Facilities.Logging;

namespace EasyLife.API
{
    public class WebApiApplication : AbpWebApplication
    {
        protected override  void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
            base.Application_Start(sender, e);
        }
    }
}
