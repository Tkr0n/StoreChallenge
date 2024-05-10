using Domain.Models;

namespace Domain.Services.Interfaces
{
    public interface IOAuthService
    {
        public Task<SignUp_Response> SignUp(SignUp_Request request);
        public Task<Login_Response> Login(Login_Request request);
    }
}
