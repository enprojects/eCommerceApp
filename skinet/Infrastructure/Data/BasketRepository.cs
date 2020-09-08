using System;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.Data
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IRedisService _redis;

        public BasketRepository(IRedisService redis)
        {
            _redis = redis;
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _redis.DeleteKeyAsync(basketId);
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {

            var data = await _redis.GetKeyAsync(basketId);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var created = await _redis.UpdateOrCreateAsync(basket.Id, 
                JsonSerializer.Serialize(basket));

            if (!created) return null;

            return await GetBasketAsync(basket.Id);
        }
    }
}