namespace Bizimgoz.Monitoring.Dtos.Proxies
{
    public class ZabbixProxyDto
    {
        public string? proxyid { get; set; }
        public string? host { get; set; }
        public string? status { get; set; }
        public string? description { get; set; }
        public string? lastaccess { get; set; }
        public string? tls_connect { get; set; }
        public string? tls_accept { get; set; }
        public string? tls_issuer { get; set; }
        public string? tls_subject { get; set; }
        public string? tls_psk_identity { get; set; }
        public string? tls_psk { get; set; }
        public string? proxy_address { get; set; }
        public string? auto_compress { get; set; }
        public string? version { get; set; }
        public string? compatibility { get; set; }

    }
}
