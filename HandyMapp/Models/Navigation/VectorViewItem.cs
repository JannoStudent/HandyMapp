using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandyMapp.Models.GoogeApi;
using HandyMapp.Models.GoogeApi.Places.Details;

namespace HandyMapp.Models.Navigation
{
    public class VectorViewItem
    {
        public List<Vector> VectorPoints { get; set; }
        public List<Location> Locations { get; set; }
    }
}
