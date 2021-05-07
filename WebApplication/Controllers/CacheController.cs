using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CacheController : ControllerBase
    {
        private readonly ICacheService _cacheService;

        public CacheController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string key)
        {
           var data =await _cacheService.GetCacheValueAsync(key);
           return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> Set(string key, string value)
        {
            await _cacheService.SetValueCache(key, value);
            return Ok();
        }

        [HttpPost]
        public IActionResult GetComplexValue(Input input)
        {
            var data = _cacheService.GetComplexValue(input.Key,input.HashMap);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult SetComplexValue(Input input)
        {
            _cacheService.SetComplexValue(input.Key,input.HashMap);
            return Ok();
        }

    }

    public class Input
    {
        public string Key { get; set; }
        public Dictionary<string,string> HashMap { get; set; }
    }
}