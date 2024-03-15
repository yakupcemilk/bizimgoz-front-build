using Bizimgoz.Monitoring.Dtos.Hosts;
using Bizimgoz.Monitoring.Dtos.ZabbixGraphs;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Bizimgoz.Monitoring.Dtos.Widgets
{
    public class WidgetDto : FullAuditedEntityDto<Guid>
    {
        public string HostId { get; set; } = string.Empty;
        public ZabbixHostDto? Host { get; set; }
        public string Version { get; set; } = string.Empty;
        public string Serial { get; set; } = string.Empty;
        public bool Status { get; set; }
        public int IncidentCount { get; set; }
        public string Uptime { get; set; } = string.Empty;
        public string CpuItemId { get; set; } = string.Empty;
        public ZabbixItem? CpuItem { get; set; }
        public string RamItemId { get; set; } = string.Empty;
        public ZabbixItem? RamItem { get; set; }
        public string DiskItemId { get; set; } = string.Empty;
        public ZabbixItem? DiskItem { get; set; }
        public List<string> WanInterfaceTrafficIds { get; set; }
        public List<ZabbixItem>? WanInterfaceTrafficItems { get; set; }
        public List<string> InterfacePortTrafficIds { get; set; }
        public List<ZabbixItem>? InterfacePortTrafficItems { get; set; }
    }
}
