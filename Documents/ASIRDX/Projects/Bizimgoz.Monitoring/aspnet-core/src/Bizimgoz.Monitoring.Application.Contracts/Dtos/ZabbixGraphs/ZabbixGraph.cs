//console.log(Array.from(t.children).map(t=>t.children[0].innerText).map(t =>`public int ${ t}{ get; set; }`).join("\n"))

using System.Collections.Generic;

namespace Bizimgoz.Monitoring.Dtos.ZabbixGraphs
{
    public class ZabbixGraph
    {
        public string? graphid { get; set; }
        public string? height { get; set; }
        public string? name { get; set; }
        public string? width { get; set; }
        public string? flags { get; set; }
        public string? graphtype { get; set; }
        public string? percent_left { get; set; }
        public string? percent_right { get; set; }
        public string? show_3d { get; set; }
        public string? show_legend { get; set; }
        public string? show_work_period { get; set; }
        public string? show_triggers { get; set; }
        public string? templateid { get; set; }
        public string? yaxismax { get; set; }
        public string? yaxismin { get; set; }
        public string? ymax_itemid { get; set; }
        public string? ymax_type { get; set; }
        public string? ymin_itemid { get; set; }
        public string? ymin_type { get; set; }
        public string? uuid { get; set; }
        public IEnumerable<ZabbixGraphItem> Gitems { get; set; } = new List<ZabbixGraphItem>();
    }
}
