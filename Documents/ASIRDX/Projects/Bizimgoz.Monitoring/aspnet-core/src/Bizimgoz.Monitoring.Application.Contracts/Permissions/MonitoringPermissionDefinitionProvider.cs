using Bizimgoz.Monitoring.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Bizimgoz.Monitoring.Permissions;

public class MonitoringPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MonitoringPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MonitoringPermissions.MyPermission1, L("Permission:MyPermission1"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MonitoringResource>(name);
    }
}
