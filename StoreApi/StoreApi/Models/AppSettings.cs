namespace StoreApi.Models
{
    public class AppSettings
    {
        public AppSettings() { }

        public ConnectionStrings ConnectionStrings { get; set;}
        public string AppSecret { get; set;}
        public string[] AllowedUrls { get; set;}
    }

    public class ConnectionStrings
    {
        public string StoreConnection { get; set; }
    }
}
