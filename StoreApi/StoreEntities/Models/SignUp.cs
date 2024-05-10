namespace Domain.Models
{
    public class SignUp_Request: Request
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set;}
        public string PhoneNumber { get; set;}

    }

    public class SignUp_Response: Response
    {
        public Login_Response? Login { get; set; }
    }
}
