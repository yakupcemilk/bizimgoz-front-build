using Bizimgoz.Monitoring.Dtos.Zabbix;
using Bizimgoz.Monitoring.Entities.ZabbixInfo;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Emailing.Smtp;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Settings;

namespace Bizimgoz.Monitoring.zabbix
{
    public class ZabbixAppService : ApplicationService, IZabbixAppService
    {
        public string? baseUrl; // = "http://10.200.146.146/zabbix/api_jsonrpc.php";
        public string? Auth = null;
        private IRepository<ZabbixInfo, Guid> _repository;
        private ISettingProvider _settingProvider;
        private ISettingEncryptionService _encryptionService;
        private ICurrentTenant _currentTenant;

        public ZabbixAppService(
            IConfiguration configuration, 
            ICurrentTenant currentTenant, 
            IRepository<ZabbixInfo, Guid> repository, 
            ISettingEncryptionService encryptionService,
            ISettingProvider settingProvider)
        {
            
            _settingProvider = settingProvider;
            _encryptionService = encryptionService;
            _currentTenant = currentTenant;
            var naem = currentTenant.Name;
            baseUrl = configuration.GetSection("Zabbix:Url").Value;
            if (baseUrl == null) throw new Exception("Zabbix.Url is null! add Zabbix.Url value into the appsettings.json");
            _repository = repository;
        }

        private async Task SetAuth()
        {
            if (Auth != null) return;
            if (_currentTenant.Name == null)
            {
                Auth = "5931ab2ed76d8e34e7e897b6d1f8c522";
                return;
            }
            var info = await _repository.GetAsync(t => true);
            Auth = info.Token;
        }

        public async Task<string?> SendPostRequest(dynamic dBody)
        {
            string body = dBody.ToString() ?? string.Empty;

            using (HttpClient httpClient = new HttpClient())
            {
                //httpClient.Timeout = TimeSpan.FromSeconds(1);

                HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(baseUrl, content);

                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<Output?> ZabbixGet<Input, Output>(string method, Input input)
        {
            await SetAuth();
            var bodyObject = new ZabbixRequestDto<Input>(method, input, Auth);
            string body = JsonSerializer.Serialize(bodyObject, bodyObject.GetType(),
                new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                });

            using (HttpClient httpClient = new HttpClient())
            {
                //httpClient.Timeout = TimeSpan.FromSeconds(1);

                HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(baseUrl, content);

                var resultString = await response.Content.ReadAsStringAsync();
                if (resultString == null) throw new UserFriendlyException("Zabbix request returned null");
                File.WriteAllText("resultString.json", resultString);
                Output? responseData;
                try
                {
                    responseData = JsonSerializer.Deserialize<Output>(resultString);
                }
                catch (Exception e)
                {
                    throw new UserFriendlyException(e.Message);
                }
                return responseData;
            }
        }

        public async Task<List<Output>> ZabbixGet<Output>(string method, dynamic input)
        {
            await SetAuth();
            var bodyObject = new ZabbixRequestDto<dynamic>(method, input, Auth);
            string body = JsonSerializer.Serialize(bodyObject, bodyObject.GetType(),
                new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                });
            using (HttpClient httpClient = new HttpClient())
            {
                //httpClient.Timeout = TimeSpan.FromSeconds(1);

                HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(baseUrl, content);

                var resultString = await response.Content.ReadAsStringAsync();
                if (resultString == null) throw new UserFriendlyException("Zabbix request returned null");
                // File.WriteAllText("resultString.json", resultString);
                ZabbixResponseDto<List<Output>> responseData;
                try
                {
                    responseData = JsonSerializer.Deserialize<ZabbixResponseDto<List<Output>>>(resultString) ?? new ZabbixResponseDto<List<Output>>();
                }
                catch (Exception e)
                {
                    throw new UserFriendlyException($"{e.Message}");
                }
                if(responseData.error != null) throw new UserFriendlyException($"Zabbix: {responseData.error.message}", method, responseData.error.data);
                return responseData.result ?? new List<Output>();
            }
        }

        public async Task<Output?> ZabbixGetSingle<Output>(string method, dynamic input)
        {
            await SetAuth();
            var bodyObject = new ZabbixRequestDto<dynamic>(method, input, Auth);
            string body = JsonSerializer.Serialize(bodyObject, bodyObject.GetType(),
                new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                });
            using (HttpClient httpClient = new HttpClient())
            {
                //httpClient.Timeout = TimeSpan.FromSeconds(1);

                HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(baseUrl, content);

                var resultString = await response.Content.ReadAsStringAsync();
                if (resultString == null) throw new UserFriendlyException("Zabbix request returned null");
                // File.WriteAllText("resultString.json", resultString);
                ZabbixResponseDto<Output> responseData;
                try
                {
                    responseData = JsonSerializer.Deserialize<ZabbixResponseDto<Output>>(resultString);
                }
                catch (Exception e)
                {
                    throw new UserFriendlyException($"{e.Message}");
                }
                if (responseData.error != null) throw new UserFriendlyException($"Zabbix: {responseData.error.message}", method, responseData.error.data);
                return responseData.result;
            }
        }

        public async Task<dynamic> ZabbixGetD(string method, dynamic input)
        {
            await SetAuth();
            var bodyObject = new ZabbixRequestDto<dynamic>(method, input, Auth);
            string body = JsonSerializer.Serialize(bodyObject, bodyObject.GetType(),
                new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                });

            using (HttpClient httpClient = new HttpClient())
            {
                //httpClient.Timeout = TimeSpan.FromSeconds(1);

                HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(baseUrl, content);

                var resultString = await response.Content.ReadAsStringAsync();
                if (resultString == null) throw new UserFriendlyException("Zabbix request returned null");
                File.WriteAllText("resultString.json", resultString);
                dynamic? responseData;
                try
                {
                    responseData = JsonSerializer.Deserialize<ExpandoObject>(resultString);
                }
                catch (Exception)
                {
                    throw new UserFriendlyException(resultString);
                }
                return responseData;
            }
        }

        public async Task<IEnumerable<ZabbixInfo>> GetZabbixInfos()
        {
            return await _repository.GetListAsync();
        }

        public async Task<ZabbixInfo> CreateZabbixInfo(ZabbixInfo info)
        {
            return await _repository.InsertAsync(info);
        }

        public async Task<string> GetPassword(string password)
        {
            return _encryptionService.Encrypt(new SettingDefinition("Smtp.Password", isEncrypted: true), password);
        }
        public async Task<ICurrentTenant> GetCurrentTenant()
        {
            return _currentTenant;
        }
    }
}
