using Bizimgoz.Monitoring.Dtos.Hosts;
using Bizimgoz.Monitoring.Dtos.ZabbixGraphs;

namespace Bizimgoz.Monitoring.Dtos.FirewallDashboards
{
    public class FirewallDashboard
    {
        public ZabbixHostDto host { get; set; }
        public string NameKey { get; set; }
        public ZabbixItem? Name { get; set; }

        public string IPAddressKey { get; set; }
        public ZabbixItem? IPAddress { get; set; }

        public string SerialKey { get; set; }
        public ZabbixItem? Serial { get; set; }

        public string ODModelKey { get; set; }
        public ZabbixItem? ODModel { get; set; }

        public string OsVersionKey { get; set; }
        public ZabbixItem? OsVersion { get; set; }

        public string CpuKey { get; set; }
        public ZabbixItem? Cpu { get; set; }

        public string MemUsedKey { get; set; }
        public ZabbixItem? MemUsed { get; set; }

        public string LoadKey { get; set; }
        public ZabbixItem? Load { get; set; }

        public string DiskUsedKey { get; set; }
        public ZabbixItem? DiskUsed { get; set; }

        public string StatusKey { get; set; }
        public ZabbixItem? Status { get; set; }

        public string UptimeKey { get; set; }
        public ZabbixItem? Uptime { get; set; }

        public string ConnectUsersKey { get; set; }
        public ZabbixItem? ConnectUsers { get; set; }

        public string ProcessesKey { get; set; }
        public ZabbixItem? Processes { get; set; }

        public string ActiveSessionsKey { get; set; }
        public ZabbixItem? ActiveSessions { get; set; }

        public string VpnCountKey { get; set; }
        public ZabbixItem? VpnCount { get; set; }

        public string IntrusionsBlockedKey { get; set; }
        public ZabbixItem? IntrusionsBlocked { get; set; }

        public string IntrusionsDetectedAnomalyBasedKey { get; set; }
        public ZabbixItem? IntrusionsDetectedAnomalyBased { get; set; }
    }
}
