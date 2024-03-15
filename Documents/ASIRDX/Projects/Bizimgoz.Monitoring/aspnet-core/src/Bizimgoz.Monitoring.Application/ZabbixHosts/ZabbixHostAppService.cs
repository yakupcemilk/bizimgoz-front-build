using Bizimgoz.Monitoring.Dtos.Hosts;
using Bizimgoz.Monitoring.Dtos.Hosts.Create;
using Bizimgoz.Monitoring.Dtos.Zabbix;
using Bizimgoz.Monitoring.Entities.Hosts;
using Bizimgoz.Monitoring.zabbix;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Bizimgoz.Monitoring.ZabbixHosts
{
    [Authorize]
    public class ZabbixHostAppService : ApplicationService, IZabbixHostAppService
    {
        private IRepository<ZabbixHost, Guid> _repository;
        private IZabbixAppService _zabbix;

        public ZabbixHostAppService(IRepository<ZabbixHost, Guid> repository, IZabbixAppService zabbix)
        {
            _repository = repository;
            _zabbix = zabbix;
        }

        public async Task<dynamic> Create(ZabbixHostCreateDto input)
        {
            // create host in zabbix...
            dynamic? result = await _zabbix.ZabbixGet<ZabbixHostCreateDto, ExpandoObject>("host.create", input);
            if (((IDictionary<string, object>)result).ContainsKey("error")) return result.error;

            List<string> hostids = new List<string>();
            foreach (var id in result.result.GetProperty("hostids").EnumerateArray()) hostids.Add(id.GetString());

            // fetch created host in zabbix...
            var HostData = await _zabbix.ZabbixGet<dynamic, ZabbixResponseDto<List<ZabbixHostDto>>>("host.get", new { hostids });

            // Create host in backend...
            var theHost = HostData?.result?
                .Select(dto => ObjectMapper.Map<ZabbixHostDto, ZabbixHost>(dto))
                .FirstOrDefault();
            var HostWhatWillReturn = await _repository.InsertAsync(theHost, true);
            return HostWhatWillReturn;
        }
        [HttpPost]
        public async Task Delete(List<Guid> ids)
        {
            var HostsWhatWillBeDeleted = await _repository.GetListAsync(t => ids.Contains(t.Id));
            var hostids = HostsWhatWillBeDeleted.Select(t => t.Hostid);
            await _repository.DeleteManyAsync(ids.ToArray());
            await _zabbix.ZabbixGetD("host.delete", hostids);
            return;
        }

        public async Task<ZabbixHostDto> Get(Guid id)
        {
            var element = await _repository.GetAsync(t => t.Id == id, true);
            return ObjectMapper.Map<ZabbixHost, ZabbixHostDto>(element);
        }

        public async Task<IEnumerable<ZabbixHostDto>> Get()
        {
            // get Hosts form DB...
            var list = await _repository.GetListAsync(true);

            // data -> dto...
            var dtos = list.Select(t => ObjectMapper.Map<ZabbixHost, ZabbixHostDto>(t));

            return dtos;
        }

        public async Task<IEnumerable<ZabbixHostDto>> Sync(string groupid)
        {
            var backendHosts = await _repository.GetListAsync();
            var hostids = backendHosts.Select(x => x.Hostid).ToList();

            var hostResponse = await _zabbix.ZabbixGet<dynamic, ZabbixResponseDto<List<ZabbixHost>>>("host.get", new { groupids = new List<string> { groupid } });
            if (hostResponse.error != null) throw new UserFriendlyException(hostResponse.error.message);
            var unsavedTemplates = hostResponse.result.Where(x => !hostids.Contains(x.Hostid)).ToList();

            await _repository.InsertManyAsync(unsavedTemplates);

            return unsavedTemplates.Select(x => ObjectMapper.Map<ZabbixHost, ZabbixHostDto>(x));
        }

        [HttpPost]
        public async Task<ZabbixHostDto> Update(Guid id, ExpandoObject input)
        {
            dynamic dinput = input;
            var host = await _repository.GetAsync(id);
            foreach (var prop in input)
            {
                Func<PropertyInfo, bool> predicate = p =>
                {
                    return string.Equals(p.Name, prop.Key, StringComparison.OrdinalIgnoreCase)
                    || (prop.Key == "host" && p.Name == "HostName");
                };
                var propertyInfo = host.GetType()
                    .GetProperties()
                    .FirstOrDefault(predicate);

                if (propertyInfo != null)
                {
                    // var value = (JsonElement)prop.Value;
                    if (propertyInfo.PropertyType == typeof(string))
                    {
                        propertyInfo.SetValue(host, prop.Value);
                    }
                    else if (propertyInfo.PropertyType == typeof(int))
                    {
                        propertyInfo.SetValue(host, prop.Value);
                    }

                }
            }

            dinput.hostid = host.Hostid;
            var result = await _zabbix.ZabbixGetD("host.update", dinput);
            if (((IDictionary<string, object>)result).ContainsKey("error")) return result.error;
            return ObjectMapper.Map<ZabbixHost, ZabbixHostDto>(host);
        }
    }
}
