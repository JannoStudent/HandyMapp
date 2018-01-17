using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HandyMapp.Models.GoogeApi.Directions
{
    public class Request
    {
        [JsonProperty("destination")]
        public DirectionQuery Destination { get; set; }
        [JsonProperty("origin")]
        public DirectionQuery Origin { get; set; }
        [JsonProperty("travelMode")]
        public string TravelMode { get; set; }
    }
}
