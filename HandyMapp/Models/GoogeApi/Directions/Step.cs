using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HandyMapp.Models.GoogeApi.Directions
{
    public partial class Step
    {
        [JsonProperty("distance")]
        public Distance Distance { get; set; }

        [JsonProperty("duration")]
        public Distance Duration { get; set; }

        [JsonProperty("end_location")]
        public LatLng EndLocation { get; set; }

        [JsonProperty("html_instructions")]
        public string HtmlInstructions { get; set; }

        [JsonProperty("polyline")]
        public Polyline Polyline { get; set; }

        [JsonProperty("start_location")]
        public LatLng StartLocation { get; set; }

        [JsonProperty("travel_mode")]
        public string TravelMode { get; set; }

        [JsonProperty("maneuver")]
        public string Maneuver { get; set; }
    }
}
