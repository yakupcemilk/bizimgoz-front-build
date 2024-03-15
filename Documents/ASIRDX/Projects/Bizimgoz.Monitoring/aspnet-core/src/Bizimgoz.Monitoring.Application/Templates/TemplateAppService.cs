using Bizimgoz.Monitoring.Dtos.Templates;
using Bizimgoz.Monitoring.Dtos.ZabbixGraphs;
using Bizimgoz.Monitoring.HelperServices.EmptyToNull;
using Bizimgoz.Monitoring.zabbix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Emailing;
using Volo.Abp.Emailing.Smtp;
using Volo.Abp.Sms;

namespace Bizimgoz.Monitoring.Templates
{
    public class TemplateAppService : ApplicationService
    {
        private ISmtpEmailSenderConfiguration _configuration;
        private ZabbixAppService _zabbix;
        private EmptyToNullService _toNull;
        private IEmailSender _emailSender;
        private ISmsSender _smsSender;

        public TemplateAppService(ZabbixAppService zabbix, EmptyToNullService toNull, IEmailSender emailSender, ISmsSender smsSender, ISmtpEmailSenderConfiguration configuration)
        {
            _configuration = configuration;
            _zabbix = zabbix;
            _toNull = toNull;
            _emailSender = emailSender;
            _smsSender = smsSender;
        }

        public async Task<IEnumerable<TemplateDto>> Get() => (await _zabbix.ZabbixGet<TemplateDto>("template.get", new { }));//.Take(10);
        public async Task<TemplateDto?> GetFirst(string templateId)
        {
            var template = (await _zabbix.ZabbixGet<TemplateDto>("template.get", new { templateids = new List<string> { templateId } })).FirstOrDefault();
            if (template is null) return template;
            template.Items = await _zabbix.ZabbixGet<ZabbixItem>("item.get", new { templateids = new List<string> { template.templateid } });
            foreach (var item in template.Items) _toNull.Check(item);
            return template;
        }

        public async Task<TemplateDto?> Create(TemplateDto template)
        {
            try
            {
                var result = await _zabbix.ZabbixGetSingle<TemplateCreationResult>("template.create", template);
                var createdTemplate = (await _zabbix.ZabbixGet<TemplateDto>("template.get", result)).FirstOrDefault();
                return createdTemplate;
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }

        }

        public async Task<TemplateCreationResult?> Update(TemplateDto template) => await _zabbix.ZabbixGetSingle<TemplateCreationResult>("template.update", template);
        public async Task<TemplateCreationResult?> Delete(List<string> templateIds)
        {
            // return await Task.FromResult<TemplateCreationResult?>(default);

            // The deletion endpoint has been temporarily disabled to prevent undesired operations in the database...
            return await _zabbix.ZabbixGetSingle<TemplateCreationResult>("template.delete", templateIds);
        }
        public async Task<LinkCreationResult?> LinkToHosts(LinkInputDto link)
        {
            return await _zabbix.ZabbixGetSingle<LinkCreationResult>("host.massadd", new
            {
                hosts = link.hostids.Select(hostid => new { hostid }),
                templates = link.templateids.Select(templateid => new { templateid })
            });
        }
        public async Task<LinkCreationResult?> UnlinkToHosts(LinkInputDto link)
        {
            if (link.clear) return await _zabbix.ZabbixGetSingle<LinkCreationResult>("host.massremove", new
            {
                link.hostids,
                templateids_clear = link.templateids
            });
            else return await _zabbix.ZabbixGetSingle<LinkCreationResult>("host.massremove", new
            {
                link.hostids,
                link.templateids
            });
        }

        public async Task SendThatNi(string message)
        {
            try
            {
                 await _emailSender.SendAsync("apelit55@gmail.com", "Sent by Bizimgoz Backend", message);
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }

            // await _smsSender.SendAsync("+905368454562","Naber müdür!");
        }
    }
}
