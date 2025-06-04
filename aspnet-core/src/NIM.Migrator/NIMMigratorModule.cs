using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NIM.Configuration;
using NIM.EntityFrameworkCore;
using NIM.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace NIM.Migrator;

[DependsOn(typeof(NIMEntityFrameworkModule))]
public class NIMMigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public NIMMigratorModule(NIMEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(NIMMigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            NIMConsts.ConnectionStringName
        );

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        Configuration.ReplaceService(
            typeof(IEventBus),
            () => IocManager.IocContainer.Register(
                Component.For<IEventBus>().Instance(NullEventBus.Instance)
            )
        );
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(NIMMigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
