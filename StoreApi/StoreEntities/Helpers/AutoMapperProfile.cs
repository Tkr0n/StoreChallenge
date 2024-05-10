using AutoMapper;

namespace Domain.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Models.SignUp_Request, Entities.User>().ReverseMap();
            CreateMap<Models.User, Entities.User>().ReverseMap();
        }
    }
}
