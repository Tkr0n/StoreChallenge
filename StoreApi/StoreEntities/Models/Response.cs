namespace Domain.Models
{
    public class Response : Request
    {
        public bool Success { get; set; }
        public string[] Messages { get; set; }

        public static T GetErrorResponse<T>(string[] messages = null) where T : Response, new()
        {
            return new T() { Success = false, Messages = messages };
        }
    }
}
