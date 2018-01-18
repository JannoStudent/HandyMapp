using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandyMapp.Models.GoogeApi.Places.Details
{
    public class PlaceDetails
    {
        public List<object> html_attributions { get; set; }
        public Result result { get; set; }
        public string status { get; set; }

        public int Ratting { get; set; }
    }
}
