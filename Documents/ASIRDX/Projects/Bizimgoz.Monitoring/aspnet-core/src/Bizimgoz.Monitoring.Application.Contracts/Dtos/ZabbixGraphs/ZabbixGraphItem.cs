using System;
using System.Collections.Generic;
using System.Text;

namespace Bizimgoz.Monitoring.Dtos.ZabbixGraphs
{
    public class ZabbixGraphItem
    {
        public string? gitemid { get; set; }
        public string? color { get; set; }
        public string? itemid { get; set; }
        public string? calc_fnc { get; set; }
        public string? drawtype { get; set; }
        public string? graphid { get; set; }
        public string? sortorder { get; set; }
        public string? type { get; set; }
        public string? yaxisside { get; set; }
        public ZabbixItem? item { get; set; }
    }
}
