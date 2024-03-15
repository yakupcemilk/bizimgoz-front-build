using System;
using Volo.Abp.Domain.Entities;

namespace Bizimgoz.Monitoring.Entities.Topology
{
    public class NodePosition : BasicAggregateRoot<Guid>
    {
        public float X { get; set; }
        public float Y { get; set; }
    }
}