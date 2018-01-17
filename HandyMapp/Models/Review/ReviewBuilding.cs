using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandyMapp.Models.GoogeApi.Places.Details;

namespace HandyMapp.Models.Review
{
    public class ReviewBuilding
    {
        public PlaceDetails PlaceDetails { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }

    }
}
