using Bizimgoz.Monitoring.Dtos.HostGroups;
using System.Collections.Generic;

namespace Bizimgoz.Monitoring.Dtos.Hosts.Create
{
    public class ZabbixHostCreateDto : ZabbixHostDto
    {
        public List<HostgroupsDto> groups { get; set; }
        public List<ZabbixInterfaceDto> interfaces { get; set; }
        public List<ZabbixTagDto>? tags { get; set; }
        public List<ZabbixTemplateDto> templates { get; set; }
        public List<ZabbixMacroDto>? macros { get; set; }
        public ZabbixInventory? inventory { get; set; }
    }
}
