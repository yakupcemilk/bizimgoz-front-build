using Bizimgoz.Monitoring.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Modularity;

namespace Bizimgoz.Monitoring.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(MonitoringEntityFrameworkCoreModule),
    typeof(MonitoringApplicationContractsModule)
    )]
public class MonitoringDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "Monitoring:"; });
    }
}
