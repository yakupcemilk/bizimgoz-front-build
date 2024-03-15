using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Bizimgoz.Monitoring.Entities.Dashboards
{
    public class DashboardElement : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid DashboardId { get; set; }
        public string hostid { get; set; } //= string.Empty;
        public string GraphType { get; set; }// = string.Empty;
        public List<string> itemids { get; set; }// = new List<string>();
        public DashboardSize Size { get; set; }// = new DashboardVector { X = 0, Y = 0 };
        public DashboardPosition Position { get; set; }// = new DashboardVector { X = 0, Y = 0 };
    }
}