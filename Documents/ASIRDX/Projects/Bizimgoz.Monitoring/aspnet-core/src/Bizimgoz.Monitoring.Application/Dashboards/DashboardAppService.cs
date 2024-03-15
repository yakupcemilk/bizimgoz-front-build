using Bizimgoz.Monitoring.Dtos.Dashboards;
using Bizimgoz.Monitoring.Dtos.ZabbixGraphs;
using Bizimgoz.Monitoring.Entities.Dashboards;
using Bizimgoz.Monitoring.zabbix;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Bizimgoz.Monitoring.Dashboards
{
    public class DashboardAppService : ApplicationService, IDashboardAppService
    {
        private IRepository<Dashboard, Guid> _repository;
        private IRepository<DashboardElement, Guid> _elementRepo;
        private IZabbixAppService _zabbix;
        private ILogger<DashboardAppService> _logger;

        public DashboardAppService(
            IZabbixAppService zabbix,
            IRepository<Dashboard, Guid> repository,
            IRepository<DashboardElement, Guid> elementRepo,
            ILogger<DashboardAppService> logger)
        {
            _repository = repository;
            _elementRepo = elementRepo;
            _zabbix = zabbix;
            _logger = logger;
        }
        public async Task<IEnumerable<DashboardDto>> Get(int limit = 100)
        {
            var result = (await _repository.GetListAsync(true))
                .Select(dashboard => ObjectMapper.Map<Dashboard, DashboardDto>(dashboard)).ToList();
            foreach (var item in result)
            {
                foreach (var element in item.Elements)
                {
                    element.items = (await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { element.itemids }));
                    foreach (var zabbixItem in element.items)
                    {
                        zabbixItem.histories = await _zabbix
                        .ZabbixGet<ZabbixHistory>("history.get", new
                        {
                            limit,
                            itemids = zabbixItem.itemid,
                            sortfield = "clock",
                            sortorder = "DESC",
                        });
                        zabbixItem.histories.Reverse();
                    }
                }
            }
            _logger.LogInformation($"Dashboard.Count: {result.Count}");
            return result;
        }
        public async Task<List<string>> AddToOptions(Guid id, List<string> elements)
        {
            var dashboard = await _repository.GetAsync(id);
            if (dashboard.Options is null) dashboard.Options = new List<string> { };
            dashboard.Options.AddRange(elements);
            return dashboard.Options;
        }
        public async Task<List<string>> DeleteFromOptions(Guid id, List<string> elements)
        {
            var dashboard = await _repository.GetAsync(id);
            if (dashboard.Options is null) dashboard.Options = new List<string> { };
            dashboard.Options.RemoveAll(opt => elements.Contains(opt));
            return dashboard.Options;
        }
        public async Task<List<string>> SetOptions(Guid id, List<string> elements)
        {
            var dashboard = await _repository.GetAsync(id);
            dashboard.Options = elements;
            return dashboard.Options;
        }
        public async Task SetSizeOfElement(Guid elementId, DashboardSizeDto sizeDto)
        {
            var size = ObjectMapper.Map<DashboardSizeDto, DashboardSize>(sizeDto);
            var element = await _elementRepo.GetAsync(elementId, true);
            element.Size = size;
        }
        public async Task<IEnumerable<DashboardElementDto>> AddElement(List<DashboardElementDto> elementDtos)
        {
            var elements = elementDtos.Select(elementDto => ObjectMapper.Map<DashboardElementDto, DashboardElement>(elementDto));
            await _elementRepo.InsertManyAsync(elements);
            return elements.Select(element => ObjectMapper.Map<DashboardElement, DashboardElementDto>(element));
        }
        public async Task SetPositionOfElement(Guid elementId, DashboardPositionDto positionDto)
        {
            var position = ObjectMapper.Map<DashboardPositionDto, DashboardPosition>(positionDto);
            var element = await _elementRepo.GetAsync(elementId, true);
            element.Position = position;
        }
        public async Task<DashboardDto> Get(Guid id, int limit = 100)
        {
            var dashboard = ObjectMapper.Map<Dashboard, DashboardDto>(await _repository.GetAsync(t => t.Id == id, true));
            foreach (var element in dashboard.Elements)
            {
                element.items = (await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { element.itemids }));
                foreach (var zabbixItem in element.items)
                {
                    zabbixItem.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        itemids = zabbixItem.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    zabbixItem.histories.Reverse();
                }
            }
            return dashboard;
        }
        public async Task<DashboardDto> Create(DashboardDto input)
        {
            var dashboard = ObjectMapper.Map<DashboardDto, Dashboard>(input);
            var result = await _repository.InsertAsync(dashboard);
            return ObjectMapper.Map<Dashboard, DashboardDto>(result);
        }
        public async Task Delete(Guid id)
        {
            await _repository.DeleteManyAsync(new List<Guid> { id }.AsEnumerable(), true);
            _logger.LogWarning($"Dashboard.DELETE: {id}");
            return;
        }
    }
}
