using Abp.Authorization;
using NIM.Authorization.Roles;
using NIM.Authorization.Users;

namespace NIM.Authorization;

public class PermissionChecker : PermissionChecker<Role, User>
{
    public PermissionChecker(UserManager userManager)
        : base(userManager)
    {
    }
}
