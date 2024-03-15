using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Bizimgoz.Monitoring.Dtos.Dashboards
{
    public class DashboardDto : FullAuditedEntityDto<Guid>
    {
        public string name { get; set; }
        public string Purpose { get; set; }
        public List<string> Options { get; set; }
        public List<DashboardElementDto> Elements { get; set; }
    }
}
