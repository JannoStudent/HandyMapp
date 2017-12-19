using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HandyMapp.Models.GoogeApi.Places.AutoComplete
{
    public partial class Predictions
    {
        [JsonProperty("predictions")]
        public Prediction[] PurplePredictions { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
