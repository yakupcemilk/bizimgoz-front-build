using Bizimgoz.Monitoring.Dtos.Dashboards;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Bizimgoz.Monitoring.Dashboards
{
    public interface IDashboardAppService : IApplicationService
    {
        Task<IEnumerable<DashboardElementDto>> AddElement(List<DashboardElementDto> elementDtos);
        Task<List<string>> AddToOptions(Guid id, List<string> elements);
        Task<DashboardDto> Create(DashboardDto input);
        Task Delete(Guid id);
        Task<List<string>> DeleteFromOptions(Guid id, List<string> elements);
        Task<IEnumerable<DashboardDto>> Get(int limit = 100);
        Task<DashboardDto> Get(Guid id, int limit = 100);
        Task<List<string>> SetOptions(Guid id, List<string> elements);
        Task SetPositionOfElement(Guid elementId, DashboardPositionDto positionDto);
        Task SetSizeOfElement(Guid elementId, DashboardSizeDto sizeDto);
    }
}
