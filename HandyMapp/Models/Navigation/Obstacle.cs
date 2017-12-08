using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandyMapp.Models.Navigation
{
    public partial class Obstacle
    {
        public int Id { get; set; }
        public int? VectorId { get; set; }
        public double? Weight { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public Vector Vector { get; set; }
        public ObstacleType ObstacleType { get; set; }

    }
}
