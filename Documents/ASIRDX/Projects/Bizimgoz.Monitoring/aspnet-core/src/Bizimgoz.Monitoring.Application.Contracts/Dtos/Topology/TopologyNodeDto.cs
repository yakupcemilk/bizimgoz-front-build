using System;
using Volo.Abp.Application.Dtos;
using Bizimgoz.Monitoring.Dtos.Hosts;

namespace Bizimgoz.Monitoring.Dtos.Topology
{
    public class TopologyNodeDto : FullAuditedEntityDto<Guid>
    {
        public Guid HostId { get; set; }
        public virtual ZabbixHostDto? Host { get; set; }

        public virtual NodePositionDto Position { get; set; }
        public string? Status { get; set; }
        public string? DeviceType { get; set; }
    }
}