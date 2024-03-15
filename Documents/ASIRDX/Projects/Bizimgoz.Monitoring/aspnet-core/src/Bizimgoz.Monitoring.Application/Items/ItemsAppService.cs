using Bizimgoz.Monitoring.Dtos.ZabbixGraphs;
using Bizimgoz.Monitoring.HelperServices.EmptyToNull;
using Bizimgoz.Monitoring.zabbix;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Bizimgoz.Monitoring.Items
{
    public class ItemsAppService : ApplicationService
    {
        private ZabbixAppService _zabbix;
        private EmptyToNullService _toNull;

        public ItemsAppService(ZabbixAppService zabbix, EmptyToNullService toNull)
        {
            _zabbix = zabbix;
            _toNull = toNull;
        }

        public async Task<ZabbixItem?> Create(ZabbixItem item)
        {
            var result = await _zabbix.ZabbixGetSingle<ItemCreationResult>("item.create", item);
            var createdItem = (await _zabbix.ZabbixGet<ZabbixItem>("item.get", result)).FirstOrDefault();
            return createdItem;
        }
        public async Task<ItemCreationResult?> Update(ZabbixItem item)
        {
            return await _zabbix.ZabbixGetSingle<ItemCreationResult>("item.create", item);
        }
        public async Task<List<ZabbixItem>> Get(string templateid)
        {
            var items =  await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { templateids = new List<string> { templateid } });
            items.ForEach(_toNull.Check);
            return items;
        }
    }
}
