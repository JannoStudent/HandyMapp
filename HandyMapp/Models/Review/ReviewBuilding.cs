using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandyMapp.Models.GoogeApi.Places.Details;

namespace HandyMapp.Models.Review
{
    public class ReviewBuilding
    {
        public string PlaceId { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public string Ramps { get; set; }
        public string Threshold { get; set; }
        public string Elevators { get; set; }
        public string AccessibleToilets { get; set; }
        public string HallwaysWide { get; set; }
        public string LooseTilesOrFloormats { get; set; }
    }
}
