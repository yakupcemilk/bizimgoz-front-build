namespace Bizimgoz.Monitoring.Dtos.Zabbix
{
    public class ZabbixErrorDto
    {
        /*
         "error": {
            "code": -32602,
            "message": "Invalid params.",
            "data": "No groups for host \"Linux server\"."
        }
        */
        public int code { get; set; }
        public string message { get; set; }
        public string data { get; set; }
    }
}