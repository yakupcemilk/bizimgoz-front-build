using Bizimgoz.Monitoring.Dtos.HostGroups;
using Bizimgoz.Monitoring.Dtos.Templates;
using Bizimgoz.Monitoring.Dtos.Users;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bizimgoz.Monitoring.Dtos.Actions
{
    public class ZabbixActionOperationDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? operationtype { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? esc_period { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? esc_step_from { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? esc_step_to { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? evaltype { get; set; }
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        // public string? opcommand { get; set; }
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        // public string? opcommand_grp { get; set; }
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        // public string? opcommand_hst { get; set; }
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        // public string? opconditions { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<HostgroupsDto>? opgroup { get; set; }
         [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ZabbixActionOperationMessageDto? opmessage { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<ZabbixUserGroupDto>? opmessage_grp { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<ZabbixUserDto>? opmessage_usr { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<TemplateDto>? optemplate { get; set; }
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        // public string? opinventory { get; set; }
    }
}
