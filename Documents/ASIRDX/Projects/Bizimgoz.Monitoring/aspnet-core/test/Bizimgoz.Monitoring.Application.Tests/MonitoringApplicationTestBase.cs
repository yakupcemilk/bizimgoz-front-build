using Volo.Abp.Modularity;

namespace Bizimgoz.Monitoring;

public abstract class MonitoringApplicationTestBase<TStartupModule> : MonitoringTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
