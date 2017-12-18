using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HandyMapp.Models.GoogeApi.Places.AutoComplete
{
    public partial class Term
    {
        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
