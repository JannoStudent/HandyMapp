using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Handy_Mapp.Models.Addresmoddels;

namespace Handy_Mapp.Models.AddressModels
{
    public class ReviewAddress
    {
        public int Id { get; set; }
        public int? AdressId { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public Address Address { get; set; }

    }
}
