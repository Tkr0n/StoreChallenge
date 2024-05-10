using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface ICartByUserService
    {
        public Task<Cart_Response> Get(Cart_Request Request);

        public Task<Cart_Response> Add(Cart_Request Request);

        public Task<Cart_Response> Remove(Cart_Request Request);

        public Task<Cart_Response> Purchase(Cart_Request Request);
    }
}
