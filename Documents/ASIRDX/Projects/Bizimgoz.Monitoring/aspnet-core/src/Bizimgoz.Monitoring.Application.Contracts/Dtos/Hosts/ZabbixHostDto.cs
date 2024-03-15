using System;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;

namespace Bizimgoz.Monitoring.Dtos.Hosts
{
    public class ZabbixHostDto : FullAuditedEntityDto<Guid>
    {
        /*
        ID of the host.

        Property behavior:
        - read-only
        - required for update operations
        */
        [JsonPropertyName("hostid")]
        public string? Hostid { get; set; }

        /*
        Technical name of the host.

        Property behavior:
        - required for create operations
        */
        [JsonPropertyName("host")]
        public string HostName { get; set; }

        /*
        Description of the host.
        */
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /*
        Visible name of the host.

        Default: host property value.
        */
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /*
        ID of the proxy that is used to monitor the host.
        */
        [JsonPropertyName("proxy_hostid")]
        public string? ProxyHostid { get; set; }
        public string? Type { get; set; }
    }
}
