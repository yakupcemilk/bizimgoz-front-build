using System.Threading.Tasks;

namespace Bizimgoz.Monitoring.Data;

public interface IMonitoringDbSchemaMigrator
{
    Task MigrateAsync();
}
