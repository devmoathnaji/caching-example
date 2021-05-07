using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace WebApplication.Services
{
    public class InMemoryCacheService:ICacheService
    {
        private readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        
        public Task<string> GetCacheValueAsync(string key)
        {
            return Task.FromResult(_cache.Get<string>(key));
        }

        public Task SetValueCache(string key, string value)
        {
            _cache.Set(key, value);
            return Task.CompletedTask;
        }

        public void SetComplexValue(string key,Dictionary<string,string> values)
        {
            throw new System.NotImplementedException();
        }

        public List<string> GetComplexValue(string key,Dictionary<string,string> hashKeys)
        {
            throw new System.NotImplementedException();
        }
    }
}