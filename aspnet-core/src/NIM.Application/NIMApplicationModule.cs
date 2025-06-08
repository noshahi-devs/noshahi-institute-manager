using NIM.Classes.Dto;  
using NIM.Sections.Dto;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NIM.Authorization;
using NIM.Campuses.Dto;

namespace NIM;

[DependsOn(
    typeof(NIMCoreModule),
    typeof(AbpAutoMapperModule))]
public class NIMApplicationModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.Authorization.Providers.Add<NIMAuthorizationProvider>();
    }

    public override void Initialize()
    {
        var thisAssembly = typeof(NIMApplicationModule).GetAssembly();

        IocManager.RegisterAssemblyByConvention(thisAssembly);

        Configuration.Modules.AbpAutoMapper().Configurators.Add(
            // Scan the assembly for classes which inherit from AutoMapper.Profile
            cfg => cfg.AddMaps(thisAssembly)
        );
        // Add this line to register your mapping profile
        Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
        {
            config.AddProfile<CampusMapProfile>();
            config.AddProfile<ClassMapProfile>();
            config.AddProfile<SectionMapProfile>();
        });
    }                   
}
