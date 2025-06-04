using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NIM.EntityFrameworkCore;
using NIM.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace NIM.Web.Tests;

[DependsOn(
    typeof(NIMWebMvcModule),
    typeof(AbpAspNetCoreTestBaseModule)
)]
public class NIMWebTestModule : AbpModule
{
    public NIMWebTestModule(NIMEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
    }

    public override void PreInitialize()
    {
        Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(NIMWebTestModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<ApplicationPartManager>()
            .AddApplicationPartsIfNotAddedBefore(typeof(NIMWebMvcModule).Assembly);
    }
}