using Volo.Abp.Modularity;

namespace Bizimgoz.Monitoring;

[DependsOn(
    typeof(MonitoringApplicationModule),
    typeof(MonitoringDomainTestModule)
)]
public class MonitoringApplicationTestModule : AbpModule
{

}
