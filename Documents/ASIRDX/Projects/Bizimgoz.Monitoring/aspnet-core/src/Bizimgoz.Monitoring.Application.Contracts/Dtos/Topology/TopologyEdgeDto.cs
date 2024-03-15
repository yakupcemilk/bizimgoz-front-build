using System;
using Volo.Abp.Application.Dtos;

namespace Bizimgoz.Monitoring.Dtos.Topology
{
    public class TopologyEdgeDto : FullAuditedEntityDto<Guid>
    {
        public Guid SourceId { get; set; }
        public virtual TopologyNodeDto? Source { get; set; }

        public Guid TargetId { get; set; }
        public virtual TopologyNodeDto? Target { get; set; }
        public string? Status { get; set; }
    }
}
