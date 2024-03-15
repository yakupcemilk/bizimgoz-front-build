using Bizimgoz.Monitoring.Entities.Hosts;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Bizimgoz.Monitoring.Entities.Topology
{
    public class TopologyNode : FullAuditedAggregateRoot<Guid>
    {
        public Guid HostId { get; set; }
        public virtual ZabbixHost? Host { get; set; }

        public virtual NodePosition Position { get; set; }
        public string? Status { get; set; }
        public string? DeviceType { get; set; }
    }
}