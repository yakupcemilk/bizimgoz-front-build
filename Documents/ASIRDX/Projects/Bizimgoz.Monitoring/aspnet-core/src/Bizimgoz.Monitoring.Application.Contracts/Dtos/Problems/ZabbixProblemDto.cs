using Bizimgoz.Monitoring.Dtos.Hosts;
using System.Collections.Generic;

namespace Bizimgoz.Monitoring.Dtos.Problems
{
    public class ZabbixProblemDto
    {
        public ZabbixHostDto Host { get; set; }
        public string eventid { get; set; }
        public string source { get; set; }
        public string Object { get; set; }
        public string objectid { get; set; }
        public string clock { get; set; }
        public string ns { get; set; }
        public string r_eventid { get; set; }
        public string r_clock { get; set; }
        public string r_ns { get; set; }
        public string cause_eventid { get; set; }
        public string correlationid { get; set; }
        public string userid { get; set; }
        public string name { get; set; }
        public string acknowledged { get; set; }
        public string severity { get; set; }
        public string suppressed { get; set; }
        public string opdata { get; set; }
        // public string urls { get; set; }
        public List<ZabbixTag> tags { get; set; }
        public List<ZabbixAcknowledge> acknowledges { get; set; }
    }
}
