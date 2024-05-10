using Application.Services;
using AutoMapper;
using Domain.Repositories;
using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IOAuthService> _oauthService;
        public ServiceManager(IRepositoryManager repository, IMapper mapper)
        {
            _oauthService = new Lazy<IOAuthService>(() => new OAuthService(repository, mapper));
        }
        public IOAuthService UserService => _oauthService.Value;

    }
}
