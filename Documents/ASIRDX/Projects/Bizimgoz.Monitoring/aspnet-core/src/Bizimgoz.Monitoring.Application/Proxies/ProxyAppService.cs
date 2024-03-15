using Bizimgoz.Monitoring.Dtos.Proxies;
using Bizimgoz.Monitoring.zabbix;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Bizimgoz.Monitoring.Proxies
{
    public class ProxyAppService : ApplicationService
    {
        private IZabbixAppService _zabbix;

        public ProxyAppService(IZabbixAppService zabbix)
        {
            _zabbix = zabbix;
        }
        public async Task<IEnumerable<ZabbixProxyDto>> Get()
        {
            var proxies = await _zabbix.ZabbixGet<ZabbixProxyDto>("proxy.get", new { });
            proxies.AddFirst(item: new ZabbixProxyDto { host = "no proxy", proxyid = "0" });
            return proxies;
        }
    }
}
