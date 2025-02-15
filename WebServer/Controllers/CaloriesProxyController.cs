﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaloriesProxyController : ControllerBase
    {
        [HttpGet(nameof(DailyAsync))]
        public async Task<IEnumerable<Calorie>> DailyAsync()
        {
            var url = "https://apim-svastha-dev.azure-api.net/sampledata/daily";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("api-version", "v1");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "");

            var res = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<IEnumerable<Calorie>>(res);
        }
    }
}
