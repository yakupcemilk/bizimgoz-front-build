using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bizimgoz.Monitoring.Data;
using Volo.Abp.DependencyInjection;

namespace Bizimgoz.Monitoring.EntityFrameworkCore;

public class EntityFrameworkCoreMonitoringDbSchemaMigrator
    : IMonitoringDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMonitoringDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the MonitoringDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MonitoringDbContext>()
            .Database
            .MigrateAsync();
    }
}
