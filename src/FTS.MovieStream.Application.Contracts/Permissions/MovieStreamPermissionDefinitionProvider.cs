using FTS.MovieStream.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FTS.MovieStream.Permissions;

public class MovieStreamPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MovieStreamPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MovieStreamPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MovieStreamResource>(name);
    }
}
