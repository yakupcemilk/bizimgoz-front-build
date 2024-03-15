namespace Bizimgoz.Monitoring.Dtos.Problems
{
    public class ZabbixAcknowledge
    {
        public string? acknowledgeid { get; set; }
        public string? userid { get; set; }
        public string? eventid { get; set; }
        public string? clock { get; set; }
        public string? message { get; set; }
        public string? action { get; set; }
        public string? old_severity { get; set; }
        public string? new_severity { get; set; }
    }
}