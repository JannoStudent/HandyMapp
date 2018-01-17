using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HandyMapp.Models.GoogeApi.Directions
{
    public partial class Bounds
    {
        [JsonProperty("northeast")]
        public LatLng LatLng { get; set; }

        [JsonProperty("southwest")]
        public LatLng Southwest { get; set; }
    }
}
