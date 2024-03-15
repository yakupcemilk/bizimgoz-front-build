using System;
using System.Collections.Generic;
using System.Text;

namespace Bizimgoz.Monitoring.Dtos.Incidents
{
    public class HostAvailability
    {
        public int Unknown { get; set; } = 0;
        public int Available { get; set; } = 0;
        public int Unavailable { get; set; } = 0;
    }
}
