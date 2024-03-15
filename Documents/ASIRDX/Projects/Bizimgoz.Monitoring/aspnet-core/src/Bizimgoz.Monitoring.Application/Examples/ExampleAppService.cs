using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Volo.Abp.Application.Services;

namespace Bizimgoz.Monitoring.Examples
{
    public class ExampleAppService : ApplicationService
    {
        [Authorize("ExamplePermission_permission1")]
        public List<string> endpoint1() => ["Bu", "endpoint1", "sonucudur"];
        [Authorize("ExamplePermission_permission2")]
        public List<string> endpoint2() => ["Bu", "endpoint2", "sonucudur"];
    }
}
