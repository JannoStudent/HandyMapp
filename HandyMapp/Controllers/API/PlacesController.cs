using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Runtime.Serialization.Json;
using System.Text;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces;
using GoogleMapsAPI.NET.API.Places.Components;
using HandyMapp.Data;
using HandyMapp.Models.GoogeApi;
using HandyMapp.Models.GoogeApi.Places.AutoComplete;
using HandyMapp.Models.GoogeApi.Places.Details;
using ImageSharp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Newtonsoft.Json;

namespace HandyMapp.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PlacesController : Controller
    {
        private readonly MapsAPIClient _client;
        private readonly ApplicationDbContext _context;

        public PlacesController(ApplicationDbContext context)
        {
            _client = new MapsAPIClient("AIzaSyDQBcQcRF9x8tC2_PBwF1OkkW5XACfu3bc");
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
        public PlaceDetails Get(string query)
        {
            try
            {
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(new WebClient().DownloadString("https://maps.googleapis.com/maps/api/place/details/json?placeid=" + query + "&key=AIzaSyA-ILiw69VUG6KWfiPwPq3ZKOTPGqf8hWI")));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(PlaceDetails));
                return ser.ReadObject(ms) as PlaceDetails;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        [HttpGet("ByLatLng/{lat:double}/{lng:double}")]
        public IEnumerable<PlaceDetails> ByLatLng(double lat, double lng)
        {
            try
            {
                return _client.Geocoding.ReverseGeocode(location: new GeoCoordinatesLocation(lat, lng), language: "NL").Results.ToList().Select(T => Get(T.PlaceId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        [HttpGet("AutoComplete/{query}")]
        public Predictions AutoComplete(string query)
        {
            try
             {
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(new WebClient()
                    .DownloadString("https://maps.googleapis.com/maps/api/place/autocomplete/json?input=" + query +
                                    "&language=nl" +
                                    "&location=52.058295,4.4950389" +
                                    "&radius=4000&strictbounds" +
                                    "&key=AIzaSyDlng31KQwxmdlmQme4U42NJieGP7hrpDQ")));

                return new JsonSerializer().Deserialize<Predictions>(new JsonTextReader(new StreamReader(ms)));
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
