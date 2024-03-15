using System.Collections.Generic;

namespace Bizimgoz.Monitoring.Dtos.Discoveries
{
    public class DiscoveryRuleDto
    {
        public string? druleid { get; set; }
        public string? iprange { get; set; }
        public string? name { get; set; }
        public string? delay { get; set; }
        public string? proxy_hostid { get; set; }
        public string? status { get; set; }
        public List<DiscoveryCheckDto>? dchecks { get; set; }
        public string? discoveredHostsCount { get; set; }
    }
}
