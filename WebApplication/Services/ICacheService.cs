using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication.Services
{
    public interface ICacheService
    {
        Task<string> GetCacheValueAsync(string key);
        Task SetValueCache(string key, string value);
        void SetComplexValue(string key,Dictionary<string,string> values);
        List<string> GetComplexValue(string key,Dictionary<string,string> hashKeys);
    }
     
}