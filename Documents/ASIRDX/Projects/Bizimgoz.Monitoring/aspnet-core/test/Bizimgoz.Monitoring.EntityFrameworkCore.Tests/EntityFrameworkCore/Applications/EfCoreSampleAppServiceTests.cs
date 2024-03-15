using Bizimgoz.Monitoring.Samples;
using Xunit;

namespace Bizimgoz.Monitoring.EntityFrameworkCore.Applications;

[Collection(MonitoringTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<MonitoringEntityFrameworkCoreTestModule>
{

}
