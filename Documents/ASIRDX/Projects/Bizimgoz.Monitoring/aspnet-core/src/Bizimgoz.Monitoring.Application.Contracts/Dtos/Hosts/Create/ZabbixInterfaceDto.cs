using Bizimgoz.Monitoring.Entity.Host.Create;

namespace Bizimgoz.Monitoring.Dtos.Hosts.Create
{
    public class ZabbixInterfaceDto
    {
        public string? interfaceid { get; set; }
        public ZabbixAvailable? available { get; set; }
        public string? hostid { get; set; }
        public ZabbixType? type { get; set; }
        public string? ip { get; set; }
        public string? dns { get; set; }
        public string? port { get; set; }
        public ZabbixUseip? useip { get; set; }
        public ZabbixMain? main { get; set; }
        public ZabbixInventoryDetailsDto? details { get; set; }
        public string? disable_until { get; set; }
        public string? error { get; set; }
        public string? errors_from { get; set; }
    }
}