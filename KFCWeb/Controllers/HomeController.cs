using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KFCWeb.Mappers;
using Microsoft.AspNetCore.Mvc;
using KFCWeb.Models;
using KFCWeb.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.IO.Pipelines;
using SQLitePCL;

namespace KFCWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfigurationService _configurationService;
        private readonly IStorageService _storageService;

        public HomeController(IConfigurationService configurationService, IStorageService storageService)
        {
            _configurationService = configurationService;
            _storageService = storageService;
        }

        public IActionResult Index()
        {
            var issues=  _storageService.GetIssues().Result;
            var model = new KFCIssueCollection() {Issues = issues.ToList()};
            return View(model);
        }
        
        public IActionResult Settings()
        {
            var model = new SettingsViewModel()
            {
                Services = new List<SelectListItem>()
                {
                    new SelectListItem{Value="Jira", Text = "Jira"},
                    new SelectListItem{Value = "Trello", Text = "Trello"}
                },
                Events = new WebHookEventsList[]
                {
                    new WebHookEventsList(){EventName = "IssueUpdated"},
                    new WebHookEventsList(){EventName = "IssueCreated"}
                }
            };
            return View(model);
        }

             
        //TODO запилить обработку ошибок и выдачу хоть какого то результата
        [HttpPost]
        public IActionResult Settings(SettingsViewModel model)
        {
            var configuration = SettingsMapper.MapToConfiguration(model);
            _configurationService.CreateWebhook(configuration);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}