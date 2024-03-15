using System;
using System.Collections.Generic;
using System.Text;

namespace Bizimgoz.Monitoring.Dtos.Incidents
{
    public class IncidentTableValues
    {
        public HostAvailability? HostAvailability { get; set; }
        public int NumberOfUsers { get; set; }
        public int NumberOfTemplates{ get; set; }
        public List<int> NumberOfHosts{ get; set; }
        public List<int> NumberOfTriggers{ get; set; }
        public string? ServerUrl{ get; set; }
    }
}
