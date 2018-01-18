using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandyMapp.Models.Navigation
{
    public class Preference
    {
        public bool Bench { get; set; }
        public bool DamagedSideWalk { get; set; }
        public bool Elevator { get; set; }
        public bool NarrowEntrance { get; set; }
        public bool RoadWork { get; set; }
        public bool Stairs { get; set; }
        public bool SteepRoad { get; set; }
    }
}
