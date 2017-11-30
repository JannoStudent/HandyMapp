using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Handy_Mapp.Models.Navigation
{
    public partial class VectorPath : IComparable<VectorPath>
    {
        public VectorPath()
        {
        }

        public VectorPath(double? distance)
        {
            Distance = distance;
        }

        public int VectorId1 { get; set; }
        public int VectorId2 { get; set; }
        public double? Distance { get; set; }

        public Vector VectorId1Navigation { get; set; }
        public Vector VectorId2Navigation { get; set; }
        public int CompareTo(VectorPath other)
        {
            if (this.Distance > other.Distance)
            {
                return 1;
            }
            if (this.Distance < other.Distance)
            {
                return -1;
            }
            return 0;
        }
    }
}
