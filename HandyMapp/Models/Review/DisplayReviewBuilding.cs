using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandyMapp.Models.GoogeApi.Places.Details;

namespace HandyMapp.Models.Review
{
    public class DisplayReviewBuilding
    {
        public PlaceDetails PlaceDetails { get; set; }
        public List<ReviewBuilding> ReviewBuildings { get; set; }
    }
}
