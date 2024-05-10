using Domain.Models;

namespace Domain.Services.Interfaces
{
    public interface IProductsService
    {
        public Task<Products_Response> Get(Guid? ProductId);
    }
}
