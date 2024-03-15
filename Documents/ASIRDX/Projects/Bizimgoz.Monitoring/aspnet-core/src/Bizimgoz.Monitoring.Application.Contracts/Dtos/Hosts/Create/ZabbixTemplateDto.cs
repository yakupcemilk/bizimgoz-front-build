namespace Bizimgoz.Monitoring.Dtos.Hosts.Create
{
    public class ZabbixTemplateDto
    {
        public string? templateid { get; set; }
        public string? host { get; set; }
        public string? description { get; set; }
        public string? name { get; set; }
        public string? uuid { get; set; }
        public string? vendor_name { get; set; }
        public string? vendor_version { get; set; }
    }
}