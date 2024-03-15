using Bizimgoz.Monitoring.Dtos.ZabbixGraphs;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Bizimgoz.Monitoring.Dtos.Dashboards
{
    public class DashboardElementDto : FullAuditedEntityDto<Guid>
    {
        public Guid DashboardId { get; set; }
        public string hostid { get; set; } //= string.Empty;
        public string GraphType { get; set; }// = string.Empty;
        public List<string> itemids { get; set; }// = new List<string>();
        public List<ZabbixItem> items { get; set; }// = new List<string>();
        public DashboardSizeDto Size { get; set; }// = new DashboardVector { X = 0, Y = 0 };
        public DashboardPositionDto Position { get; set; }// = new DashboardVector { X = 0, Y = 0 };
    }
}