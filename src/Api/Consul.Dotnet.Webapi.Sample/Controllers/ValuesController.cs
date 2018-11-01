using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace Consul.Dotnet.Webapi.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet("{key}")]
        public async Task<ActionResult<KeyValuePair<string, string>>> Get(string key)
        {
            return new KeyValuePair<string, string>(key, await ConsulGateway.GetValue(key));
        }
    }
}
