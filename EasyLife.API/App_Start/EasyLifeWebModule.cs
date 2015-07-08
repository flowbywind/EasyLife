using System.Reflection;
using Abp.Modules;

namespace EasyLife.API
{
    [DependsOn(typeof(EasyLifeDataModule), typeof(EasyLifeApplicationModule))]
    public class EasyLifeWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Add/remove languages for your application

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

        }
    }
}
