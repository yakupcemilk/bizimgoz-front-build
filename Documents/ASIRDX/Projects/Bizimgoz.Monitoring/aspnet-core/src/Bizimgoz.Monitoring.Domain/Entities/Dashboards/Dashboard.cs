using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Bizimgoz.Monitoring.Entities.Dashboards
{
    public class Dashboard : FullAuditedAggregateRoot<Guid>
    {
        public string name { get; set; }
        public string Purpose { get; set; }
        public List<string>? Options { get; set; }
        public List<DashboardElement> Elements { get; set; }
    }
}
