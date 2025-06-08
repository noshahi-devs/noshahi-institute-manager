namespace NIM.Authorization;

public static class PermissionNames
{
    public const string Pages_Tenants = "Pages.Tenants";

    public const string Pages_Users = "Pages.Users";
    public const string Pages_Users_Activation = "Pages.Users.Activation";

    public const string Pages_Roles = "Pages.Roles";

    // ➕ Add Campus-related permissions
    public const string Pages_Campuses = "Pages.Campuses";
    public const string Pages_Campuses_Create = "Pages.Campuses.Create";
    public const string Pages_Campuses_Edit = "Pages.Campuses.Edit";
    public const string Pages_Campuses_Delete = "Pages.Campuses.Delete";

    // ➕ Add Class-related permissions
    public const string Pages_Classes = "Pages.Classes";
    public const string Pages_Classes_Create = "Pages.Classes.Create";
    public const string Pages_Classes_Edit = "Pages.Classes.Edit";
    public const string Pages_Classes_Delete = "Pages.Classes.Delete";

    // ➕ Add Section-related permissions
    public const string Pages_Sections = "Pages.Sections";
    public const string Pages_Sections_Create = "Pages.Sections.Create";
    public const string Pages_Sections_Edit = "Pages.Sections.Edit";
    public const string Pages_Sections_Delete = "Pages.Sections.Delete";
}
