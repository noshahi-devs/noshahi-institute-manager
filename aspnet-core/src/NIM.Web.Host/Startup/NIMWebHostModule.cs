using Abp.Modules;
using Abp.Reflection.Extensions;
using NIM.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace NIM.Web.Host.Startup
{
    [DependsOn(
       typeof(NIMWebCoreModule))]
    public class NIMWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public NIMWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NIMWebHostModule).GetAssembly());
        }
    }
}
