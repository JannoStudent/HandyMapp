using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Directions.Enums;
using GoogleMapsAPI.NET.API.Directions.Responses;
using GoogleMapsAPI.NET.API.Places.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandyMapp.Controllers.API
{
    [Produces("application/json")]
    [Route("api/PlacesAutoComplete")]
    public class PlacesAutoCompleteController : Controller
    {
        private readonly MapsAPIClient _client;

        public PlacesAutoCompleteController()
        {
            _client = new MapsAPIClient("AIzaSyDfFiQB4uFA8_lS-24Ll1EFUXxfGVGoJWs");

            //_client.Places.GetPlaceDetails("safsdafdas").Result.


        }

        // GET: api/PlacesAutoComplete
        [HttpGet]
        public IEnumerable<PlacePrediction> Get()
        {
            return null;
        }

        [HttpGet("{query}")]
        public IEnumerable<PlacePrediction> Get(string query)
        {
            try
            {
                return _client.Places.AutoComplete(input: query,
                        location: new GeoCoordinatesLocation(52.058295, 4.4950389), language: "NL", radius: 2000).Predictions;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

    }
}
