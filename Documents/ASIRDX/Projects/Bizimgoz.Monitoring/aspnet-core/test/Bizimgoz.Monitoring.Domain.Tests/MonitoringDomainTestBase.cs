using Volo.Abp.Modularity;

namespace Bizimgoz.Monitoring;

/* Inherit from this class for your domain layer tests. */
public abstract class MonitoringDomainTestBase<TStartupModule> : MonitoringTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
