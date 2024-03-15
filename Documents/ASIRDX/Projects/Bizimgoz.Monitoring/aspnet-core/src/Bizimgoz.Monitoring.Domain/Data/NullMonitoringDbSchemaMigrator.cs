using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Bizimgoz.Monitoring.Data;

/* This is used if database provider does't define
 * IMonitoringDbSchemaMigrator implementation.
 */
public class NullMonitoringDbSchemaMigrator : IMonitoringDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
