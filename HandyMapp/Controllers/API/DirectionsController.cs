using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Common.Components.Locations;
using GoogleMapsAPI.NET.API.Directions.Enums;
using GoogleMapsAPI.NET.API.Directions.Responses;
using HandyMapp.Models.GoogeApi;
using HandyMapp.Models.GoogeApi.Directions;
using HandyMapp.Models.GoogeApi.Places.Details;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HandyMapp.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Directions")]
    public class DirectionsController : Controller
    {
        [HttpGet("ByLocation")]
        public Predictions ByLocation(Location start, Location end)
        {
           
            try
            {
                MemoryStream ms = new MemoryStream(
                    Encoding.UTF8.GetBytes(
                        new WebClient().DownloadString(
                            "https://maps.googleapis.com/maps/api/directions/json?origin=" + start.lat + "," + start.lng +
                            "&destination=" + end.lat + "," + end.lng +
                            "&alternatives=true" +
                            "&mode=walking&language=nl&unit=metric&key=AIzaSyA-ILiw69VUG6KWfiPwPq3ZKOTPGqf8hWI")));
                return new JsonSerializer().Deserialize<Predictions>(new JsonTextReader(new StreamReader(ms)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        [HttpGet("ByPlaceId/{start}/{end}")]
        public GetDirectionsResponse ByPlaceId(string start, string end)
        {
            var client = new MapsAPIClient("AIzaSyDfFiQB4uFA8_lS-24Ll1EFUXxfGVGoJWs");
            
            try
            {
                MemoryStream ms = new MemoryStream(
                    Encoding.UTF8.GetBytes(
                        new WebClient()
                        .DownloadString(
                            "https://maps.googleapis.com/maps/api/directions/json?origin=place_id:" + start +
                            "&destination=place_id:" + end +
                            "&alternatives=true" +
                            "&mode=walking&language=nl&unit=metric&key=AIzaSyA-ILiw69VUG6KWfiPwPq3ZKOTPGqf8hWI")));

                var p = new JsonSerializer().Deserialize<Predictions>(new JsonTextReader(new StreamReader(ms)));
               
                return client.Directions.GetDirections(origin: new GeoCoordinatesLocation(p.Routes[0].Legs[0].StartLocation.Lat, p.Routes[0].Legs[0].StartLocation.Lng), destination: new GeoCoordinatesLocation(p.Routes[0].Legs[0].EndLocation.Lat, p.Routes[0].Legs[0].EndLocation.Lng), mode: TransportationModeEnum.Walking, waypoints: null, alternatives: true, avoid: null, language: "dutch", units: UnitSystemEnum.Metric, region: null, departureTime: DateTime.Now, arrivalTime: null, optimizeWaypoints: true, transitMode: null, transitRoutingPreference: TransitRoutingPreferenceEnum.LessWalking, trafficModel: TrafficModelEnum.BestGuess);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

    }
}

