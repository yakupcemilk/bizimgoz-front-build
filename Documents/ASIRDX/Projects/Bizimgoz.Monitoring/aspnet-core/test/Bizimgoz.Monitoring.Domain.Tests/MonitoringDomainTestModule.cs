using Volo.Abp.Modularity;

namespace Bizimgoz.Monitoring;

[DependsOn(
    typeof(MonitoringDomainModule),
    typeof(MonitoringTestBaseModule)
)]
public class MonitoringDomainTestModule : AbpModule
{

}
