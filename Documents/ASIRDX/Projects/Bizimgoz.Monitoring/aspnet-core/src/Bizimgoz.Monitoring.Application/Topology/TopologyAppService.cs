using Bizimgoz.Monitoring.Dtos.Topology;
using Bizimgoz.Monitoring.Entities.Topology;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Bizimgoz.Monitoring.Topology
{
    public class TopologyAppService : ApplicationService, ITopologyAppService
    {
        private IRepository<TopologyEdge, Guid> _edgeRepository;
        private IRepository<TopologyNode, Guid> _nodeRepository;

        public TopologyAppService(
            IRepository<TopologyEdge, Guid> edgeRepository,
            IRepository<TopologyNode, Guid> nodeRepository)
        {
            _edgeRepository = edgeRepository;
            _nodeRepository = nodeRepository;
        }
        public async Task<TopologyNodesAndEdgesDto> GetAll()
        {
            var edges = await _edgeRepository.GetListAsync(t => true, true);
            var nodes = await _nodeRepository.GetListAsync(t => true, true);
            File.WriteAllText("nodes.json", JsonSerializer.Serialize(nodes));
            return new TopologyNodesAndEdgesDto
            {
                Edges = edges.Select(e => ObjectMapper.Map<TopologyEdge, TopologyEdgeDto>(e)).ToList(),
                Nodes = nodes.Select(e => ObjectMapper.Map<TopologyNode, TopologyNodeDto>(e)).ToList()
            };
        }

        // The nodes returned without hosts, will be used to check which hosts are present in the topology
        public async Task<IEnumerable<TopologyNodeDto>> GetNodes()
        {
            var nodes = await _nodeRepository.GetListAsync(t => true);
            return nodes.Select(e => ObjectMapper.Map<TopologyNode, TopologyNodeDto>(e));
        }
        public Task AddEdges(List<TopologyEdgeDto> edges)
        {
            var edgesList = edges.Select(e => ObjectMapper.Map<TopologyEdgeDto, TopologyEdge>(e));
            return _edgeRepository.InsertManyAsync(edgesList, true);
        }

        public Task AddNodes(List<TopologyNodeDto> nodes)
        {
            var nodeList = nodes.Select(e => ObjectMapper.Map<TopologyNodeDto, TopologyNode>(e));
            File.WriteAllText("nodes.json", JsonSerializer.Serialize(nodeList));
            return _nodeRepository.InsertManyAsync(nodeList, true);
        }

        public Task DeleteAllEdges() => _edgeRepository.DeleteDirectAsync(t => true);

        public Task DeleteAllNodes() => _nodeRepository.DeleteDirectAsync(t => true);

        public Task DeleteEdges(List<Guid> edgeIds) => _edgeRepository.DeleteManyAsync(edgeIds, true);

        public Task DeleteNodes(List<Guid> nodeIds) => _edgeRepository.DeleteManyAsync(nodeIds, true);

        public async Task UpdatePositions(List<TopologyNodeDto> nodes)
        {
            var ids = nodes.Select(node => node.Id);
            var dbNodes = await _nodeRepository.GetListAsync(t => ids.Contains(t.Id), true);
            dbNodes.ForEach(dbNode =>
            {
                var pos = ObjectMapper.Map<NodePositionDto, NodePosition>(nodes.First(t => t.Id == dbNode.Id).Position);
                dbNode.Position = pos;
            });
            return;
        }

        // [Authorize($"{MonitoringPermissions.GroupName}.ZabbixHost.ProductDeletion")]
        public string DeleteDeneme()
        {
            return "ProductDeletion is returned";
        }

        // [Authorize($"{MonitoringPermissions.GroupName}.ZabbixHost.ProductCreation")]
        public string CreateDeneme()
        {
            return "ProductCreation is returned";
        }
    }
}
