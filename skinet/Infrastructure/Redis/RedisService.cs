using Core.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Redis
{
  

    public class RedisService : IRedisService
    {
        private readonly IDatabase _database;
        public RedisService(IConnectionMultiplexer connection)
        {
            _database = connection.GetDatabase();
        }

        public async Task<bool> UpdateOrCreateAsync(string key, RedisValue data)
        {
            return await _database.StringSetAsync(key, data, TimeSpan.FromDays(30));
        }

        public async Task<RedisValue> GetKeyAsync(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("redis key name is emoty or null");

            return await _database.StringGetAsync(key);

        }

        public async Task<bool> DeleteKeyAsync(string key)
        {
            return  await _database.KeyDeleteAsync(key);
        }

    }
}
