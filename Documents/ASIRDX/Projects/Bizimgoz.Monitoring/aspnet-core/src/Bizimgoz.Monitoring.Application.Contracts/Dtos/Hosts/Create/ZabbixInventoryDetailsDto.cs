using Bizimgoz.Monitoring.Entity.Host.Create;

namespace Bizimgoz.Monitoring.Dtos.Hosts.Create
{
    public class ZabbixInventoryDetailsDto
    {
        public ZabbixVersion version { get; set; }
        public ZabbixBulk bulk { get; set; } = ZabbixBulk.DontUseBulkRequests;
        public string? community { get; set; }
        public int? max_repetitions { get; set; } = 10;
        public string? securityname { get; set; }
        public ZabbixSecuritylevel? securitylevel { get; set; } = ZabbixSecuritylevel.noAuthNoPriv;
        public string? authpassphrase { get; set; }
        public string? privpassphrase { get; set; }
        public ZabbixAuthprotocol? authprotocol { get; set; }
        public ZabbixPrivprotocol? privprotocol { get; set; }
        public string? contextname { get; set; }
    }
}