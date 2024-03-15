using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bizimgoz.Monitoring.Dtos
{
    public class ZabbixResultDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? druleids { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? groupids { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? actionids { get; set; }
    }
}
