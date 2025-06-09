using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace NIM.Authorization;

public class NIMAuthorizationProvider : AuthorizationProvider
{
    public override void SetPermissions(IPermissionDefinitionContext context)
    {
        context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
        context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
        context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
        context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

        // Add Campus permissions
        var campuses = context.CreatePermission(PermissionNames.Pages_Campuses, L("Campuses"));
        campuses.CreateChildPermission(PermissionNames.Pages_Campuses_Create, L("CreateCampus"));
        campuses.CreateChildPermission(PermissionNames.Pages_Campuses_Edit, L("EditCampus"));
        campuses.CreateChildPermission(PermissionNames.Pages_Campuses_Delete, L("DeleteCampus"));   

        // Add Class permissions
        var classes = context.CreatePermission(PermissionNames.Pages_Classes, L("Classes"));
        classes.CreateChildPermission(PermissionNames.Pages_Classes_Create, L("CreateClass"));
        classes.CreateChildPermission(PermissionNames.Pages_Classes_Edit, L("EditClass"));
        classes.CreateChildPermission(PermissionNames.Pages_Classes_Delete, L("DeleteClass"));

        // Add Section permissions
        var sections = context.CreatePermission(PermissionNames.Pages_Sections, L("Sections"));
        sections.CreateChildPermission(PermissionNames.Pages_Sections_Create, L("CreateSection"));
        sections.CreateChildPermission(PermissionNames.Pages_Sections_Edit, L("EditSection"));
        sections.CreateChildPermission(PermissionNames.Pages_Sections_Delete, L("DeleteSection"));

        // Add TeacherProfile permissions
        var teacherProfiles = context.CreatePermission(PermissionNames.Pages_TeacherProfiles, L("TeacherProfiles"));
        teacherProfiles.CreateChildPermission(PermissionNames.Pages_TeacherProfiles_Create, L("CreateTeacherProfile"));
        teacherProfiles.CreateChildPermission(PermissionNames.Pages_TeacherProfiles_Edit, L("EditTeacherProfile"));
        teacherProfiles.CreateChildPermission(PermissionNames.Pages_TeacherProfiles_Delete, L("DeleteTeacherProfile"));

        // Add PrincipalProfile permissions
        var principalProfiles = context.CreatePermission(PermissionNames.Pages_PrincipalProfiles, L("PrincipalProfiles"));
        principalProfiles.CreateChildPermission(PermissionNames.Pages_PrincipalProfiles_Create, L("CreatePrincipalProfile"));
        principalProfiles.CreateChildPermission(PermissionNames.Pages_PrincipalProfiles_Edit, L("EditPrincipalProfile"));
        principalProfiles.CreateChildPermission(PermissionNames.Pages_PrincipalProfiles_Delete, L("DeletePrincipalProfile"));

        // Add AccountantProfile permissions
        var accountantProfiles = context.CreatePermission(PermissionNames.Pages_AccountantProfiles, L("AccountantProfiles"));
        accountantProfiles.CreateChildPermission(PermissionNames.Pages_AccountantProfiles_Create, L("CreateAccountantProfile"));
        accountantProfiles.CreateChildPermission(PermissionNames.Pages_AccountantProfiles_Edit, L("EditAccountantProfile"));
        accountantProfiles.CreateChildPermission(PermissionNames.Pages_AccountantProfiles_Delete, L("DeleteAccountantProfile"));

        // Add StudentProfile permissions
        var studentProfiles = context.CreatePermission(PermissionNames.Pages_StudentProfiles, L("StudentProfiles"));
        studentProfiles.CreateChildPermission(PermissionNames.Pages_StudentProfiles_Create, L("CreateStudentProfile"));
        studentProfiles.CreateChildPermission(PermissionNames.Pages_StudentProfiles_Edit, L("EditStudentProfile"));
        studentProfiles.CreateChildPermission(PermissionNames.Pages_StudentProfiles_Delete, L("DeleteStudentProfile"));

        // Add StudentFee permissions
        var studentFees = context.CreatePermission(PermissionNames.Pages_StudentFees, L("StudentFees"));
        studentFees.CreateChildPermission(PermissionNames.Pages_StudentFees_Create, L("CreateStudentFee"));
        studentFees.CreateChildPermission(PermissionNames.Pages_StudentFees_Edit, L("EditStudentFee"));
        studentFees.CreateChildPermission(PermissionNames.Pages_StudentFees_Delete, L("DeleteStudentFee"));

        // Add SalaryRecord permissions
        var salaryRecords = context.CreatePermission(PermissionNames.Pages_SalaryRecords, L("SalaryRecords"));
        salaryRecords.CreateChildPermission(PermissionNames.Pages_SalaryRecords_Create, L("CreateSalaryRecord"));
        salaryRecords.CreateChildPermission(PermissionNames.Pages_SalaryRecords_Edit, L("EditSalaryRecord"));
        salaryRecords.CreateChildPermission(PermissionNames.Pages_SalaryRecords_Delete, L("DeleteSalaryRecord"));

        // Add StaffAttendance permissions
        var staffAttendance = context.CreatePermission(PermissionNames.Pages_StaffAttendance, L("StaffAttendance"));
        staffAttendance.CreateChildPermission(PermissionNames.Pages_StaffAttendance_Create, L("CreateStaffAttendance"));
        staffAttendance.CreateChildPermission(PermissionNames.Pages_StaffAttendance_Edit, L("EditStaffAttendance"));
        staffAttendance.CreateChildPermission(PermissionNames.Pages_StaffAttendance_Delete, L("DeleteStaffAttendance"));

        // Add StudentAttendance permissions
        var studentAttendance = context.CreatePermission(PermissionNames.Pages_StudentAttendance, L("StudentAttendance"));
        studentAttendance.CreateChildPermission(PermissionNames.Pages_StudentAttendance_Create, L("CreateStudentAttendance"));
        studentAttendance.CreateChildPermission(PermissionNames.Pages_StudentAttendance_Edit, L("EditStudentAttendance"));
        studentAttendance.CreateChildPermission(PermissionNames.Pages_StudentAttendance_Delete, L("DeleteStudentAttendance"));

        // Add Test permissions
        var tests = context.CreatePermission(PermissionNames.Pages_Tests, L("Tests"));
        tests.CreateChildPermission(PermissionNames.Pages_Tests_Create, L("CreateTest"));
        tests.CreateChildPermission(PermissionNames.Pages_Tests_Edit, L("EditTest"));
        tests.CreateChildPermission(PermissionNames.Pages_Tests_Delete, L("DeleteTest"));

        // Add StudentResult permissions
        var studentResults = context.CreatePermission(PermissionNames.Pages_StudentResults, L("StudentResults"));
        studentResults.CreateChildPermission(PermissionNames.Pages_StudentResults_Create, L("CreateStudentResult"));
        studentResults.CreateChildPermission(PermissionNames.Pages_StudentResults_Edit, L("EditStudentResult"));
        studentResults.CreateChildPermission(PermissionNames.Pages_StudentResults_Delete, L("DeleteStudentResult"));

        // Add SmsNotification permissions
        var smsNotifications = context.CreatePermission(PermissionNames.Pages_SmsNotifications, L("SmsNotifications"));
        smsNotifications.CreateChildPermission(PermissionNames.Pages_SmsNotifications_Create, L("CreateSmsNotification"));
        smsNotifications.CreateChildPermission(PermissionNames.Pages_SmsNotifications_Edit, L("EditSmsNotification"));
        smsNotifications.CreateChildPermission(PermissionNames.Pages_SmsNotifications_Delete, L("DeleteSmsNotification"));

    }

    private static ILocalizableString L(string name)
    {
        return new LocalizableString(name, NIMConsts.LocalizationSourceName);
    }
}
