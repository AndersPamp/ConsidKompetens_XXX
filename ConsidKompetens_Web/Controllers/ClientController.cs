using System.Collections.Generic;
using ConsidKompetens_Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConsidKompetens_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IDataProvider _data;

        public ClientController(ILogger<ClientController> logger, IDataProvider data)
        {
            _logger = logger;
            _data = data;
        }

        // GET: api/Client
        [Authorize]
        [HttpGet]
        public IEnumerable<string> SpaPage()
        {
            return new string[] { "Logged in" };
        }

        // GET: api/Client/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Client
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
