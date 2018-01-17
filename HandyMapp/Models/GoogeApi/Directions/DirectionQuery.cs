using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HandyMapp.Models.GoogeApi.Directions
{
    public class DirectionQuery
    {
        [JsonProperty("query")]
        public string Query { get; set; }
    }
}
