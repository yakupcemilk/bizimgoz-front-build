using System;
using System.Collections.Generic;
using System.Text;

namespace Bizimgoz.Monitoring.Dtos.ZabbixGraphs
{
    public class GetZabbixGraphParameters
    {
        public List<string> graphids { get; set; } = new List<string>();
        public List<string> groupids { get; set; } = new List<string>();
        public List<string> hostids { get; set; } = new List<string>();
        public List<string> itemids { get; set; } = new List<string>();
        public string HistoryLimit { get; set; } = string.Empty;
    }
}
