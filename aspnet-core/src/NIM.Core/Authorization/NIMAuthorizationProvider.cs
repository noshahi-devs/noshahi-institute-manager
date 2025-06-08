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

    }

    private static ILocalizableString L(string name)
    {
        return new LocalizableString(name, NIMConsts.LocalizationSourceName);
    }
}
