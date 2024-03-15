using System;
using Volo.Abp.Domain.Entities;

namespace Bizimgoz.Monitoring.Entities.Dashboards
{
    public class DashboardSize : BasicAggregateRoot<Guid>
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}