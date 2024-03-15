using Bizimgoz.Monitoring.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Bizimgoz.Monitoring.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MonitoringController : AbpControllerBase
{
    protected MonitoringController()
    {
        LocalizationResource = typeof(MonitoringResource);
    }
}
