using Volo.Abp.Settings;

namespace Bizimgoz.Monitoring.Settings;

public class MonitoringSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MonitoringSettings.MySetting1));
    }
}
