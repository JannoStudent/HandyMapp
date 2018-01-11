using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HandyMapp.Models.GoogeApi.Directions;

namespace HandyMapp.Models.Directions
{
    public partial class Predictions
    {
        [JsonProperty("geocoded_waypoints")]
        public GeocodedWaypoint[] GeocodedWaypoints { get; set; }

        [JsonProperty("routes")]
        public Route[] Routes { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
