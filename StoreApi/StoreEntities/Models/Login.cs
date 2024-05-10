namespace Domain.Models
{
    public class Login_Request: Request
    {
        public Login_Request(string userName, string password) {
            
            _UserName = userName;
            _Password = password;
        }

        protected string _UserName;

        protected string _Password;

        public string GetUserName() => _UserName;
        public string GetPassword() => _Password;
    }

    public class Login_Response : Response
    {
        public User User { get; set; }
        public string Token;
    }
}
