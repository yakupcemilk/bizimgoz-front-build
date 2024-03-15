using Bizimgoz.Monitoring.Dtos.Hosts;
using Bizimgoz.Monitoring.Dtos.Incidents;
using Bizimgoz.Monitoring.Dtos.Interfaces;
using Bizimgoz.Monitoring.Dtos.Problems;
using Bizimgoz.Monitoring.Helpers.TimeStampConverters;
using Bizimgoz.Monitoring.zabbix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Bizimgoz.Monitoring.Incidents
{
    public class IncidentAppService : ApplicationService, IIncidentAppService
    {
        private IZabbixAppService _zabbix;
        private TimeStampConverter _timeStampConverter;

        public IncidentAppService(IZabbixAppService zabbix, TimeStampConverter timeStampConverter)
        {
            _zabbix = zabbix;
            _timeStampConverter = timeStampConverter;
        }
        public async Task<IEnumerable<ZabbixProblemDto>> Get(List<int> severities = default)
        {
            if (severities == default) severities = new List<int>();
            var problems = new List<ZabbixProblemDto>();
            var hosts = (await _zabbix.ZabbixGet<ZabbixHostDto>("host.get",
                severities.Count == 0 ? new
                {
                    withProblemsSuppressed = false,
                    output = new List<string> { "host", "description", "name", "proxy_hostid" }
                } : new
                {
                    withProblemsSuppressed = false,
                    output = new List<string> { "host", "description", "name", "proxy_hostid" },
                    severities
                }));
            foreach (var host in hosts)
            {
                var hostsProblems = (await _zabbix.ZabbixGet<ZabbixProblemDto>("problem.get",
                    severities.Count == 0 ? new
                    {
                        hostids = new List<string> { host.Hostid },
                        output = "extend",
                        selectAcknowledges = "extend",
                        selectTags = "extend",
                        selectSuppressionData = "extend"
                    } : new
                    {
                        severities,
                        hostids = new List<string> { host.Hostid },
                        output = "extend",
                        selectAcknowledges = "extend",
                        selectTags = "extend",
                        selectSuppressionData = "extend"
                    }));
                foreach (var hostsProblem in hostsProblems)
                {
                    hostsProblem.Host = host;
                    hostsProblem.severity = hostsProblem.severity switch
                    {
                        "0" => "not classified",
                        "1" => "information",
                        "2" => "warning",
                        "3" => "average",
                        "4" => "high",
                        "5" => "disaster",
                        _ => "undefined",
                    };
                    hostsProblem.clock = _timeStampConverter.Convert(hostsProblem.clock);
                }
                problems.AddRange(hostsProblems);
            }
            return problems;
        }

        public async Task<CreateAcknowledgeResultDto> CreateAcknowledge(CreateAcknowledgeDto dto) => await _zabbix.ZabbixGetSingle<CreateAcknowledgeResultDto>("event.acknowledge", dto);

        public async Task<IncidentTableValues> GetSystemInformation()
        {
            try
            {
                var values = new IncidentTableValues();
                values.HostAvailability = new HostAvailability();
                var interfaces = await _zabbix.ZabbixGet<InterfaceDto>("hostinterface.get", new { });
                foreach (var TheInterface in interfaces)
                {
                    if (TheInterface.available == "0") values.HostAvailability.Unknown++;
                    if (TheInterface.available == "1") values.HostAvailability.Available++;
                    if (TheInterface.available == "2") values.HostAvailability.Unavailable++;
                }
                values.NumberOfTemplates = int.Parse(await _zabbix.ZabbixGetSingle<string>("template.get", new { countOutput = true }) ?? " - 1");
                var incidentHosts = (await _zabbix.ZabbixGet<IncidentHostDto>("host.get", new { output = new List<string> { "status" } }));
                values.NumberOfHosts = new List<int>
                {
                    incidentHosts.Count,
                    incidentHosts.Where(host=>host.status == "0").Count(),
                    incidentHosts.Where(host=>host.status == "1").Count()
                };

                var triggers = (await _zabbix.ZabbixGet<IncidentTriggerDto>("trigger.get", new { output = new List<string> { "status", "value" }, templated = true }));
                values.NumberOfTriggers = new List<int>
                {
                    triggers.Count,
                    triggers.Where(trigger=>trigger.status == "0").Count(),
                    triggers.Where(trigger=>trigger.status == "1").Count(),
                    triggers.Where(trigger=>trigger.value == "1").Count(),
                    triggers.Where(trigger=>trigger.value == "0").Count()
                };

                values.ServerUrl = "localhost:10051";
                return values;
            }
            catch (Exception e)
            {
                throw new UserFriendlyException($"getHostAvailability: {e.Message}");
            }

        }
    }
}
