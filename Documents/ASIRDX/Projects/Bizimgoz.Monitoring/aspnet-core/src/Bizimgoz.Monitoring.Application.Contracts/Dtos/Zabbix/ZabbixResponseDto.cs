using System;
using System.Collections.Generic;
using System.Text;

namespace Bizimgoz.Monitoring.Dtos.Zabbix
{
    public class ZabbixResponseDto<ResultType>
    {
        public string jsonrpc { get; set; } = "2.0";
        public ResultType? result { get; set; }
        public ZabbixErrorDto? error { get; set; }
        public int id { get; set; } = 1;
    }
}
