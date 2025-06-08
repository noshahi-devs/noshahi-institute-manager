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

        // Add Principal permissions
        var principals = context.CreatePermission(PermissionNames.Pages_Principals, L("Principals"));
        principals.CreateChildPermission(PermissionNames.Pages_Principals_Create, L("CreatePrincipal"));
        principals.CreateChildPermission(PermissionNames.Pages_Principals_Edit, L("EditPrincipal"));
        principals.CreateChildPermission(PermissionNames.Pages_Principals_Delete, L("DeletePrincipal"));
    }

    private static ILocalizableString L(string name)
    {
        return new LocalizableString(name, NIMConsts.LocalizationSourceName);
    }
}
