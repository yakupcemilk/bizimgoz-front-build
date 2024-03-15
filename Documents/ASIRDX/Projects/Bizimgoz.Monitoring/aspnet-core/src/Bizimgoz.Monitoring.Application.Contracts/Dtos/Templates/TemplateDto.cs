using Bizimgoz.Monitoring.Dtos.ZabbixGraphs;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bizimgoz.Monitoring.Dtos.Templates
{
    public class TemplateDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<TemplateGroup>? groups { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<TemplateTemplates>? templates { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? templateid { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? host { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? description { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? name { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? uuid { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public string? vendor_name { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? vendor_version { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<ZabbixItem>? Items  { get; set; }
    }
}
