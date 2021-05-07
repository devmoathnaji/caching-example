using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;
using WebApplication.Filters;

namespace WebApplication.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<string> GetCacheValueAsync(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            return await db.StringGetAsync(key);
        }

        public Task SetValueCache(string key, string value)
        {
            var db = _connectionMultiplexer.GetDatabase();
            db.StringSetAsync(key, value);
            return Task.CompletedTask;
        }

        public async void SetComplexValue(string key,Dictionary<string,string> values)
        {
            var db = _connectionMultiplexer.GetDatabase();
            if (values == null)
            {
                ResultModel<string> res = new ResultModel<string>();
                res.Message = "Dictionary cant be null";
                res.Result = null;
                res.Results = null;
                res.IsSuccess = false;
                res.StatusCode = 400;
                ResultFilter<string> result = new ResultFilter<string>(res);
            }

            foreach (var item in values)
            {
                await db.HashSetAsync(key, new HashEntry[] {new HashEntry(name: item.Key, item.Value)});
            }
            //await db.HashSetAsync(key, new HashEntry[] { new HashEntry("12", "13"), new HashEntry("14", "15") });
        }

        public List<string> GetComplexValue(string key,Dictionary<string,string> hashKeys)
        {
            var db = _connectionMultiplexer.GetDatabase();
            string redisHashResult = "";
            List<string> cacheResult = new List<string>();
            foreach (var item in hashKeys)
            {
                redisHashResult =  db.HashGet(key, item.Key);
                cacheResult.Add(redisHashResult);
            }
            return cacheResult;
        }



       
    }
}