using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Bizimgoz.Monitoring.Entities.Widgets
{
    public class Widget : FullAuditedAggregateRoot<Guid>
    {
        public string HostId { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string Serial { get; set; } = string.Empty;
        public bool Status { get; set; }
        public string Uptime { get; set; } = string.Empty;
        public string CpuItemId { get; set; } = string.Empty;
        public string RamItemId { get; set; } = string.Empty;
        public string DiskItemId { get; set; } = string.Empty;
        public List<string> WanInterfaceTrafficIds { get; set; }
        public List<string> InterfacePortTrafficIds { get; set; }
    }
}
