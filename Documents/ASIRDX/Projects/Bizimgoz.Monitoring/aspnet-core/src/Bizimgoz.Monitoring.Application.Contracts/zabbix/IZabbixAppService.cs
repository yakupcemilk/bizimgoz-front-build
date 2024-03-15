using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Bizimgoz.Monitoring.zabbix
{
    public interface IZabbixAppService : IApplicationService
    {
        Task<string?> SendPostRequest(dynamic dBody);
        public Task<Output?> ZabbixGet<Input, Output>(string method, Input input);
        public Task<List<Output>> ZabbixGet<Output>(string method, dynamic input);
        public Task<dynamic?> ZabbixGetD(string method, dynamic input);
        Task<Output?> ZabbixGetSingle<Output>(string method, dynamic input);
    }
}
