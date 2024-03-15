using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Bizimgoz.Monitoring;

[Dependency(ReplaceServices = true)]
public class MonitoringBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Monitoring";
}
