using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using KFCWeb.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace KFCWeb.Services
{
    public interface IStorageService
    {
        Task<IEnumerable<Issue>> GetIssues();
    }
    public class StorageService:IStorageService
    {
        private readonly HttpClient _httpClient;
        private readonly string _storageUrl;
        public StorageService(IOptionsSnapshot<AppSettings> settings)
        {
            _httpClient = new HttpClient();
            _storageUrl = $"{settings.Value.StorageUrl}";
        }

        public async Task<IEnumerable<Issue>> GetIssues()
        {
            var url = API.Storage.GetIssues(_storageUrl);
            var data = await _httpClient.GetStringAsync(url);
            var issues = JsonConvert.DeserializeObject<IEnumerable<Issue>>(data);
            return issues;
        }
    }
}