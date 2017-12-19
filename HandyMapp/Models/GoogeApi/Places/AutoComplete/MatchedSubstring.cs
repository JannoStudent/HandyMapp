using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HandyMapp.Models.GoogeApi.Places.AutoComplete
{
    public partial class MatchedSubstring
    {
        [JsonProperty("length")]
        public long Length { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }
    }
}
