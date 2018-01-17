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

        public int AvrageRatting { get; set; }
        public int ScooterRatting { get; set; }
        public int WheelchairRatting { get; set; }
        public int WalkerRatting { get; set; }
        public int WalkingStickRatting { get; set; }
    }
}
