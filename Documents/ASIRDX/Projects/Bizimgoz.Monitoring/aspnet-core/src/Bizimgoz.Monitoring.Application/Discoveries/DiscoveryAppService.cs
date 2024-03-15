using AutoMapper;
using Bizimgoz.Monitoring.Dtos;
using Bizimgoz.Monitoring.Dtos.Actions;
using Bizimgoz.Monitoring.Dtos.DiscoveredHosts;
using Bizimgoz.Monitoring.Dtos.Discoveries;
using Bizimgoz.Monitoring.Dtos.HostGroups;
using Bizimgoz.Monitoring.Dtos.Proxies;
using Bizimgoz.Monitoring.zabbix;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Bizimgoz.Monitoring.Discoveries
{
    public class DiscoveryAppService : ApplicationService
    {
        private IZabbixAppService _zabbix;

        public DiscoveryAppService(IZabbixAppService zabbix)
        {
            _zabbix = zabbix;
        }

        public async Task<IEnumerable<DiscoveryRuleDto>> Get()
        {
            var drules = await _zabbix.ZabbixGet<DiscoveryRuleDto>("drule.get", new
            {
                output = "extend",
                selectDChecks = "extend"
            });
            var proxies = await _zabbix.ZabbixGet<ZabbixProxyDto>("proxy.get", new
            {
                output = new List<string> { "host" },
                proxyids = drules.Select(drule => drule.proxy_hostid).Distinct().ToList()
            });

            var dhosts = await _zabbix.ZabbixGet<ZabbixDiscoveredHostDto>("dhost.get", new
            {
                output = new List<string> { "druleid" },
            });

            foreach (var drule in drules)
            {
                drule.proxy_hostid = proxies.Find(proxy => proxy.proxyid == drule.proxy_hostid)?.host ?? string.Empty;
                drule.discoveredHostsCount = dhosts.Where(dhost => dhost.druleid == drule.druleid).Count().ToString();
            }
            return drules;
        }
        public async Task<ZabbixResultDto> Create(DiscoveryRuleDto discoveryRule)
        {
            var druleResult = await _zabbix.ZabbixGetSingle<ZabbixResultDto>("drule.create", discoveryRule) ?? new ZabbixResultDto { };
            var hgResult = await _zabbix.ZabbixGetSingle<ZabbixResultDto>("hostgroup.create", new { name = $"HostGroup.Discovery.{discoveryRule.name}" }) ?? new ZabbixResultDto { };
            var actionToBeCreated = new ZabbixActionsDto
            {
                eventsource = "1",
                name = $"Action.Discovery.{discoveryRule.name}",
                filter = new ZabbixActionFilterDto
                {
                    conditions = new List<ZabbixActionFilterConditionDto>{
                        new ZabbixActionFilterConditionDto{
                            conditiontype="18",// Discovery Rule
                            value= druleResult.druleids?.FirstOrDefault(),
                            // value2="",
                            // formulaid="A"
                            Operator = "0",

                        },
                    },
                    evaltype = "0",
                    // eval_formula = "A",
                    // formula = ""
                },
                operations = new List<ZabbixActionOperationDto> {
                    new ZabbixActionOperationDto{ operationtype = "2" /* add host */ },
                    new ZabbixActionOperationDto{
                        operationtype = "4",// add to host group
                        opgroup = new List<HostgroupsDto>{
                            new HostgroupsDto { groupid = hgResult.groupids?.FirstOrDefault() }
                        }
                    }
                }
            };
            var actionResult = await _zabbix.ZabbixGetSingle<ZabbixResultDto>("action.create", actionToBeCreated) ?? new ZabbixResultDto { };
            return new ZabbixResultDto
            {
                actionids = actionResult.actionids,
                druleids = druleResult.druleids,
                groupids = hgResult.groupids
            };
        }
        public async Task<ZabbixResultDto?> UpdateStatus(string druleid, string status)
        {
            var result = await _zabbix.ZabbixGetSingle<ZabbixResultDto>("drule.update", new { druleid, status });
            return result;
        }
        public async Task<ZabbixResultDto> Delete(string druleid)
        {
            var drules = await _zabbix.ZabbixGet<DiscoveryRuleDto>("drule.get", new { druleids = new List<string> { druleid } });
            // var hgResult = await _zabbix.ZabbixGetSingle<ZabbixResultDto>("hostgroup.create", new { name = $"HostGroup.Discovery.{discoveryRule.name}" }) ?? new ZabbixResultDto { };

            var allActions = await _zabbix.ZabbixGet<ZabbixActionsDto>("action.get", new
            {
                output = "extend",
                selectOperations = "extend",
                selectRecoveryOperations = "extend",
                selectUpdateOperations = "extend",
                selectFilter = "extend"
            });

            var dactions = allActions
                .Where(actionResult => actionResult.name.StartsWith("Action.Discovery.") && actionResult
                    .filter
                    .conditions.Any(condition => condition.conditiontype == "18" && condition.value == drules.FirstOrDefault()?.druleid)
                )
                .ToList();

            var groupids = dactions.SelectMany(daction => daction
            .operations
            .Where(operation => operation.operationtype == "4")
            .SelectMany(operation => operation.opgroup.Select(group => group.groupid))
            ).ToList();

            var actionDeleteResult = await _zabbix.ZabbixGetSingle<ZabbixResultDto>("action.delete", dactions.Select(daction => daction.actionid).ToList());
            var hgDeleteResult = await _zabbix.ZabbixGetSingle<ZabbixResultDto>("hostgroup.delete", groupids);
            var druleDeleteResult = await _zabbix.ZabbixGetSingle<ZabbixResultDto>("drule.delete", drules.Select(drule=> drule.druleid).ToList());

            return new ZabbixResultDto
            {
                actionids = actionDeleteResult.actionids,
                druleids = druleDeleteResult.druleids,
                groupids = hgDeleteResult.groupids
            };
        }

        public async Task<IEnumerable<dynamic>> GetActionsDynamic()
        {
            return await _zabbix.ZabbixGet<dynamic>("action.get", new
            {
                output = "extend",
                selectOperations = "extend",
                selectRecoveryOperations = "extend",
                selectUpdateOperations = "extend",
                selectFilter = "extend"
            });
        }
        public async Task<IEnumerable<ZabbixActionsDto>> GetActions()
        {
            return await _zabbix.ZabbixGet<ZabbixActionsDto>("action.get", new
            {
                output = "extend",
                selectOperations = "extend",
                selectRecoveryOperations = "extend",
                selectUpdateOperations = "extend",
                selectFilter = "extend"
            });
        }
    }
}
