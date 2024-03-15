using System.Collections.Generic;

namespace Bizimgoz.Monitoring.Dtos.Problems
{
    public class CreateAcknowledgeDto
    {
        public List<string> eventids { get; set; }
        public string action { get; set; }
        public string? cause_eventid { get; set; }
        public string? message { get; set; }
        public string? severity { get; set; }
        public string? suppress_until { get; set; }
    }
}
