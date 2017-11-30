using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Handy_Mapp.Models.Addresmoddels
{
    public partial class Address
    {


        public int Id { get; set; }
        [Required]
        public int StreetId { get; set; }
        [Required]
        public string StreetNumber { get; set; }
        public int? PostCodeId { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public int ProvinceId { get; set; }
        [Required]
        public string PlaceId { get; set; }
        [Required]
        public int CountryId { get; set; }

        public int ScooterRating { get; set; }
        public int WeelchairRating { get; set; }
        public int WalkerRating { get; set; }
        public int CaneRating { get; set; }

        public City City { get; set; }
        public Country Country { get; set; }
        public PostCode PostCode { get; set; }
        public Province Province { get; set; }
        public Street Street { get; set; }
    }
}
