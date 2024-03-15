using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bizimgoz.Monitoring.Entities.ZabbixInfo
{
    public class ZabbixInfo : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public string Url { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Token { get; set; }
    }
}
