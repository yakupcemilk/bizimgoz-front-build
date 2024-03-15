using Bizimgoz.Monitoring.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Bizimgoz.Monitoring.Permissions
{
    public class ExamplePermissionDefinition : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup("ExamplePermission");

            myGroup.AddPermission("ExamplePermission_permission1");
            myGroup.AddPermission("ExamplePermission_permission2");

        }
        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MonitoringResource>(name);
        }
    }
}
