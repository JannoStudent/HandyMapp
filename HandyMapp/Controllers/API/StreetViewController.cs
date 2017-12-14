using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleMapsAPI.NET.API.Client;
using HandyMapp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandyMapp.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class StreetViewController : Controller
    {
        private readonly MapsAPIClient _client;

        public StreetViewController()
        {
            _client = new MapsAPIClient("AIzaSyDfFiQB4uFA8_lS-24Ll1EFUXxfGVGoJWs");
        }

        // GET: api/StreetView
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/StreetView/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/StreetView
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/StreetView/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
