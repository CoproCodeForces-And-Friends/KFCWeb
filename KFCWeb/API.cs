namespace KFCWeb
{
    public static class API
    {
        public static class Storage
        {
            public static string GetIssues(string baseUrl)
            {
                return $"{baseUrl}/api/storage/StoreData";
            }
        }

        public static class Configuration
        {
            public static string CreateWebhook(string baseUrl)
            {
                return $"{baseUrl}/createhook";
            }
        }
    }
}