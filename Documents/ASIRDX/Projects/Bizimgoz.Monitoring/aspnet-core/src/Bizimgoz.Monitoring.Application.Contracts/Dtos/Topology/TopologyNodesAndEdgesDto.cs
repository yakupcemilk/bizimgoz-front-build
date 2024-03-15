using System.Collections.Generic;

namespace Bizimgoz.Monitoring.Dtos.Topology
{
    public class TopologyNodesAndEdgesDto
    {
        public List<TopologyNodeDto> Nodes { get; set; }
        public List<TopologyEdgeDto> Edges { get; set; }
    }
}
