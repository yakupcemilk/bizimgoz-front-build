using Bizimgoz.Monitoring.Dtos.ZabbixGraphs;
using Bizimgoz.Monitoring.zabbix;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Bizimgoz.Monitoring.ZabbixGraphs
{
    public class ZabbixGraphAppService : ApplicationService, IZabbixGraphAppService
    {
        private IZabbixAppService _zabbix;

        public ZabbixGraphAppService(IZabbixAppService zabbix)
        {
            _zabbix = zabbix;
        }

        public async Task<IEnumerable<ZabbixGraph>> GetAllAsync(
            List<string> groupids, 
            List<string> graphids,
            List<string> itemids, 
            List<string> hostids,
            string limit
            )
        {
            var graphs = await _zabbix.ZabbixGet<ZabbixGraph>("graph.get", new
            {
                groupids = groupids.IsNullOrEmpty() ? null : groupids,
                graphids = graphids.IsNullOrEmpty() ? null : graphids,
                itemids = itemids.IsNullOrEmpty() ? null : itemids,
                hostids = hostids.IsNullOrEmpty() ? null : hostids,
            });

            foreach (var graph in graphs)
            {
                graph.Gitems = await _zabbix.ZabbixGet<ZabbixGraphItem>("graphitem.get", new { graphids = graph.graphid });

                foreach (var graphItem in graph.Gitems)
                {
                    graphItem.item = (await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { itemids = graphItem.itemid })).FirstOrDefault();

                    graphItem.item.histories = await _zabbix
                        .ZabbixGet<ZabbixHistory>("history.get", new {
                            limit,
                            itemids = graphItem.item.itemid,
                            sortfield= "clock",
                            sortorder= "DESC",
                        });
                    graphItem.item.histories.Reverse();
                }
            }

            return graphs;
        }
    }
}
