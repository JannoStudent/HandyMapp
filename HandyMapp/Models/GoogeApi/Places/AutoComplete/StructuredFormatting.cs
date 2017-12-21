using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HandyMapp.Models.GoogeApi.Places.AutoComplete
{
    public partial class StructuredFormatting
    {
        [JsonProperty("main_text")]
        public string MainText { get; set; }

        [JsonProperty("main_text_matched_substrings")]
        public MatchedSubstring[] MainTextMatchedSubstrings { get; set; }

        [JsonProperty("secondary_text")]
        public string SecondaryText { get; set; }
    }
}
