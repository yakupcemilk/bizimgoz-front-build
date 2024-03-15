using Bizimgoz.Monitoring.Dtos.Hosts;
using Bizimgoz.Monitoring.Dtos.Widgets;
using Bizimgoz.Monitoring.Dtos.ZabbixGraphs;
using Bizimgoz.Monitoring.Entities.Widgets;
using Bizimgoz.Monitoring.zabbix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Bizimgoz.Monitoring.Widgets
{
    public class WidgetAppService : ApplicationService, IWidgetAppService
    {
        private IZabbixAppService _zabbix;
        private IRepository<Widget, Guid> _repository;

        public WidgetAppService(
            IZabbixAppService zabbix,
            IRepository<Widget, Guid> repository)
        {
            this._zabbix = zabbix;
            this._repository = repository;
        }

        public async Task<IEnumerable<WidgetDto>> Get(int limit = 100)
        {
            var widgetsFromDb = (await _repository.GetListAsync(true))
                .Select(widget => ObjectMapper.Map<Widget, WidgetDto>(widget))
                .ToList();
            foreach (var widget in widgetsFromDb)
            {
                // CpuItem...
                widget.CpuItem = (await _zabbix.ZabbixGet<ZabbixItem>("item.get", new
                {
                    itemids = new List<string> { widget.CpuItemId }
                })).FirstOrDefault();
                if (widget.CpuItem is null) throw new UserFriendlyException("widget.CpuItem can not be found!");
                widget.CpuItem.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = 0, //widget.CpuItem.units == "%" ? "0" : "3",
                        itemids = widget.CpuItemId,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                widget.CpuItem.histories.Reverse();

                // RamItem...
                widget.RamItem = (await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { itemids = new List<string> { widget.RamItemId } })).FirstOrDefault();
                if (widget.RamItem is null) throw new UserFriendlyException("widget.RamItem can not be found!");
                widget.RamItem.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = widget.RamItem.units == "%" ? "0" : "3",
                        itemids = widget.RamItemId,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                widget.RamItem.histories.Reverse();

                // DiskItem...
                widget.DiskItem = (await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { itemids = new List<string> { widget.DiskItemId } })).FirstOrDefault();
                if (widget.DiskItem is null) throw new UserFriendlyException("widget.DiskItem can not be found!");
                widget.DiskItem.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = widget.DiskItem.units == "%" ? "0" : "3",
                        itemids = widget.DiskItemId,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                widget.DiskItem.histories.Reverse();

                // WanInterfaceTrafficItems...
                widget.WanInterfaceTrafficItems = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { itemids = widget.WanInterfaceTrafficIds });
                foreach (var WanInterfaceTrafficItem in widget.WanInterfaceTrafficItems)
                {
                    WanInterfaceTrafficItem.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = WanInterfaceTrafficItem.units == "%" ? "0" : "3",
                        itemids = WanInterfaceTrafficItem.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    WanInterfaceTrafficItem.histories.Reverse();
                }

                // InterfacePortTrafficItems...
                widget.InterfacePortTrafficItems = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { itemids = widget.InterfacePortTrafficIds });
                foreach (var InterfacePortTrafficItem in widget.InterfacePortTrafficItems)
                {
                    InterfacePortTrafficItem.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = InterfacePortTrafficItem.units == "%" ? "0" : "3",
                        itemids = InterfacePortTrafficItem.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    InterfacePortTrafficItem.histories.Reverse();
                }
            }
            return widgetsFromDb;
        }
        public async Task<WidgetDto?> GetByHostId(string HostId, int limit = 100)
        {
            try
            {
                var widget = ObjectMapper.Map<Widget, WidgetDto>(await _repository.GetAsync(t => t.HostId == HostId, true));
                // CpuItem...
                widget.CpuItem = (await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { itemids = new List<string> { widget.CpuItemId } })).FirstOrDefault();
                if (widget.CpuItem is null) throw new UserFriendlyException("widget.CpuItem can not be found!");
                widget.CpuItem.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = widget.CpuItem.value_type,
                        itemids = widget.CpuItemId,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                widget.CpuItem.histories.Reverse();

                // RamItem...
                widget.RamItem = (await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { itemids = new List<string> { widget.RamItemId } })).FirstOrDefault();
                if (widget.RamItem is null) throw new UserFriendlyException("widget.RamItem can not be found!");
                widget.RamItem.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = widget.RamItem.value_type,
                        itemids = widget.RamItemId,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                widget.RamItem.histories.Reverse();

                // DiskItem...
                widget.DiskItem = (await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { itemids = new List<string> { widget.DiskItemId } })).FirstOrDefault();
                if (widget.DiskItem is null) throw new UserFriendlyException("widget.DiskItem can not be found!");
                widget.DiskItem.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = widget.DiskItem.value_type,
                        itemids = widget.DiskItemId,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                widget.DiskItem.histories.Reverse();

                // WanInterfaceTrafficItems...
                widget.WanInterfaceTrafficItems = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { itemids = widget.WanInterfaceTrafficIds });
                foreach (var WanInterfaceTrafficItem in widget.WanInterfaceTrafficItems)
                {
                    WanInterfaceTrafficItem.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = WanInterfaceTrafficItem.value_type,
                        itemids = WanInterfaceTrafficItem.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    WanInterfaceTrafficItem.histories.Reverse();
                }

                // InterfacePortTrafficItems...
                widget.InterfacePortTrafficItems = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { itemids = widget.InterfacePortTrafficIds });
                foreach (var InterfacePortTrafficItem in widget.InterfacePortTrafficItems)
                {
                    InterfacePortTrafficItem.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = InterfacePortTrafficItem.value_type,
                        itemids = InterfacePortTrafficItem.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    InterfacePortTrafficItem.histories.Reverse();
                }
                return widget;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public async Task<WidgetDto?> Get(Guid id, int limit = 100)
        {
            try
            {
                var widget = ObjectMapper.Map<Widget, WidgetDto>(await _repository.GetAsync(t => t.Id == id, true));

                widget.Host = (await _zabbix.ZabbixGet<ZabbixHostDto>("host.get", new { hostids = new List<string> { widget.HostId } })).FirstOrDefault();
                widget.Uptime = (await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { hostids = new List<string> { widget.HostId }, search = new { key_ = "vmware.vm.uptime[{$VMWARE.URL},{$VMWARE.VM.UUID}]" } }))
                    .FirstOrDefault()?.lastvalue ?? "undefined";
                if (int.TryParse(widget.Uptime, out int uptimeInSeconds))
                {
                    TimeSpan uptime = TimeSpan.FromSeconds(uptimeInSeconds);

                    widget.Uptime = uptime.ToString();
                }
                widget.Status = (await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { hostids = new List<string> { widget.HostId }, search = new { key_ = "vmware.vm.powerstate[{$VMWARE.URL},{$VMWARE.VM.UUID}]" } }))
                    .FirstOrDefault()?.lastvalue == "1" ? true : false;

                // CpuItem...
                widget.CpuItem = (await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { itemids = new List<string> { widget.CpuItemId } })).FirstOrDefault();
                if (widget.CpuItem is null) throw new UserFriendlyException("widget.CpuItem can not be found!");
                widget.CpuItem.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = widget.CpuItem.value_type,
                        itemids = widget.CpuItemId,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                widget.CpuItem.histories.Reverse();

                // RamItem...
                widget.RamItem = (await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { itemids = new List<string> { widget.RamItemId } })).FirstOrDefault();
                if (widget.RamItem is null) throw new UserFriendlyException("widget.RamItem can not be found!");
                widget.RamItem.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = widget.RamItem.value_type,
                        itemids = widget.RamItemId,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                widget.RamItem.histories.Reverse();

                // DiskItem...
                widget.DiskItem = (await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { itemids = new List<string> { widget.DiskItemId } })).FirstOrDefault();
                if (widget.DiskItem is null) throw new UserFriendlyException("widget.DiskItem can not be found!");
                widget.DiskItem.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = widget.DiskItem.value_type,
                        itemids = widget.DiskItemId,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                widget.DiskItem.histories.Reverse();

                // WanInterfaceTrafficItems...
                widget.WanInterfaceTrafficItems = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { itemids = widget.WanInterfaceTrafficIds });
                foreach (var WanInterfaceTrafficItem in widget.WanInterfaceTrafficItems)
                {
                    WanInterfaceTrafficItem.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = WanInterfaceTrafficItem.value_type,
                        itemids = WanInterfaceTrafficItem.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    WanInterfaceTrafficItem.histories.Reverse();
                }

                // InterfacePortTrafficItems...
                widget.InterfacePortTrafficItems = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { itemids = widget.InterfacePortTrafficIds });
                foreach (var InterfacePortTrafficItem in widget.InterfacePortTrafficItems)
                {
                    InterfacePortTrafficItem.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = InterfacePortTrafficItem.value_type,
                        itemids = InterfacePortTrafficItem.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    InterfacePortTrafficItem.histories.Reverse();
                }
                return widget;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public async Task<WidgetDto> Create(WidgetDto input)
        {
            var widget = ObjectMapper.Map<WidgetDto, Widget>(input);
            var result = await _repository.InsertAsync(widget);
            return ObjectMapper.Map<Widget, WidgetDto>(result);
        }

        public async Task<IEnumerable<WidgetDto>> GetForTable()
        {
            var widgetsFromDb = (await _repository.GetListAsync(true))
                    .Select(widget => ObjectMapper.Map<Widget, WidgetDto>(widget))
                    .ToList();
            var hostids = widgetsFromDb.Select(widget => widget.HostId).ToList();
            var zabbixHost = await _zabbix.ZabbixGet<ZabbixHostDto>("host.get", new { hostids });
            var UpTimes = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { hostids, search = new { key_ = "vmware.vm.uptime[{$VMWARE.URL},{$VMWARE.VM.UUID}]" } });
            var powerStates = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { hostids, search = new { key_ = "vmware.vm.powerstate[{$VMWARE.URL},{$VMWARE.VM.UUID}]" } });
            foreach (var widget in widgetsFromDb)
            {
                widget.Host = zabbixHost.FirstOrDefault(host => host.Hostid == widget.HostId);

                var uptimeItem = UpTimes.FirstOrDefault(item => item.hostid == widget.HostId);
                widget.Uptime = uptimeItem?.lastvalue ?? "undefined";

                if (int.TryParse(widget.Uptime, out int uptimeInSeconds))
                {
                    TimeSpan uptime = TimeSpan.FromSeconds(uptimeInSeconds);

                    widget.Uptime = uptime.ToString();
                }

                var powerState = powerStates.FirstOrDefault(item => item.hostid == widget.HostId);
                widget.Status = powerState?.lastvalue == "1" ? true : false;

                // widget.IncidentCount = (await _zabbix.ZabbixGet<ZabbixHostDto>("problem.get", new { hostids = new List<string> { widget.HostId } })).Count;
            }
            return widgetsFromDb;
        }
    }
}
