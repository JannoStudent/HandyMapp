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
using GoogleMapsAPI.NET.API.Places.Components;
using HandyMapp.Data;
using HandyMapp.Models.GoogeApi;
using ImageSharp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;

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
        public PlaceDetails Get(string query)
        {
            try
            {
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(new WebClient().DownloadString("https://maps.googleapis.com/maps/api/place/details/json?placeid=" + query + "&key=AIzaSyDfFiQB4uFA8_lS-24Ll1EFUXxfGVGoJWs")));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(PlaceDetails));
                var test = ser.ReadObject(ms) as PlaceDetails;
                return test;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        [HttpGet("GetPhoto/{query}")]
        public Image GetPhoto(string query)
        {
            try
            {
                //var imageString = new WebClient().DownloadString("https://maps.googleapis.com/maps/api/place/photo?maxwidth=800&photoreference=" + query + "&key=AIzaSyDfFiQB4uFA8_lS-24Ll1EFUXxfGVGoJWs");
                //var imageString = "https://maps.googleapis.com/maps/api/place/photo?maxwidth=800&photoreference=" + query + "&key=AIzaSyDfFiQB4uFA8_lS-24Ll1EFUXxfGVGoJWs";
                //imageString = "<img src="+ imageString + " alt=\"Photo location\">";

                var imageBytes = new WebClient().DownloadData("https://maps.googleapis.com/maps/api/place/photo?maxwidth=800&photoreference=" + query + "&key=AIzaSyDfFiQB4uFA8_lS-24Ll1EFUXxfGVGoJWs");
                var image = new Image(imageBytes);
                var test = File(imageBytes, ".jpg");
                return image;
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
        public IEnumerable<PlacePrediction> AutoComplete(string query)
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
