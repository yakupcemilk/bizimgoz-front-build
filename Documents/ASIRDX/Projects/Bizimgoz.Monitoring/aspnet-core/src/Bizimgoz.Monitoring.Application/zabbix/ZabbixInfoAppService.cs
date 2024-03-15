using Bizimgoz.Monitoring.Entities.ZabbixInfo;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Bizimgoz.Monitoring.zabbix
{
    public class ZabbixInfoAppService : ApplicationService
    {
        private IRepository<ZabbixInfo, Guid> _repository;
        public ZabbixInfoAppService(IRepository<ZabbixInfo, Guid> repository) => _repository = repository;
        public async Task<ZabbixInfo?> Get() => await _repository.GetAsync(t => true);
        public async Task<ZabbixInfo?> Create(ZabbixInfo element) => await _repository.InsertAsync(element);
    }
}
