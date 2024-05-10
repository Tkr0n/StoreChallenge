using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using Domain.Services.Interfaces;

namespace Application.Services
{
    public class ProductsService: IProductsService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        ProductsService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Products_Response> Get(Guid? ProductId) 
        {
            var response = new Products_Response();

            try
            {
                var products = await _repository.ProductsRepository.GetAll(x=> ProductId != null ? x.ProductId == ProductId : x.ProductId == x.ProductId);

                if (products != null)
                {
                    _mapper.Map<Products_Response>(products);
                    
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Messages = new string[] { "Error fetching products" };
                }

            }catch (Exception ex)
            {
                response.Success = false;
                Response.GetErrorResponse<Products_Response>(response.Messages = new string[] { ex.Message });
            }

            return response;
        }

    }
}
