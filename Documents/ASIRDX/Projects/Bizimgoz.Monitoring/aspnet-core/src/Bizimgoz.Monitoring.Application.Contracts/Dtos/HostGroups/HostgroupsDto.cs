using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bizimgoz.Monitoring.Dtos.HostGroups
{
    public class HostgroupsDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? groupid { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? name { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Internal { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? flags { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? uuid { get; set; }
    }
}
