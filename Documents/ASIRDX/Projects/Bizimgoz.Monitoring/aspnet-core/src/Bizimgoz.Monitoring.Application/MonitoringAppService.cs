using System;
using System.Collections.Generic;
using System.Text;
using Bizimgoz.Monitoring.Localization;
using Volo.Abp.Application.Services;

namespace Bizimgoz.Monitoring;

/* Inherit your application services from this class.
 */
public abstract class MonitoringAppService : ApplicationService
{
    protected MonitoringAppService()
    {
        LocalizationResource = typeof(MonitoringResource);
    }
}
