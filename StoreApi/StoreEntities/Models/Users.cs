namespace Domain.Models
{
    public class Users_Request: Request
    {
        public Users_Request() { 
        
            Users = new List<User>();
        }

        public List<User> Users { get; set; }
    }
    public class Users_Response : Response
    {

    }

    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
