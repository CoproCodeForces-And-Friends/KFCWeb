using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KFCWeb.Models
{
    public class SettingsViewModel
    {
        public string ServiceName { get; set; }
        public List<SelectListItem> Services { get; set; }
        public string BugTrackerUrl { get; set; }
        public string WebhookUrl { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public WebHookEventsList[] Events { get; set; }
    }

    public class WebHookEventsList
    {
        public string EventName { get; set; }
        public bool IsChecked { get; set; }
    }
}