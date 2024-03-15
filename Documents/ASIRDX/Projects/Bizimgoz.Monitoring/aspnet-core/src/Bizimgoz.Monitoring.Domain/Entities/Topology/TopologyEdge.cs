using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Bizimgoz.Monitoring.Entities.Topology
{
    public class TopologyEdge : FullAuditedAggregateRoot<Guid>
    {
        public Guid SourceId { get; set; }
        public virtual TopologyNode? Source { get; set; }

        public Guid TargetId { get; set; }
        public virtual TopologyNode? Target { get; set; }
        public string? Status { get; set; }
    }
}
