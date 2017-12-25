using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using KFCWeb.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace KFCWeb.Services
{
    public interface IConfigurationService
    {
        Task CreateWebhook(ConfigurationModel model);
    }
    
    public class ConfigurationService:IConfigurationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _configurationServiceUrl;
        public ConfigurationService(IOptionsSnapshot<AppSettings> settings)
        {
            _httpClient = new HttpClient();
            _configurationServiceUrl = $"{settings.Value.ConfigurationServiceUrl}";
        }
        
        public async Task CreateWebhook(ConfigurationModel model)
        {
            var url = API.Configuration.CreateWebhook(_configurationServiceUrl);
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(url, content);
        }
    }
}