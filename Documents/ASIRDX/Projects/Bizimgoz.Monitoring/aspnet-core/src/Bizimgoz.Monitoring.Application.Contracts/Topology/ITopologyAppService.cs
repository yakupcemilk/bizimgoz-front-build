using Bizimgoz.Monitoring.Dtos.Topology;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Bizimgoz.Monitoring.Topology
{
    public interface ITopologyAppService : IApplicationService
    {
        public Task<TopologyNodesAndEdgesDto> GetAll();

        public Task AddNodes(List<TopologyNodeDto> nodes);
        public Task AddEdges(List<TopologyEdgeDto> edges);

        public Task UpdatePositions(List<TopologyNodeDto> nodes);

        public Task DeleteNodes(List<Guid> nodeIds);
        public Task DeleteEdges(List<Guid> edgeIds);

        public Task DeleteAllNodes();
        public Task DeleteAllEdges();

        public string DeleteDeneme();
        public string CreateDeneme();
        Task<IEnumerable<TopologyNodeDto>> GetNodes();
    }
}
