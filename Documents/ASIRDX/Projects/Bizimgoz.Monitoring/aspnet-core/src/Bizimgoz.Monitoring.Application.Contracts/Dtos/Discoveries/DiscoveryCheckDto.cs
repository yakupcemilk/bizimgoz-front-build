namespace Bizimgoz.Monitoring.Dtos.Discoveries
{
    public class DiscoveryCheckDto
    {
        public string? dcheckid { get; set; }
        public string? druleid { get; set; }
        public string? key_ { get; set; }
        public string? ports { get; set; }
        public string? snmp_community { get; set; }
        public string? snmpv3_authpassphrase { get; set; }
        public string? snmpv3_authprotocol { get; set; }
        public string? snmpv3_contextname { get; set; }
        public string? snmpv3_privpassphrase { get; set; }
        public string? snmpv3_privprotocol { get; set; }
        public string? snmpv3_securitylevel { get; set; }
        public string? snmpv3_securityname { get; set; }
        public string? type { get; set; }
        public string? uniq { get; set; }
        public string? host_source { get; set; }
        public string? name_source { get; set; }
    }
}
