using NIM.Classes.Dto;  
using NIM.Sections.Dto;
using NIM.TeacherProfiles.Dto;
using NIM.PrincipalProfiles.Dto;
using NIM.AccountantProfiles.Dto;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NIM.Authorization;
using NIM.Campuses.Dto;
using NIM.StudentProfiles.Dto;
using NIM.LeaveApplications.Dto;

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
            config.AddProfile<TeacherProfileMapProfile>();
            config.AddProfile<PrincipalMapProfile>();
            config.AddProfile<PrincipalMapProfile>();
            config.AddProfile<AccountantMapProfile>();
            config.AddProfile<StudentMapProfile>();
            config.AddProfile<NIM.StudentFees.Dto.StudentFeeMapProfile>();
            config.AddProfile<NIM.SalaryRecords.Dto.SalaryMapProfile>();
            config.AddProfile<NIM.LeaveApplications.Dto.LeaveApplicationMapProfile>();
            config.AddProfile<NIM.StaffAttendances.Dto.StaffAttendanceMapProfile>();
            config.AddProfile<NIM.StudentAttendances.Dto.StudentAttendanceMapProfile>();
            config.AddProfile<NIM.Tests.Dto.TestMapProfile>();
            config.AddProfile<NIM.StudentResults.Dto.StudentResultMapProfile>();
            config.AddProfile<NIM.SmsNotifications.Dto.SmsNotificationMapProfile>();

        });
    }                   
}
