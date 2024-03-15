using Bizimgoz.Monitoring.Dtos.Hosts;
using Bizimgoz.Monitoring.Dtos.Hosts.Create;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Bizimgoz.Monitoring.ZabbixHosts
{
    public interface IZabbixHostAppService : IApplicationService
    {
        Task<IEnumerable<ZabbixHostDto>>Sync(string groupid);
        Task<dynamic> Create(ZabbixHostCreateDto input);
        Task Delete(List<Guid> ids);
        Task<ZabbixHostDto> Get(Guid id);
        Task<IEnumerable<ZabbixHostDto>> Get();
        Task<ZabbixHostDto> Update(Guid id, ExpandoObject input);
    }
}
