using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Places.Responses;
using HandyMapp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandyMapp.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Places")]
    public class PlacesController : Controller
    {
        private readonly MapsAPIClient _client;
        private readonly ApplicationDbContext _context;

        public PlacesController(ApplicationDbContext context)
        {
            _client = new MapsAPIClient("AIzaSyDfFiQB4uFA8_lS-24Ll1EFUXxfGVGoJWs");
            _context = context;
        }

        // GET: api/Places
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Places/5
        [HttpGet("{query}")]
        public PlaceDetailsResponse Get(string query)
        {
            try
            {
                return _client.Places.GetPlaceDetails(placeId: query);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        [Route("GetPlacesByLatLng/{lat:double}/{lng:double}")]
        public IEnumerable<PlaceDetailsResponse> GetPlacesByLatLng(double lat, double lng)
        {
            try
            {
                return _client.Geocoding.ReverseGeocode(location: new GeoCoordinatesLocation(lat,lng),language:"NL").Results.ToList().Select(T =>_client.Places.GetPlaceDetails(T.PlaceId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        // POST: api/Places
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }
        
        // PUT: api/Places/5
        [HttpPut("{query}")]
        public void Put(int query, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{query}")]
        public void Delete(int id)
        {
        }
    }
}
