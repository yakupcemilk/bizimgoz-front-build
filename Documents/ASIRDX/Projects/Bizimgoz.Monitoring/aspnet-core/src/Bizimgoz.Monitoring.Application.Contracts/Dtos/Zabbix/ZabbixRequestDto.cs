using System.Text.Json.Serialization;

namespace Bizimgoz.Monitoring.Dtos.Zabbix
{
    public class ZabbixRequestDto<paramType>
    {
        public ZabbixRequestDto(string method, paramType Params, string auth)
        {
            this.method = method;
            this.Params = Params;
            this.auth = auth;
        }
        public string jsonrpc { get; set; } = "2.0";
        public string method { get; set; }

        [JsonPropertyName("params")]
        public paramType Params { get; set; }
        public int id { get; set; } = 1;
        public string auth { get; set; } // = "5931ab2ed76d8e34e7e897b6d1f8c522";
    }
}
