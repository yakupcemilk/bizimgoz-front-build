using System;

namespace Bizimgoz.Monitoring.Dtos.Interfaces
{
    public class InterfaceDto
    {
        public string? interfaceid { get; set; }
        public string? available { get; set; }
        public string? hostid { get; set; }
        public string? type { get; set; }
        public string? ip { get; set; }
        public string? dns { get; set; }
        public string? port { get; set; }
        public string? useip { get; set; }
        public string? main { get; set; }
        // public array? details { get; set; }
        public string? disable_until { get; set; }
        public string? error { get; set; }
        public string? errors_from { get; set; }

    }
}
