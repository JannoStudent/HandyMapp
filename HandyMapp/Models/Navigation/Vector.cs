using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using HandyMapp.Models.Addresmoddels;

namespace HandyMapp.Models.Navigation 
{
    public partial class Vector
    {
        public Vector()
        {
            Obstacle = new HashSet<Obstacle>();
            VectorPathVectorId1Navigation = new HashSet<VectorPath>();
            VectorPathVectorId2Navigation = new HashSet<VectorPath>();
        }

        public Vector(double? latitude, double? longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            Obstacle = new HashSet<Obstacle>();
            VectorPathVectorId1Navigation = new HashSet<VectorPath>();
            VectorPathVectorId2Navigation = new HashSet<VectorPath>();
        }
        
        public int Id { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double Weight { get; set; }
        public ICollection<Obstacle> Obstacle { get; set; }
        public ICollection<VectorPath> VectorPathVectorId1Navigation { get; set; }
        public ICollection<VectorPath> VectorPathVectorId2Navigation { get; set; }

        public double GetDistance(Vector goalVector)
        {
            double? dx = this.Latitude - goalVector.Latitude;
            double? dy = this.Longitude - goalVector.Longitude;
            return Math.Sqrt((double) (dx * dx + dy * dy));
        }
    
    }
}
