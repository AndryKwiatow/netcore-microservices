using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using MS.AFORO255.History.DTOs;
using MS.AFORO255.History.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS.AFORO255.History.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;
        private readonly IDistributedCache _distributedCache;

        public HistoryController(IHistoryService historyService, IDistributedCache distributedCache)
        {
            _historyService = historyService;
            _distributedCache = distributedCache;
        }

        //[HttpGet("{accountId}")]
        //public async Task<IActionResult> Get(int accountId)
        //{
        //    var result = await _historyService.GetAll();
        //    var model = result.Where(x => x.AccountId == accountId).ToList();
        //    return Ok(model);
        //}


        [HttpGet("{accountId}")]
        public async Task<IActionResult> Get(int accountId)
        {
            string historydata = $"key-{accountId}";
            var _cache = _distributedCache.GetString(historydata);
            IEnumerable<HistoryResponse> model = null;

            if (_cache == null)
            {
                var result = await _historyService.GetAll();
                model = result.Where(x => x.AccountId == accountId).ToList();

                var options = new DistributedCacheEntryOptions()
                                    .SetSlidingExpiration(TimeSpan.FromSeconds(10));
                _distributedCache.SetString(historydata, Newtonsoft.Json.JsonConvert.SerializeObject(model), options);
            }
            else
            {
                model = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HistoryResponse>>(_cache);
            }
           
            return Ok(model);
        }
    }
}
