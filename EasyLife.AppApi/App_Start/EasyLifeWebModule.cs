using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Abp.Localization;
using Abp.Localization.Sources.Xml;
using Abp.Modules;
using EasyLife.AppApi;

namespace EasyLife.Web
{
    [DependsOn(typeof(EasyLifeDataModule), typeof(EasyLifeApplicationModule))]
    public class EasyLifeWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Add/remove languages for your application
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england"));
            Configuration.Localization.Languages.Add(new LanguageInfo("ch", "中文", "famfamfam-flag-cn", true));


            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new XmlLocalizationSource(
                    EasyLifeConsts.LocalizationSourceName,
                    HttpContext.Current.Server.MapPath("~/Localization/EasyLife")
                    )
                );

            //Configure navigation/menu
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
