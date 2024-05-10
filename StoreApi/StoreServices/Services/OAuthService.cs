using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using Domain.Services.Interfaces;

namespace Application.Services
{
    public class OAuthService: IOAuthService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public OAuthService(IRepositoryManager repository, IMapper mapper) 
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<SignUp_Response> SignUp(SignUp_Request request)
        {   
            SignUp_Response response = new SignUp_Response();

            try
            {
                var mapped = _mapper.Map<Domain.Models.SignUp_Request, Domain.Entities.User>(request);
                
                mapped.UserId = Guid.NewGuid();

                await _repository.UsersRepository.Create(mapped);

                await _repository.Commit();

                response.Success = true;
                response.Messages = new string[] { "User successfully created" };
            }
            catch (Exception ex)
            {
                response.Success = false;
                Response.GetErrorResponse<SignUp_Response>(response.Messages = new string[] { ex.Message });
            }

            return response;
        }

        public async Task<Login_Response> Login(Login_Request request)
        {
            Login_Response response = new Login_Response();

            try
            {
                var credentials = await _repository.UsersRepository.Get(x => x.UserName == request.GetUserName());

                if(request.GetUserName() == credentials.UserName && request.GetPassword() == credentials.Password)
                {
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Messages = new string[] { "Invalid Credentials" };
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                Response.GetErrorResponse<Login_Response>(response.Messages = new string[] { ex.Message });
            }

            return response;
        }
    }
}
