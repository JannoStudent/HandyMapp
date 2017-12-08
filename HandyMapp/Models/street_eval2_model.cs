using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    
namespace HandyMapp.Models
{
    public class street_eval2_model
    {
        public string lat { get; set; }
        public string lng { get; set; }

        public street_eval2_model(string lat, string lng)
        {
            this.lat = lat;
            this.lng = lng;
            // string name = Request.Cookies["myCoordsBro"].Value;
        }
    }
}
