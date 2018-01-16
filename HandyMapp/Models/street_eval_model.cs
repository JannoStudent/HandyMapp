using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandyMapp.Models
{
    public class street_eval_model
    {
        public int Id { get; set; }
        public string aid { get; set; }
        public string lat { get; set; }

        public string lng { get; set; }

        //public string streetname { get; set; }
        public string rating { get; set; }

        public string obst_type { get; set; }
        public string description { get; set; }

        public street_eval_model()
        {

        }

        public street_eval_model(string lat, string lng, string rating, string description, string obst_type)
        {
            this.lat = lat;
            this.lng = lng;
            this.rating = rating;
            this.description = description;
            this.obst_type = obst_type;
        }
    }
}
