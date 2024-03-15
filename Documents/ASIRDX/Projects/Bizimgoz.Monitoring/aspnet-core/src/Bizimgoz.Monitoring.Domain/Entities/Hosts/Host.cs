using Bizimgoz.Monitoring.JsonConverters;
using System;
using System.Text.Json.Serialization;
using Volo.Abp.Domain.Entities.Auditing;

namespace Bizimgoz.Monitoring.Entities.Hosts
{
    public class ZabbixHost : FullAuditedAggregateRoot<Guid>
    {
        /*
        ID of the host.

        Property behavior:
        - read-only
        - required for update operations
        */
        [JsonPropertyName("hostid")]
        public string Hostid { get; set; }

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
        Origin of the host.

        Possible values:
        0 - a plain host;
        4 - a discovered host.

        Property behavior:
        - read-only
        */
        [JsonPropertyName("flags")]
        [JsonConverter(typeof(ParseEnumConverter<HostOrigin>))]
        public HostOrigin Flags { get; set; } = HostOrigin.PlainHost;

        /*
        Host inventory population mode.

        Possible values:
        -1 - (default) disabled;
        0 - manual;
        1 - automatic.
        */
        [JsonPropertyName("inventory_mode")]
        [JsonConverter(typeof(ParseEnumConverter<InventoryMode>))]
        public InventoryMode InventoryMode { get; set; } = InventoryMode.Disabled;

        /*
        IPMI authentication algorithm.

        Possible values:
        -1 - (default) default;
        0 - none;
        1 - MD2;
        2 - MD5
        4 - straight;
        5 - OEM;
        6 - RMCP+.
        */
        [JsonPropertyName("ipmi_authtype")]
        [JsonConverter(typeof(ParseEnumConverter<IpmiAuthtype>))]
        public IpmiAuthtype IpmiAuthtype { get; set; } = IpmiAuthtype.Default;

        /*
        IPMI password.
        */
        [JsonPropertyName("ipmi_password")]
        public string IpmiPassword { get; set; } = string.Empty;

        /*
        IPMI privilege level.

        Possible values:
        1 - callback;
        2 - (default) user;
        3 - operator;
        4 - admin;
        5 - OEM.
        */
        [JsonPropertyName("ipmi_privilege")]
        [JsonConverter(typeof(ParseEnumConverter<IpmiPrivilegeLevel>))]
        public IpmiPrivilegeLevel IpmiPrivilege { get; set; } = IpmiPrivilegeLevel.User;

        /*
        IPMI username.
        */
        [JsonPropertyName("ipmi_username")]
        public string IpmiUsername { get; set; } = string.Empty;

        /*
        Starting time of the effective maintenance.

        Property behavior:
        - read-only
        */
        [JsonPropertyName("maintenance_from")]
        public string MaintenanceFrom { get; set; } = string.Empty;

        /*
        Effective maintenance status.

        Possible values:
        0 - (default) no maintenance;
        1 - maintenance in effect.

        Property behavior:
        - read-only
        */
        [JsonPropertyName("maintenance_status")]
        [JsonConverter(typeof(ParseEnumConverter<MaintenanceStatus>))]
        public MaintenanceStatus MaintenanceStatus { get; set; } = MaintenanceStatus.NoMaintenance;

        /*
        Effective maintenance type.

        Possible values:
        0 - (default) maintenance with data collection;
        1 - maintenance without data collection.

        Property behavior:
        - read-only
        */
        [JsonPropertyName("maintenance_type")]
        [JsonConverter(typeof(ParseEnumConverter<MaintenanceType>))]
        public MaintenanceType MaintenanceType { get; set; } = MaintenanceType.WithDataCollection;

        /*
        ID of the maintenance that is currently in effect on the host.

        Property behavior:
        - read-only
        */
        [JsonPropertyName("maintenanceid")]
        public string Maintenanceid { get; set; } = string.Empty;

        /*
        Visible name of the host.

        Default: host property value.
        */
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /*
        ID of the proxy that is used to monitor the host.
        */
        [JsonPropertyName("proxy_hostid")]
        public string ProxyHostid { get; set; } = string.Empty;

        /*
        Status and function of the host.

        Possible values:
        0 - (default) monitored host;
        1 - unmonitored host.
        */
        [JsonPropertyName("status")]
        [JsonConverter(typeof(ParseEnumConverter<HostStatus>))]
        public HostStatus Status { get; set; } = HostStatus.MonitoredHost;

        /*
        Connections to host.

        Possible values:
        1 - (default) No encryption;
        2 - PSK;
        4 - certificate.
        */
        [JsonPropertyName("tls_connect")]
        [JsonConverter(typeof(ParseEnumConverter<HostConnectionType>))]
        public HostConnectionType TlsConnect { get; set; } = HostConnectionType.NoEncryption;

        /*
        Connections from host.
        This is a bitmask field, any combination of possible bitmap values is acceptable.

        Possible bitmap values:
        1 - (default) No encryption;
        2 - PSK;
        4 - certificate.
        */
        [JsonPropertyName("tls_accept")]
        [JsonConverter(typeof(ParseEnumConverter<HostConnectionType>))]
        public HostConnectionType TlsAccept { get; set; } = HostConnectionType.NoEncryption;

        /*
        Certificate issuer.
        */
        [JsonPropertyName("tls_issuer")]
        public string TlsIssuer { get; set; } = string.Empty;

        /*
        Certificate subject.
        */
        [JsonPropertyName("tls_subject")]
        public string TlsSubject { get; set; } = string.Empty;

        /*
        PSK identity.
        Do not put sensitive information in the PSK identity, it is transmitted unencrypted over the network to inform a receiver which PSK to use.

        Property behavior:
        - write-only
        - required if tls_connect is set to "PSK", or tls_accept contains the "PSK" bit
        */
        [JsonPropertyName("tls_psk_identity")]
        public string? TlsPskIdentity { get; set; } = string.Empty;

        /*
        The preshared key, at least 32 hex digits.

        Property behavior:
        - write-only
        - required if tls_connect is set to "PSK", or tls_accept contains the "PSK" bit
        */
        [JsonPropertyName("tls_psk")]
        public string? TlsPsk { get; set; } = string.Empty;

        /*
        Host active interface availability status.

        Possible values:
        0 - interface status is unknown;
        1 - interface is available;
        2 - interface is not available.

        Property behavior:
        - read-only
        */
        [JsonPropertyName("active_available")]
        [JsonConverter(typeof(ParseEnumConverter<InterfaceAvailabilityStatus>))]
        public InterfaceAvailabilityStatus ActiveAvailable { get; set; } = InterfaceAvailabilityStatus.Unknown;

        public string? Type { get; set; }
    }
}
