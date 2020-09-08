using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRedisService
    {
        Task<bool> DeleteKeyAsync(string key);
        Task<RedisValue> GetKeyAsync(string key);
        Task<bool> UpdateOrCreateAsync(string key, RedisValue data);
    }


}
