﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandyMapp.Models.AddressModels
{
    public class ReviewPlace
    {
        public int Id { get; set; }
        public int? AdressId { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public Address Address { get; set; }

    }
}
