using Bizimgoz.Monitoring.Samples;
using Xunit;

namespace Bizimgoz.Monitoring.EntityFrameworkCore.Domains;

[Collection(MonitoringTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<MonitoringEntityFrameworkCoreTestModule>
{

}
