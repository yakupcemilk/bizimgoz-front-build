using Bizimgoz.Monitoring.Dtos.FirewallDashboards;
using Bizimgoz.Monitoring.Dtos.Hosts;
using Bizimgoz.Monitoring.Dtos.ZabbixGraphs;
using Bizimgoz.Monitoring.HelperServices.EmptyToNull;
using Bizimgoz.Monitoring.zabbix;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Bizimgoz.Monitoring.FirewallDashboards
{
    public class FirewallDashboardAppService : ApplicationService
    {
        private ZabbixAppService _zabbix;
        private EmptyToNullService _toNull;

        public FirewallDashboardAppService(ZabbixAppService zabbix, EmptyToNullService toNull)
        {
            _zabbix = zabbix;
            _toNull = toNull;
        }

        public async Task<IEnumerable<FirewallDashboard?>> Get(int limit = 100)
        {
            var item0 = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { search = new { key_ = "system.name" } });
            // var item1 = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { search = new { key_ = "Interface üzerinden bulunacak" } });
            var item2 = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { search = new { key_ = "fnSysSerial" } });
            // var item3 = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { search = new { key_ = "null" } });
            var item4 = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { search = new { key_ = "system.sw.os[sysDescr.0]" } });
            var item5 = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { search = new { key_ = "fgSysCpuUsage" } });
            var item6 = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { search = new { key_ = "fgSysMemUsage" } });
            // var item7 = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { search = new { key_ = "null" } });
            var item8 = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { search = new { key_ = "fgSysDiskUsage" } });
            var item9 = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { search = new { key_ = "icmpping" } });
            var item10 = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { search = new { key_ = "system.uptime[sysUpTime.0]" } });
            var item11 = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { search = new { key_ = "fgVpnSslStatsLoginUsers" } });
            // var item12 = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { search = new { key_ = "null" } });
            var item13 = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { search = new { key_ = "fgSysSesCount" } });
            var item14 = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { search = new { key_ = "fgVpnTunnelUpCount" } });
            var item15 = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { search = new { key_ = "fgIpsIntrusionsBlocked" } });
            var item16 = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { search = new { key_ = "fgIpsAnomalyDetections" } });

            item0.ForEach(item => _toNull.Check(item));
            item2.ForEach(item => _toNull.Check(item));
            item4.ForEach(item => _toNull.Check(item));
            item5.ForEach(item => _toNull.Check(item));
            item6.ForEach(item => _toNull.Check(item));
            item8.ForEach(item => _toNull.Check(item));
            item9.ForEach(item => _toNull.Check(item));
            item10.ForEach(item => _toNull.Check(item));
            item11.ForEach(item => _toNull.Check(item));
            item13.ForEach(item => _toNull.Check(item));
            item14.ForEach(item => _toNull.Check(item));
            item15.ForEach(item => _toNull.Check(item));
            item16.ForEach(item => _toNull.Check(item));

            var hostids = item0.Select(item => item.hostid);

            hostids = hostids.Where(hostid => item2.Select(item => item.hostid).Contains(hostid));
            hostids = hostids.Where(hostid => item4.Select(item => item.hostid).Contains(hostid));
            hostids = hostids.Where(hostid => item5.Select(item => item.hostid).Contains(hostid));
            hostids = hostids.Where(hostid => item6.Select(item => item.hostid).Contains(hostid));
            hostids = hostids.Where(hostid => item8.Select(item => item.hostid).Contains(hostid));
            hostids = hostids.Where(hostid => item9.Select(item => item.hostid).Contains(hostid));
            hostids = hostids.Where(hostid => item10.Select(item => item.hostid).Contains(hostid));
            hostids = hostids.Where(hostid => item11.Select(item => item.hostid).Contains(hostid));
            hostids = hostids.Where(hostid => item13.Select(item => item.hostid).Contains(hostid));
            hostids = hostids.Where(hostid => item14.Select(item => item.hostid).Contains(hostid));
            hostids = hostids.Where(hostid => item15.Select(item => item.hostid).Contains(hostid));
            hostids = hostids.Where(hostid => item16.Select(item => item.hostid).Contains(hostid));

            var hosts = await _zabbix.ZabbixGet<ZabbixHostDto>("host.get", new { hostids = hostids.ToList() });

            var dashboards = hosts.Select(host => new FirewallDashboard
            {
                host = host,
                Name = item0.FirstOrDefault(item => item.hostid == host.Hostid),
                // IPAddress = item1.FirstOrDefault(item => item.hostid == host.Hostid),
                Serial = item2.FirstOrDefault(item => item.hostid == host.Hostid),
                // ODModel = item3.FirstOrDefault(item => item.hostid == host.Hostid),
                OsVersion = item4.FirstOrDefault(item => item.hostid == host.Hostid),
                Cpu = item5.FirstOrDefault(item => item.hostid == host.Hostid),
                MemUsed = item6.FirstOrDefault(item => item.hostid == host.Hostid),
                // Load = item7.FirstOrDefault(item => item.hostid == host.Hostid),
                DiskUsed = item8.FirstOrDefault(item => item.hostid == host.Hostid),
                Status = item9.FirstOrDefault(item => item.hostid == host.Hostid),
                Uptime = item10.FirstOrDefault(item => item.hostid == host.Hostid),
                ConnectUsers = item11.FirstOrDefault(item => item.hostid == host.Hostid),
                // Processes = item12.FirstOrDefault(item => item.hostid == host.Hostid),
                ActiveSessions = item13.FirstOrDefault(item => item.hostid == host.Hostid),
                VpnCount = item14.FirstOrDefault(item => item.hostid == host.Hostid),
                IntrusionsBlocked = item15.FirstOrDefault(item => item.hostid == host.Hostid),
                IntrusionsDetectedAnomalyBased = item16.FirstOrDefault(item => item.hostid == host.Hostid),
            });
            foreach (var dashboard in dashboards)
            {
                if (dashboard.Name is not null)
                {
                    dashboard.Name.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = dashboard.Name.value_type,
                        itemids = dashboard.Name.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    dashboard.Name.histories.Reverse();
                }
                if (dashboard.IPAddress is not null)
                {
                    dashboard.IPAddress.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = dashboard.IPAddress.value_type,
                        itemids = dashboard.IPAddress.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    dashboard.IPAddress.histories.Reverse();
                }
                if (dashboard.Serial is not null)
                {
                    dashboard.Serial.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = dashboard.Serial.value_type,
                        itemids = dashboard.Serial.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    dashboard.Serial.histories.Reverse();
                }
                if (dashboard.ODModel is not null)
                {
                    dashboard.ODModel.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = dashboard.ODModel.value_type,
                        itemids = dashboard.ODModel.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    dashboard.ODModel.histories.Reverse();
                }
                if (dashboard.OsVersion is not null)
                {
                    dashboard.OsVersion.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = dashboard.OsVersion.value_type,
                        itemids = dashboard.OsVersion.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    dashboard.OsVersion.histories.Reverse();
                }
                if (dashboard.Cpu is not null)
                {
                    dashboard.Cpu.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = dashboard.Cpu.value_type,
                        itemids = dashboard.Cpu.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    dashboard.Cpu.histories.Reverse();
                }
                if (dashboard.MemUsed is not null)
                {
                    dashboard.MemUsed.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = dashboard.MemUsed.value_type,
                        itemids = dashboard.MemUsed.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    dashboard.MemUsed.histories.Reverse();
                }
                if (dashboard.Load is not null)
                {
                    dashboard.Load.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = dashboard.Load.value_type,
                        itemids = dashboard.Load.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    dashboard.Load.histories.Reverse();
                }
                if (dashboard.DiskUsed is not null)
                {
                    dashboard.DiskUsed.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = dashboard.DiskUsed.value_type,
                        itemids = dashboard.DiskUsed.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    dashboard.DiskUsed.histories.Reverse();
                }
                if (dashboard.Status is not null)
                {
                    dashboard.Status.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = dashboard.Status.value_type,
                        itemids = dashboard.Status.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    dashboard.Status.histories.Reverse();
                }
                if (dashboard.Uptime is not null)
                {
                    dashboard.Uptime.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = dashboard.Uptime.value_type,
                        itemids = dashboard.Uptime.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    dashboard.Uptime.histories.Reverse();
                }
                if (dashboard.ConnectUsers is not null)
                {
                    dashboard.ConnectUsers.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = dashboard.ConnectUsers.value_type,
                        itemids = dashboard.ConnectUsers.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    dashboard.ConnectUsers.histories.Reverse();
                }
                if (dashboard.Processes is not null)
                {
                    dashboard.Processes.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = dashboard.Processes.value_type,
                        itemids = dashboard.Processes.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    dashboard.Processes.histories.Reverse();
                }
                if (dashboard.ActiveSessions is not null)
                {
                    dashboard.ActiveSessions.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = dashboard.ActiveSessions.value_type,
                        itemids = dashboard.ActiveSessions.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    dashboard.ActiveSessions.histories.Reverse();
                }
                if (dashboard.VpnCount is not null)
                {
                    dashboard.VpnCount.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = dashboard.VpnCount.value_type,
                        itemids = dashboard.VpnCount.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    dashboard.VpnCount.histories.Reverse();
                }
                if (dashboard.IntrusionsBlocked is not null)
                {
                    dashboard.IntrusionsBlocked.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = dashboard.IntrusionsBlocked.value_type,
                        itemids = dashboard.IntrusionsBlocked.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    dashboard.IntrusionsBlocked.histories.Reverse();
                }
                if (dashboard.IntrusionsDetectedAnomalyBased is not null)
                {
                    dashboard.IntrusionsDetectedAnomalyBased.histories = await _zabbix
                    .ZabbixGet<ZabbixHistory>("history.get", new
                    {
                        limit,
                        history = dashboard.IntrusionsDetectedAnomalyBased.value_type,
                        itemids = dashboard.IntrusionsDetectedAnomalyBased.itemid,
                        sortfield = "clock",
                        sortorder = "DESC",
                    });
                    dashboard.IntrusionsDetectedAnomalyBased.histories.Reverse();
                }
            }
            return dashboards;
            // return await Task.FromResult(new List<string>());
        }
    }
}
