using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using HandyMapp.Models.Directions;
using HandyMapp.Models.GoogeApi;
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
            string s = "https://maps.googleapis.com/maps/api/directions/json?origin=" + start.lat + "," + start.lng +
                "&destination=" + end.lat + "," + end.lng +
                "&mode=walking&language=nl&unit=metric&key=AIzaSyA-ILiw69VUG6KWfiPwPq3ZKOTPGqf8hWI";

            try
            {
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(new WebClient().DownloadString("https://maps.googleapis.com/maps/api/directions/json?origin=" + start.lat + "," + start.lng + "&destination=" + end.lat + "," + end.lng + "&mode=walking&language=nl&unit=metric&key=AIzaSyA-ILiw69VUG6KWfiPwPq3ZKOTPGqf8hWI")));
                return new JsonSerializer().Deserialize<Predictions>(new JsonTextReader(new StreamReader(ms)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }



    }
}

