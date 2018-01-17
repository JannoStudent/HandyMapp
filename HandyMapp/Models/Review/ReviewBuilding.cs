using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HandyMapp.Models.GoogeApi.Places.Details;
using Newtonsoft.Json;

namespace HandyMapp.Models.Review
{
    public class ReviewBuilding
    {
        [Key]
        [JsonProperty("placeId")]
        public string PlaceId { get; set; }
        [JsonProperty("rating")]
        public int Rating { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("ramps")]
        public QuestionOption Ramps { get; set; }
        [JsonProperty("threshold")]
        public QuestionOption Threshold { get; set; }
        [JsonProperty("elevators")]
        public QuestionOption Elevators { get; set; }
        [JsonProperty("accessibleToilets")]
        public QuestionOption AccessibleToilets { get; set; }
        [JsonProperty("hallwaysWide")]
        public QuestionOption HallwaysWide { get; set; }
        [JsonProperty("looseTilesOrFloormats")]
        public QuestionOption LooseTilesOrFloormats { get; set; }
    }
}
