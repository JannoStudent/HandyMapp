using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HandyMapp.Models.GoogeApi.Directions
{
    public partial class Polyline
    {
        [JsonProperty("points")]
        public string Points { get; set; }
    }
}
