using AutoMapper;
using Domain.Entities;
using Domain.Models;
using Domain.Repositories;
using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CartByUserService: ICartByUserService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        CartByUserService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Cart_Response> Get(Cart_Request Request)
        {
            var response = new Cart_Response();

            try
            {
                var cart = await _repository.CartByUsersRepository.Get(x => x.UserId == Request.UserId);

                if (cart != null)
                {
                    _mapper.Map<Cart_Response>(cart);

                    response.Success = true;
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                Response.GetErrorResponse<Cart_Response>(response.Messages = new string[] { ex.Message });
            }

            return response;
        }

        public async Task<Cart_Response> Add(Cart_Request Request)
        {
            var response = new Cart_Response();

            try
            {
                var product = await _repository.ProductsRepository.Get(x => x.ProductId == Request.ProductId);

                var cartExists = await _repository.CartByUsersRepository.Exists(x=>x.UserId == Request.UserId);

                var cart = new CartByUser()
                {
                    CartId = Guid.NewGuid(),
                    UserId = Request.UserId,
                    ProductId = Request.ProductId,
                    Quantity = 1,
                    
                };

                if (cartExists != null)
                {
                    await _repository.CartByUsersRepository.Create(cart);
                }

                else
                {
                    cart = await _repository.CartByUsersRepository.Get(x => x.UserId == Request.UserId);
                    _repository.CartByUsersRepository.Update(cart);
                }

                response.Success = true;
                
                await _repository.Commit();

            }
            catch (Exception ex)
            {
                response.Success = false;
                Response.GetErrorResponse<Cart_Response>(response.Messages = new string[] { ex.Message });
            }

            return response;
        }

        public async Task<Cart_Response> Remove(Cart_Request Request)
        {
            var response = new Cart_Response();

            try
            {
                var cart = await _repository.CartByUsersRepository.Get(x => x.UserId == Request.UserId && x.ProductId != Request.ProductId);

                _repository.CartByUsersRepository.Update(cart);

                response.Success = true;

                await _repository.Commit();

            }
            catch (Exception ex)
            {
                response.Success = false;
                Response.GetErrorResponse<Cart_Response>(response.Messages = new string[] { ex.Message });
            }

            return response;
        }

        public async Task<Cart_Response> Purchase(Cart_Request Request)
        {
            var response = new Cart_Response();

            try
            {
                var cart = await _repository.CartByUsersRepository.Get(x => x.UserId == Request.UserId && x.ProductId != Request.ProductId);

                _repository.CartByUsersRepository.Delete(cart);

                response.Success = true;

                await _repository.Commit();

            }
            catch (Exception ex)
            {
                response.Success = false;
                Response.GetErrorResponse<Cart_Response>(response.Messages = new string[] { ex.Message });
            }

            return response;
        }
    }
}
