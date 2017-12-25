using System;
using System.Linq;
using KFCWeb.Models;

namespace KFCWeb.Mappers
{
    public static class SettingsMapper
    {
        public static ConfigurationModel MapToConfiguration(SettingsViewModel settings)
        {
            return new ConfigurationModel()
            {
                ServiceName = settings.ServiceName,
                WebHookModel = new WebHookModel()
                {
                    Password = settings.Password,
                    Login = settings.Login,
                    BugTrackerUrl = settings.BugTrackerUrl,
                    WebHookName = Guid.NewGuid().ToString(),
                    WebHookUrl = settings.WebhookUrl,
                    Events = settings.Events.Where(t=>t.IsChecked).Select(t => (WebHookEventType) 
                        Enum.Parse(typeof(WebHookEventType), t.EventName)).ToArray()
                }
            };
        }
    }
}