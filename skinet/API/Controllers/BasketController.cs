using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Requests;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepo, IMapper mapper)
        {
            _basketRepo = basketRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> GetBasketId(string id)
        {
            var basket = await _basketRepo.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));

        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketRequest basket)
        {
            var customerBasket = _mapper.Map<CustomerBasketRequest, CustomerBasket>(basket);

            var updatedBasket = await _basketRepo.UpdateBasketAsync(customerBasket);

            return Ok(updatedBasket);
        }

        [HttpDelete("{id}")]
        public async Task DeleteBasketAsync(string id)
        {
            await _basketRepo.DeleteBasketAsync(id);
        }

    }
}
